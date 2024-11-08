using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Data.SqlClient;

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
        // Method to find students whose ID contains a given string
        public static List<Student> FindID(string ID, List<Student> students)
        {
            // Use LINQ to filter the list of students based on the provided ID
            List<Student> filterdStudents = students.Where((student) => 
            {
                return student.StudentID.Contains(ID);  // Check if the student's ID contains the provided ID substring
            }).ToList();

            return filterdStudents;
        }

        public static (int StudentCount, float AverageAge) GetSummary(List<Student> students) // Method to get a summary of the student list (count of students and average age)
        {
            int numberOfStudents = students.Count;  // Get the total number of students
            float avgAge = students.Aggregate(0, (sum, student) =>  // Use Aggregate to sum up the ages of all students, and then calculate the average age
            {
                return sum + student.Age; // Add each student's age to the cumulative sum
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
        // Method to display a popup when duplicate student IDs are found
        public void ShowDuplicatePopup(string duplicateID)
        {
            // Find students with the matching duplicate ID using LINQ
            var duplicates = students.Where(s => s.StudentID == duplicateID).ToList();

            // Create a new form to show duplicates
            Form duplicateForm = new Form
            {
                Text = "Duplicate ID Found",
                Width = 300,
                Height = 200
            };

            ListBox listBox = new ListBox // Create a ListBox to display the list of duplicate students
            {
                Dock = DockStyle.Fill // The ListBox will fill the entire form
            };

            foreach (var student in duplicates) // Add each duplicate student to the ListBox
            {
                listBox.Items.Add($"ID: {student.StudentID}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }

            duplicateForm.Controls.Add(listBox);
            duplicateForm.ShowDialog(); // Show the form as a dialog box (popup)
        }

        // Method to delete a selected student from a DataGridView and the student list
        public void deleteStudent(DataGridView DGV, List<Student> studentList)
        {
            if (DGV.SelectedRows.Count > 0) // Check if any row is selected in the DataGridView
            {
                var selectedRow = DGV.SelectedRows[0];
                var selectedStudent = (Student)selectedRow.DataBoundItem;   // Cast the selected row's data to a Student object

                studentList.RemoveAll(s => s.StudentID == selectedStudent.StudentID);  // Remove the student from the list based on their StudentID

                // Refresh DataGridView
                DGV.DataSource = null; // Clear the current data source
                DGV.DataSource = studentList; // Reassign the updated student list as the data source
                MessageBox.Show("Student deleted successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
        // Method to log an action (such as deletion) and return the log as a list of strings
        public List<string> LogData (string action)
        {
            List<string> LogList = new List<string>();
            if (!string.IsNullOrEmpty(action)) // If the action string is not empty or null, add it to the log list
            {
                LogList.Add(action);
            }
            return LogList;
        }
        // Method to log data to a database (currently not implemented)
        public void LogToDataBase(List<string> list)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory; // Get the application's base directory path
            string databasePath = Path.Combine(appDirectory, "MyDatabase.mdf"); // Define the path to the database file within the application directory

            if (Directory.Exists(databasePath))
            {
                //using (SqlDataAdapter adapter = new SqlDataAdapter()) ;
            }
        }
        


    }
}
