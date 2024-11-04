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
        
        public string path = Path.GetFullPath("Content.txt");
        public List<string> read()
        {
            List<string> list = new List<string>();
            list = File.ReadAllLines(path).ToList();
            return list;
        }
    }
}
