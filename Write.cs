using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudentManagementSystem
{
    internal class Write
    {
        public string filePath = Path.Combine(".", "Content.txt");
        public void write(List<Student> studentlist)
        {
            var lines = studentlist.Select(s => $"{s.StudentID},{s.Name},{s.Age},{s.Course}").ToArray();
             File.WriteAllLines(filePath, lines);
        }
        
        
    }
}
