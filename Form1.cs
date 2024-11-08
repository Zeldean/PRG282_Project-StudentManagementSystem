using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class frmMain : Form
    {
        // Create the read and write objects with the file path
        static string filePath = Path.Combine(".", "Student.txt");
        Read myreader = new Read(filePath);
        Write mywriter = new Write(filePath);

        // Create the dataHandler object
        DataHandler dataHandler = new DataHandler();
        BindingSource bs = new BindingSource();

        List<(string Action, string StudentID, DateTime Timestamp)> ProgressList = new List<(string, string, DateTime)>();


        public frmMain()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Does the file exixt check and the initual read of data
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                dataHandler.Students.Clear();
                //return;
            }
            dataHandler.Students = myreader.read();

            string databasePath = Path.Combine(Application.StartupPath, "SMSLogs.db");

            // Check if the database file already exists
            if (!File.Exists(databasePath))
            {
                // Create the database file
                SQLiteConnection.CreateFile(databasePath);
                MessageBox.Show("Database created at " + databasePath);

               
                // Initialize the database with the Logs table
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    connection.Open();

                    // Create the Logs table
                    string createLogsTable = @"
                    CREATE TABLE IF NOT EXISTS Logs (
                    LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Action TEXT NOT NULL,
                    StudentID TEXT NOT NULL,
                    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (StudentID) REFERENCES Users(Id)
                    );";

                    using (SQLiteCommand command = new SQLiteCommand(createLogsTable, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Table 'Logs' created.");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Database already exists.");
            }


        }





        private void VIEWbtn_Click(object sender, EventArgs e)
        {
            SEARCHtb.Clear();
            bs.DataSource = dataHandler.Students;
            dgvDataOutput.DataSource = bs;
        }

        private void ADDbtn_Click(object sender, EventArgs e)
        {
            // Call validation method
            if (dataHandler.Validations(IDtb, NAMEtb,Surnametb, AGEtb, PHONEtb, COURSEtb))
            {
                //add the student if validations are successful
                dataHandler.Students.Add(new Student(IDtb.Text, NAMEtb.Text, Surnametb.Text,(int)AGEtb.Value, PHONEtb.Text, COURSEtb.Text));
                bs.DataSource = null; // Clear previous data source
                bs.DataSource = dataHandler.Students; // Update data source
                dgvDataOutput.DataSource = bs; // Refresh the DataGridView
                dataHandler.LogData("Student Added", IDtb.Text);
                ProgressList = dataHandler.logList;
                ClearTextBoxes();
            }
        }

        private void UPDATEbtn_Click(object sender, EventArgs e)
        {
            UpdateRow();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked row is valid
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvDataOutput.Rows[e.RowIndex];  // Get the index of the clicked cell/row

                    // Check for null cells to avoid NullReferenceException
                    IDtb.Text = row.Cells["StudentID"].Value?.ToString();
                    NAMEtb.Text = row.Cells["Name"].Value?.ToString();
                    Surnametb.Text = row.Cells["Surname"].Value?.ToString();
                    AGEtb.Text = row.Cells["Age"].Value?.ToString();
                    PHONEtb.Text = row.Cells["PhoneNumber"].Value?.ToString();
                    COURSEtb.Text = row.Cells["Course"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void DELETEbtn_Click(object sender, EventArgs e)
        {
            dataHandler.deleteStudent(dgvDataOutput,dataHandler.Students);
            dataHandler.LogData("Deleted Student", IDtb.Text);
            ProgressList = dataHandler.logList;
            ClearTextBoxes();
        }

        private void SEARCHtb_TextChanged(object sender, EventArgs e)
        {
            List<Student> filterdStudentList = DataHandler.FindID(SEARCHtb.Text, dataHandler.Students);
            bs.DataSource = filterdStudentList;

            dgvDataOutput.DataSource = bs;
        }

        private void SUMMARYbtn_Click(object sender, EventArgs e)
        {
            var (studentCount, averageAge) = DataHandler.GetSummary(dataHandler.Students);

            using (FileStream fileStream = new FileStream(@"./summary.txt", FileMode.OpenOrCreate))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("Summary");
                writer.WriteLine("====================");
                writer.WriteLine($"Total Number of Students: {studentCount}");
                writer.WriteLine($"Average Age of Students: {averageAge}");
            }

            MessageBox.Show("Summary report has been generated successfully.");

            lblStdCount.Text = studentCount.ToString();
            lblAvgAge.Text = Math.Round(averageAge).ToString();
        }

        private void UpdateRow() ///JpSeaman
        {
            // Ensure that a row is selected to make sure a cell is not just clicked by accident 
            if (dgvDataOutput.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDataOutput.SelectedRows[0];
                string currentID = selectedRow.Cells["StudentID"].Value.ToString(); // Get current ID
                string newID = IDtb.Text; // New ID from the text box

                // Check for ID matches if changed
                if (newID != currentID && dataHandler.Students.Any(students => students.StudentID == newID))
                {
                    MessageBox.Show("The Student ID already exists. Please enter a unique ID.");
                    dataHandler.ShowDuplicatePopup(newID);
                    return; // Exit if the ID already exists
                }

                    // Update the cells in the DataGridView with the new values
                    selectedRow.Cells["StudentID"].Value = newID;
                    selectedRow.Cells["Name"].Value = NAMEtb.Text;
                    selectedRow.Cells["Surname"].Value = Surnametb.Text;
                    selectedRow.Cells["Age"].Value = AGEtb.Text;
                    selectedRow.Cells["PhoneNumber"].Value = PHONEtb.Text;
                    selectedRow.Cells["Course"].Value = COURSEtb.Text;

                    List<string> updatedList = new List<string>();
                    foreach (Student student in dataHandler.Students)
                    {
                        updatedList.Add($"{student.StudentID},{student.Name},{student.Surname},{student.Age},{student.PhoneNumber},{student.Course}");
                    }

                    ClearTextBoxes();
                    dataHandler.LogData("Updated Student", newID);
                    ProgressList = dataHandler.logList;
                    MessageBox.Show("Sucessdully updated Student Information");
                

            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void ClearTextBoxes()///JpSeaman
        {
            IDtb.Text = string.Empty;
            NAMEtb.Text = string.Empty;
            Surnametb.Text = string.Empty;
            AGEtb.Value = 0; 
            PHONEtb.Text = string.Empty;
            COURSEtb.Text = string.Empty;
        }

        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            dataHandler.Students.Clear();
            dataHandler.Students = myreader.read();

            bs.DataSource = dataHandler.Students;
            dgvDataOutput.DataSource = bs;

            MessageBox.Show("Changes has been discarded");
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            mywriter.write(dataHandler.Students);
            dataHandler.LogToDataBase(ProgressList);
            dataHandler.ReadLogsFromDatabase();
            MessageBox.Show("Changes has been saved");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close. All unsaved changes will be lost", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
