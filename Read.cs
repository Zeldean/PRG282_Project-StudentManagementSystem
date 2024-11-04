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
        
        public string filePath = Path.GetFullPath("Content.txt");
        public List<string> read()
        {
            List<string> list = new List<string>();
            list = File.ReadAllLines(filePath).ToList();
            return list;
        }

        public void write(List<Student> studentlist)
        {
            var lines = studentlist.Select(s => $"{s.StudentID},{s.Name},{s.Age},{s.Course}").ToArray();
            File.WriteAllLines(filePath, lines);
        }
    }
}
