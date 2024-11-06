﻿using System;
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

            
        public void write(List<Student> studentlist)
        {
            try
            {
                if (studentlist != null)
                {
                    var lines = studentlist.Select(s => $"{s.StudentID},{s.Name},{s.Age},{s.Course}").ToArray();
                    File.WriteAllLines(this.filePath, lines);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied, check permissions.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Directory does not exists. Please check the file path.", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An I/O error occurred while writing the file. Details: {ex.Message}", "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }        
    }
}
