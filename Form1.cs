using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Form1 : Form
    {
        // Create the read and write objects with the file path
        static string filePath = Path.Combine(".", "Content.txt");
        Read myreader = new Read(filePath);
        Write mywriter = new Write(filePath);

        // Create the dataHandler object
        DataHandler dataHandler = new DataHandler();
        BindingSource bs = new BindingSource();

        public Form1()
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
                return;
            }
            dataHandler.Students = myreader.read();
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
            if (dataHandler.Validations(IDtb, NAMEtb, AGEtb, COURSEtb))
            {
                //add the student if validations are successful
                dataHandler.Students.Add(new Student(IDtb.Text, NAMEtb.Text, (int)AGEtb.Value, COURSEtb.Text));
                //List<string> list = new List<string>();  
                //mywriter.write(dataHandler.Students);
                bs.DataSource = null; // Clear previous data source
                bs.DataSource = dataHandler.Students; // Update data source
                dgvDataOutput.DataSource = bs; // Refresh the DataGridView
                ClearTextBoxes();
            }
        }

        private void UPDATEbtn_Click(object sender, EventArgs e)
        {
            UpdateRow();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDataOutput.Rows[e.RowIndex];  //Get the index of the clicked cell/row
            IDtb.Text = row.Cells["StudentID"].Value.ToString();
            NAMEtb.Text = row.Cells["Name"].Value.ToString();
            AGEtb.Text = row.Cells["Age"].Value.ToString();
            COURSEtb.Text = row.Cells["Course"].Value.ToString();
        }
        
        private void DELETEbtn_Click(object sender, EventArgs e)
        {
           dataHandler.deleteStudent(dgvDataOutput,dataHandler.Students);
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
                selectedRow.Cells["Age"].Value = AGEtb.Text;
                selectedRow.Cells["Course"].Value = COURSEtb.Text;

                List<string> updatedList = new List<string>();
                foreach (Student student in dataHandler.Students)
                {
                    updatedList.Add($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
                }

                // Write the updated list to a file
                //File.WriteAllLines(filePath, updatedList);
                //ClearTextBoxes();
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
            AGEtb.Value = 0; // Assuming AGEtb is a NumericUpDown
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
            MessageBox.Show("Changes has been saved");
        }
    }
}
