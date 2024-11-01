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
        public string filename = @"C:\Users\Cash\OneDrive - belgiumcampus.ac.za\Documents\Belgium\Year2\PRG282\Project\282Project\StudentManagementSystem\Content.txt";

        public List<string> read()
        {
            List<string> list = new List<string>();
            list = File.ReadAllLines(filename).ToList();
            return list;
        }
    }
}
