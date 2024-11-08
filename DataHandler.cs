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
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace StudentManagementSystem
{
    internal class DataHandler
    {
        List<Student> students = new List<Student>();
        static string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string databasePath = Path.Combine(appDirectory, "SMSLogs.db");

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

        public bool Validations(TextBox txtID, TextBox txtName, TextBox txtSurname, NumericUpDown txtAge, MaskedTextBox txtPhoneNumber, TextBox txtCource)
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

            // Validate Name and capitalize first letter
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.BackColor = Color.Red;
                errorMessages.Add("Name cannot be empty.");
                isValid = false;
            }
            else
            {
                // Capitalize first letter of the name
                txtName.Text = char.ToUpper(txtName.Text[0]) + txtName.Text.Substring(1).ToLower();
                txtName.BackColor = Color.White;
            }

            // Validate Surname and capitalize first letter
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                txtSurname.BackColor = Color.Red;
                errorMessages.Add("Surname cannot be empty.");
                isValid = false;
            }
            else
            {
                // Capitalize first letter of the surname
                txtSurname.Text = char.ToUpper(txtSurname.Text[0]) + txtSurname.Text.Substring(1).ToLower();
                txtSurname.BackColor = Color.White;
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

            // Validate Phone Number (MaskedTextBox)
            if (string.IsNullOrEmpty(txtPhoneNumber.Text) || txtPhoneNumber.MaskFull == false)
            {
                txtPhoneNumber.BackColor = Color.Red;
                errorMessages.Add("Phone number cannot be empty.");
                isValid = false;
            }
            else
            {
                // Ensure phone number length is exactly correct (including format characters)
                string phoneNumber = txtPhoneNumber.Text;
                if (phoneNumber.Length != 14)
                {
                    txtPhoneNumber.BackColor = Color.Red;
                    errorMessages.Add("Phone number must be exactly 10 characters long.");
                    isValid = false;
                }
                else
                {
                    txtPhoneNumber.BackColor = Color.White;
                }
                
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

        public List<(string Action, string StudentID, DateTime Timestamp)> logList = new List<(string, string, DateTime)>();

        public void LogData(string action, string studentId)
        {

            try
            {
                if (!string.IsNullOrEmpty(action))
                {
                    // Add log entry with current timestamp
                    logList.Add((action, studentId, DateTime.Now));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging data: {ex.Message}");
            }
        }



        public void LogToDataBase(List<(string Action, string StudentID, DateTime Timestamp)> logList)
        {
            try
            {
                // Check if the database exists
                if (File.Exists(databasePath))
                {
                    using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                    {
                        connection.Open();

                        foreach (var log in logList)
                        {
                            // First check if this log entry already exists
                            string checkLogQuery = @"
                                                        SELECT COUNT(*) FROM Logs 
                                                        WHERE Action = @Action 
                                                        AND StudentID = @StudentID 
                                                        AND Timestamp = @Timestamp;";

                            using (SQLiteCommand checkCommand = new SQLiteCommand(checkLogQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@Action", log.Action);
                                checkCommand.Parameters.AddWithValue("@StudentID", log.StudentID);
                                checkCommand.Parameters.AddWithValue("@Timestamp", log.Timestamp);

                                // Execute the query to check for duplicates
                                long logCount = (long)checkCommand.ExecuteScalar();

                                // If no such log exists, insert the new log
                                if (logCount == 0)
                                {
                                    string insertLogQuery = @"
                                                                INSERT INTO Logs (Action, StudentID, Timestamp)
                                                                VALUES (@Action, @StudentID, @Timestamp);";

                                    using (SQLiteCommand command = new SQLiteCommand(insertLogQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Action", log.Action);
                                        command.Parameters.AddWithValue("@StudentID", log.StudentID);
                                        command.Parameters.AddWithValue("@Timestamp", log.Timestamp);

                                        command.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // Log entry already exists
                                    Console.WriteLine("Duplicate log entry found. Skipping insert.");
                                }
                            }
                        }

                        MessageBox.Show("Log data written to the database.");
                    }
                }
                else
                {
                    Console.WriteLine("Database not found at " + databasePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging data to the database: {ex.Message}");
            }
        }




        public void ReadLogsFromDatabase()
        {

            try
            { 
                if (File.Exists(databasePath))
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    connection.Open();
                    string selectQuery = "SELECT LogID, Action, StudentID, Timestamp FROM Logs;";
                    string allLogs = "LogID \t Action \t\t StudentID \t Timestamp\n";
                    allLogs += "-------------------------------------------------------------\n";

                    using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int logId = reader.GetInt32(0);
                                string action = reader.GetString(1);
                                string studentId = reader.GetString(2);
                                DateTime timestamp = reader.GetDateTime(3);

                                allLogs += $"|{logId} |\t {action} |\t {studentId} |\t {timestamp}|\n";
                            }
                        }
                    }

                    // Display all logs in a single MessageBox
                    MessageBox.Show(allLogs, "Logs from Database");
                }
            }
            else
            {
                MessageBox.Show("Database not found at " + databasePath);
            }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while reading logs from the database: {ex.Message}");
            }
        }
    }
}
