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
        public string filePath = Path.Combine(".", "Content.txt");   //made a global Path to the Folder so it is accessable by handler.FilePath instead of having multiple 

        public Read()
        {
            // Check if the file exists; if not, create it
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose(); // Create the file and immediately dispose of the file stream
            }
        }

        public List<string> read()
        {
            // Read all lines from the file into a list
            List<string> list = File.ReadAllLines(filePath).ToList();
            return list;
        }
    }
}
