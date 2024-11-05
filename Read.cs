using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Read
    {
        string filePath;

        public Read(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Student> read()
        {
            List<Student> students = new List<Student>();
            List<string> list = File.ReadAllLines(filePath).ToList();

            foreach (string item in list)
            {
                string[] items = item.Split(',');
                Student person = new Student(items[0], items[1], Convert.ToInt32(items[2]), items[3]);
                students.Add(person);
            }
            
            return students;
        }
    }
}
