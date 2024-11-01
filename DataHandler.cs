using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class DataHandler
    {
        List<Student> students = new List<Student>();

        public List<Student> format(List<string> list)
        {
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
