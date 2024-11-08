using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    internal class DataHandler
    {
        // Fields
        private List<Student> students = new List<Student>();
        private static readonly string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string databasePath = Path.Combine(appDirectory, "SMSLogs.db");

        // Log List
        public List<(string Action, string StudentID, DateTime Timestamp)> logList = new List<(string, string, DateTime)>();

        // Constructors
        public DataHandler() { }
        public DataHandler(List<Student> students)
        {
            this.students = students;
        }

        // Properties
        public List<Student> Students { get => students; set => students = value; }

        // Methods

        /// <summary>
        /// Finds students whose ID contains a given string.
        /// </summary>
        public static List<Student> FindID(string ID, List<Student> students)
        {
            return students.Where(student => student.StudentID.Contains(ID)).ToList();
        }

        /// <summary>
        /// Gets a summary of the student list (count of students and average age).
        /// </summary>
        public static (int StudentCount, float AverageAge) GetSummary(List<Student> students)
        {
            int numberOfStudents = students.Count;
            float avgAge = students.Aggregate(0, (sum, student) => sum + student.Age) / (float)numberOfStudents;
            return (numberOfStudents, avgAge);
        }

        /// <summary>
        /// Validates input fields for creating or updating a student.
        /// </summary>
        public bool Validations(TextBox txtID, TextBox txtName, TextBox txtSurname, NumericUpDown txtAge, MaskedTextBox txtPhoneNumber, TextBox txtCource)
        {
            bool isValid = true;
            List<string> errorMessages = new List<string>();
            bool hasDuplicateID = false;

            // Validate ID
            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.BackColor = Color.Red;
                errorMessages.Add("ID cannot be empty.");
                isValid = false;
            }
            else
            {
                txtID.BackColor = Color.White;
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

            // Validate Phone Number
            if (string.IsNullOrEmpty(txtPhoneNumber.Text) || !txtPhoneNumber.MaskFull)
            {
                txtPhoneNumber.BackColor = Color.Red;
                errorMessages.Add("Phone number cannot be empty.");
                isValid = false;
            }
            else if (txtPhoneNumber.Text.Length != 14)
            {
                txtPhoneNumber.BackColor = Color.Red;
                errorMessages.Add("Phone number must be exactly 10 characters long.");
                isValid = false;
            }
            else
            {
                txtPhoneNumber.BackColor = Color.White;
            }

            // Check for duplicate IDs
            var duplicateStudent = students.FirstOrDefault(s => s.StudentID == txtID.Text);
            if (duplicateStudent != null)
            {
                txtID.BackColor = Color.Red;
                errorMessages.Add("Duplicate ID found. Please use a unique ID.");
                hasDuplicateID = true;
                isValid = false;
            }

            // Display all errors if any exist
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

        /// <summary>
        /// Displays a popup when duplicate student IDs are found.
        /// </summary>
        public void ShowDuplicatePopup(string duplicateID)
        {
            var duplicates = students.Where(s => s.StudentID == duplicateID).ToList();

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

        /// <summary>
        /// Deletes a selected student from a DataGridView and the student list.
        /// </summary>
        public void deleteStudent(DataGridView DGV, List<Student> studentList)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                var selectedRow = DGV.SelectedRows[0];
                var selectedStudent = (Student)selectedRow.DataBoundItem;

                studentList.RemoveAll(s => s.StudentID == selectedStudent.StudentID);
                DGV.DataSource = null;
                DGV.DataSource = studentList;
                MessageBox.Show("Student deleted successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        /// <summary>
        /// Logs an action with a student ID and timestamp.
        /// </summary>
        public void LogData(string action, string studentId)
        {
            try
            {
                if (!string.IsNullOrEmpty(action))
                {
                    logList.Add((action, studentId, DateTime.Now));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging data: {ex.Message}");
            }
        }

        /// <summary>
        /// Logs data to the database.
        /// </summary>
        public void LogToDataBase(List<(string Action, string StudentID, DateTime Timestamp)> logList)
        {
            try
            {
                if (File.Exists(databasePath))
                {
                    using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                    {
                        connection.Open();

                        foreach (var log in logList)
                        {
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

                                long logCount = (long)checkCommand.ExecuteScalar();

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

        /// <summary>
        /// Reads logs from the database and displays them.
        /// </summary>
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
