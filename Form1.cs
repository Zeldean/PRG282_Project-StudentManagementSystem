using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string path = Path.GetFullPath("Content.txt");
        Read myreader = new Read();
        DataHandler handler = new DataHandler();
        BindingSource bs = new BindingSource();
        List<Student> studentlist = new List<Student>();

        private void VIEWbtn_Click(object sender, EventArgs e)
        {
            bs.DataSource = studentlist;
            dataGridView1.DataSource = bs;
        }

        private void ADDbtn_Click(object sender, EventArgs e)
        {
            // Call validation method
            if (handler.Validations(IDtb, NAMEtb, AGEtb, COURSEtb))
            {
                //add the student if validations are successful
                studentlist.Add(new Student(IDtb.Text, NAMEtb.Text, (int)AGEtb.Value, COURSEtb.Text));
                List<string> list = new List<string>();
                foreach (Student student in studentlist)
                {
                    list.Add($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
                }
                // Write the student to a file
                File.WriteAllLines(myreader.filePath, list);
                bs.DataSource = null; // Clear previous data source
                bs.DataSource = studentlist; // Update data source
                dataGridView1.DataSource = bs; // Refresh the DataGridView
                ClearTextBoxes();
            }
        }


        private void SEARCHtb_TextChanged(object sender, EventArgs e)
        {
            List<Student> filterdStudentList = DataHandler.FindID(SEARCHtb.Text, studentlist);
            bs.DataSource = filterdStudentList;

            dataGridView1.DataSource = bs;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Boolean notexist = !File.Exists(path);

            if (notexist)
            {
                File.CreateText(path);
            }
            if (new FileInfo(path).Length == 0)
            {

            }
            else
            {
                List<Student> list = new List<Student>();
                list = handler.format(myreader.read());
                studentlist = list;
            }
        }

        private void UPDATEbtn_Click(object sender, EventArgs e)
        {
            UpdateRow();
        }

        private void ClearTextBoxes()///JpSeaman
        {
            IDtb.Text = string.Empty;
            NAMEtb.Text = string.Empty;
            AGEtb.Value = 0; // Assuming AGEtb is a NumericUpDown
            COURSEtb.Text = string.Empty;
        }
        private void UpdateRow() ///JpSeaman
        {
            // Ensure that a row is selected to make sure a cell is not just clicked by accident 
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string currentID = selectedRow.Cells["StudentID"].Value.ToString(); // Get current ID
                string newID = IDtb.Text; // New ID from the text box

                // Check for ID matches if changed
                if (newID != currentID && studentlist.Any(students => students.StudentID == newID))
                {
                    MessageBox.Show("The Student ID already exists. Please enter a unique ID.");
                    handler.ShowDuplicatePopup(newID);
                    return; // Exit if the ID already exists
                }

                // Update the cells in the DataGridView with the new values
                selectedRow.Cells["StudentID"].Value = newID;
                selectedRow.Cells["Name"].Value = NAMEtb.Text;
                selectedRow.Cells["Age"].Value = AGEtb.Text;
                selectedRow.Cells["Course"].Value = COURSEtb.Text;

                List<string> updatedList = new List<string>();
                foreach (Student student in studentlist)
                {
                    updatedList.Add($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
                }

                // Write the updated list to a file
                File.WriteAllLines(myreader.filePath, updatedList);
                ClearTextBoxes();
                MessageBox.Show("Sucessdully updated Student Information");
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //JpSeaman
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];  //Get the index of the clicked cell/row
            IDtb.Text = row.Cells["StudentID"].Value.ToString();
            NAMEtb.Text = row.Cells["Name"].Value.ToString();
            AGEtb.Text = row.Cells["Age"].Value.ToString();
            COURSEtb.Text = row.Cells["Course"].Value.ToString();
        }
    }
}
