using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace StudentManagementSystem
{
    internal class DataHandler
    {
        List<Student> students = new List<Student>();

        public DataHandler() { }
        public DataHandler(List<Student> students)
        {
            this.students = students;
        }

        public List<Student> Students { get => students; set => students = value; }
            
        // Methods
        public static List<Student> FindID(string ID, List<Student> students)
        {
            List<Student> filterdStudents = students.Where((student) =>
            {
                return student.StudentID.Contains(ID);
            }).ToList();

            return filterdStudents;
        }

        public static (int StudentCount, float AverageAge) GetSummary(List<Student> students)
        {
            int numberOfStudents = students.Count;
            float avgAge = students.Aggregate(0, (sum, student) =>
            {
                return sum + student.Age;
            }) / (float)numberOfStudents;

            return (numberOfStudents, avgAge);
        }

        public bool Validations(TextBox txtID, TextBox txtName, NumericUpDown txtAge, TextBox txtCource)
        {
            bool isValid = true;
            List<string> errorMessages = new List<string>();
            bool hasDuplicateID = false; // Flag for duplicate ID check

            // Validate ID
            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.BackColor = Color.Red;
                errorMessages.Add("ID cannot be empty.");
                isValid = false;
            }
            else
            {
                txtID.BackColor = Color.White; // Reset if valid
            }

            // Validate Name
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.BackColor = Color.Red;
                errorMessages.Add("Name cannot be empty.");
                isValid = false;
            }
            else
            {
                txtName.BackColor = Color.White;
            }

            // Validate Age
            if (!int.TryParse(txtAge.Text, out int Age) || Age <= 0)
            {
                txtAge.BackColor = Color.Red;
                errorMessages.Add("Age must be a positive integer.");
                isValid = false;
            }
            else
            {
                txtAge.BackColor = Color.White;
            }

            // Validate Course
            if (string.IsNullOrEmpty(txtCource.Text))
            {
                txtCource.BackColor = Color.Red;
                errorMessages.Add("Course cannot be empty.");
                isValid = false;
            }
            else
            {
                txtCource.BackColor = Color.White;
            }

            // Check for duplicate IDs
            var duplicateStudent = students.FirstOrDefault(s => s.StudentID == txtID.Text);
            if (duplicateStudent != null)
            {
                txtID.BackColor = Color.Red;
                errorMessages.Add("Duplicate ID found. Please use a unique ID.");
                hasDuplicateID = true; // Set flag to indicate duplicate ID
                isValid = false;
            }

            // Display all errors in one message box if any exist
            if (errorMessages.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errorMessages), "Errors:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Show duplicate popup if duplicate ID found
            if (hasDuplicateID)
            {
                ShowDuplicatePopup(txtID.Text);
            }

            return isValid;
        }

        public void ShowDuplicatePopup(string duplicateID)
        {
            var duplicates = students.Where(s => s.StudentID == duplicateID).ToList();

            // Create a new form to show duplicates
            Form duplicateForm = new Form
            {
                Text = "Duplicate ID Found",
                Width = 300,
                Height = 200
            };

            ListBox listBox = new ListBox
            {
                Dock = DockStyle.Fill
            };

            foreach (var student in duplicates)
            {
                listBox.Items.Add($"ID: {student.StudentID}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }

            duplicateForm.Controls.Add(listBox);
            duplicateForm.ShowDialog();
        }

        public void deleteStudent(DataGridView DGV, List<Student> studentList)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                var selectedRow = DGV.SelectedRows[0];
                var selectedStudent = (Student)selectedRow.DataBoundItem;

                studentList.RemoveAll(s => s.StudentID == selectedStudent.StudentID);

                // Refresh DataGridView
                DGV.DataSource = null;
                DGV.DataSource = studentList;
                MessageBox.Show("Student deleted successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
    }
}
