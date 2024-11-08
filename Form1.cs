using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class frmMain : Form
    {
        // File and Database Paths
        private static readonly string filePath = Path.Combine(".", "Student.txt");
        private readonly string databasePath = Path.Combine(Application.StartupPath, "SMSLogs.db");

        // Reader, Writer, and DataHandler Objects
        private readonly Read myreader = new Read(filePath);
        private readonly Write mywriter = new Write(filePath);
        private readonly DataHandler dataHandler = new DataHandler();

        // Binding Source and Progress Tracking
        private readonly BindingSource bs = new BindingSource();
        private List<(string Action, string StudentID, DateTime Timestamp)> ProgressList = new List<(string, string, DateTime)>();
        private bool unSavedChanges = false;

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load event - Initializes data and database.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeStudentData();
            InitializeDatabase();
        }

        /// <summary>
        /// Initializes student data from file.
        /// </summary>
        private void InitializeStudentData()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                dataHandler.Students.Clear();
            }
            dataHandler.Students = myreader.read();
        }

        /// <summary>
        /// Initializes the SQLite database and creates necessary tables if not present.
        /// </summary>
        private void InitializeDatabase()
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
                MessageBox.Show("Database created at " + databasePath);

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    connection.Open();
                    string createLogsTable = @"
                    CREATE TABLE IF NOT EXISTS Logs (
                    LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Action TEXT NOT NULL,
                    StudentID TEXT NOT NULL,
                    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
                    );";
                    using (SQLiteCommand command = new SQLiteCommand(createLogsTable, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Table 'Logs' created.");
                    }
                }
            }
        }

        /// <summary>
        /// View button click event - Displays all students.
        /// </summary>
        private void VIEWbtn_Click(object sender, EventArgs e)
        {
            SEARCHtb.Clear();
            bs.DataSource = dataHandler.Students;
            dgvDataOutput.DataSource = bs;
        }

        /// <summary>
        /// Add button click event - Adds a new student.
        /// </summary>
        private void ADDbtn_Click(object sender, EventArgs e)
        {
            if (dataHandler.Validations(IDtb, NAMEtb, Surnametb, AGEtb, PHONEtb, COURSEtb))
            {
                dataHandler.Students.Add(new Student(IDtb.Text, NAMEtb.Text, Surnametb.Text, (int)AGEtb.Value, PHONEtb.Text, COURSEtb.Text));
                RefreshStudentData();
                dataHandler.LogData("Student Added", IDtb.Text);
                ProgressList = dataHandler.logList;
                unSavedChanges = true;
                ClearTextBoxes();
            }
        }

        /// <summary>
        /// Update button click event - Updates the selected student information.
        /// </summary>
        private void UPDATEbtn_Click(object sender, EventArgs e)
        {
            UpdateRow();
            unSavedChanges = true;
        }

        /// <summary>
        /// Cell click event for DataGridView - Populates text fields with selected row data.
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDataOutput.Rows[e.RowIndex];
                IDtb.Text = row.Cells["StudentID"].Value?.ToString();
                NAMEtb.Text = row.Cells["Name"].Value?.ToString();
                Surnametb.Text = row.Cells["Surname"].Value?.ToString();
                AGEtb.Text = row.Cells["Age"].Value?.ToString();
                PHONEtb.Text = row.Cells["PhoneNumber"].Value?.ToString();
                COURSEtb.Text = row.Cells["Course"].Value?.ToString();
            }
        }

        /// <summary>
        /// Delete button click event - Deletes the selected student.
        /// </summary>
        private void DELETEbtn_Click(object sender, EventArgs e)
        {
            dataHandler.deleteStudent(dgvDataOutput, dataHandler.Students);
            dataHandler.LogData("Deleted Student", IDtb.Text);
            ProgressList = dataHandler.logList;
            unSavedChanges = true;
            ClearTextBoxes();
        }

        /// <summary>
        /// Search textbox change event - Filters students by ID.
        /// </summary>
        private void SEARCHtb_TextChanged(object sender, EventArgs e)
        {
            List<Student> filterdStudentList = DataHandler.FindID(SEARCHtb.Text, dataHandler.Students);
            bs.DataSource = filterdStudentList;
            dgvDataOutput.DataSource = bs;
        }

        /// <summary>
        /// Summary button click event - Generates a summary report.
        /// </summary>
        private void SUMMARYbtn_Click(object sender, EventArgs e)
        {
            var (studentCount, averageAge) = DataHandler.GetSummary(dataHandler.Students);

            using (FileStream fileStream = new FileStream("./summary.txt", FileMode.OpenOrCreate))
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

        /// <summary>
        /// Updates the selected student's information.
        /// </summary>
        private void UpdateRow()
        {
            if (dgvDataOutput.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDataOutput.SelectedRows[0];
                string currentID = selectedRow.Cells["StudentID"].Value.ToString();
                string newID = IDtb.Text;

                if (newID != currentID && dataHandler.Students.Any(students => students.StudentID == newID))
                {
                    MessageBox.Show("The Student ID already exists. Please enter a unique ID.");
                    dataHandler.ShowDuplicatePopup(newID);
                    return;
                }

                selectedRow.Cells["StudentID"].Value = newID;
                selectedRow.Cells["Name"].Value = NAMEtb.Text;
                selectedRow.Cells["Surname"].Value = Surnametb.Text;
                selectedRow.Cells["Age"].Value = AGEtb.Text;
                selectedRow.Cells["PhoneNumber"].Value = PHONEtb.Text;
                selectedRow.Cells["Course"].Value = COURSEtb.Text;

                ClearTextBoxes();
                dataHandler.LogData("Updated Student", newID);
                ProgressList = dataHandler.logList;
                MessageBox.Show("Successfully updated Student Information");
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        /// <summary>
        /// Clears all the textboxes in the form.
        /// </summary>
        private void ClearTextBoxes()
        {
            IDtb.Text = string.Empty;
            NAMEtb.Text = string.Empty;
            Surnametb.Text = string.Empty;
            AGEtb.Value = 0;
            PHONEtb.Text = string.Empty;
            COURSEtb.Text = string.Empty;
        }

        /// <summary>
        /// Discard changes button click event - Reloads student data from file.
        /// </summary>
        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            dataHandler.Students.Clear();
            dataHandler.Students = myreader.read();
            bs.DataSource = dataHandler.Students;
            dgvDataOutput.DataSource = bs;
            unSavedChanges = false;
            MessageBox.Show("Changes have been discarded");
        }

        /// <summary>
        /// Save changes button click event - Saves all changes to file and database.
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            mywriter.write(dataHandler.Students);
            dataHandler.LogToDataBase(ProgressList);
            dataHandler.ReadLogsFromDatabase();
            unSavedChanges = false;
            MessageBox.Show("Changes have been saved");
        }

        /// <summary>
        /// Close button click event - Closes the application after confirming unsaved changes.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to close? All unsaved changes will be lost.";
            if (!unSavedChanges || MessageBox.Show(message, "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Refreshes the student data and updates the DataGridView.
        /// </summary>
        private void RefreshStudentData()
        {
            bs.DataSource = null;
            bs.DataSource = dataHandler.Students;
            dgvDataOutput.DataSource = bs;
        }
    }
}
