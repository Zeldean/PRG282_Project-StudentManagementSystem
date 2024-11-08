using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StudentManagementSystem
{
    internal class Write
    {
        string filePath;

        public Write(string filePath)
        {
            this.filePath = filePath;
        }    
        public void write(List<Student> studentlist) // Method to write a list of students to a file
        {
            try
            {
                if (studentlist != null)  // Ensure the student list is not null before proceeding
                {
                    var lines = studentlist.Select(s => $"{s.StudentID},{s.Name},{s.Age},{s.Course}").ToArray();  // Create an array of strings where each student's data is formatted as "ID,Name,Age,Course"
                    File.WriteAllLines(this.filePath, lines);  // Write all lines to the specified file
                }
            }
            catch (UnauthorizedAccessException)
            { // Catch case where access is denied (e.g., no permission to write to the file)
                MessageBox.Show("Access denied, check permissions.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            { // Catch case where the directory doesn't exist
                MessageBox.Show("Directory does not exists. Please check the file path.", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            { // Catch any I/O errors that occur during file writing
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
