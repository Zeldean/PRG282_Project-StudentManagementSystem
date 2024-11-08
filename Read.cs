using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentManagementSystem
{
    /// <summary>
    /// Class responsible for reading student data from a file.
    /// </summary>
    internal class Read
    {
        // Fields
        private readonly string filePath;

        // Constructor
        public Read(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Reads the student data from the file and returns a list of Student objects.
        /// </summary>
        /// <returns>List of students read from the file.</returns>
        public List<Student> read()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        int count = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] items = line.Split(',');
                            Student person = new Student(items[0], items[1], items[2], Convert.ToInt32(items[3]), items[4], items[5]);
                            students.Add(person);
                            count++;
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error while accessing file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return students;
        }
    }
}
