using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    /// <summary>
    /// Class responsible for writing student data to a file.
    /// </summary>
    internal class Write
    {
        // Fields
        private readonly string filePath;

        // Constructor
        public Write(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Writes the list of students to the file.
        /// </summary>
        /// <param name="studentlist">List of students to write to the file.</param>
        public void write(List<Student> studentlist)
        {
            try
            {
                // Ensure the student list is not null before proceeding
                if (studentlist != null)
                {
                    // Create an array of strings where each student's data is formatted as "ID,Name,Surname,Age,PhoneNumber,Course"
                    var lines = studentlist.Select(s => $"{s.StudentID},{s.Name},{s.Surname},{s.Age},{s.PhoneNumber},{s.Course}").ToArray();

                    // Write all lines to the specified file
                    File.WriteAllLines(this.filePath, lines);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Catch case where access is denied (e.g., no permission to write to the file)
                MessageBox.Show("Access denied, check permissions.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            {
                // Catch case where the directory doesn't exist
                MessageBox.Show("Directory does not exist. Please check the file path.", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                // Catch any I/O errors that occur during file writing
                MessageBox.Show($"An I/O error occurred while writing the file. Details: {ex.Message}", "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
