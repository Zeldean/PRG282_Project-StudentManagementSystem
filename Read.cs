using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Read // Class to handle reading student data from a file
    {
        string filePath;

        public Read(string filePath) // Constructor to initialize the file path
        {
            this.filePath = filePath; // Assign the provided file path to the class variable
        }

        public List<Student> read()  // Method to read the file and return a list of Student objects
        {
            List<Student> students = new List<Student>();
            List<string> list = File.ReadAllLines(filePath).ToList(); // Read all lines from the file and store them as a list of strings

            try
            { 
                foreach (string item in list)
               {
                string[] items = item.Split(','); // Split the line by commas to separate the student properties
                    Student person = new Student(items[0], items[1], Convert.ToInt32(items[2]), items[3]);  // Create a new Student object using the split data (name, surname, age, grade)
                    students.Add(person);
               }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                // Handle I/O errors, like read/write permission issues
                Console.WriteLine($"I/O error while accessing file: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Any error I don't know of. (you're screwd)
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }


            return students;
        }
    }
}
