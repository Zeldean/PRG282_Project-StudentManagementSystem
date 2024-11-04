using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        public string path = Path.GetFullPath("Content.txt");
        Read myreader = new Read();
        DataHandler handler = new DataHandler();
        BindingSource bs = new BindingSource();
        List<Student> studentlist = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void VIEWbtn_Click(object sender, EventArgs e)
        {
            SEARCHtb.Clear();

            bs.DataSource = studentlist;
            dataGridView1.DataSource = bs;
        }

        private void ADDbtn_Click(object sender, EventArgs e)
        {
            studentlist.Add(new Student(IDtb.Text, NAMEtb.Text, Convert.ToInt32(AGEtb.Text), COURSEtb.Text));
            List<string> list = new List<string>();
            foreach (Student student in studentlist)
            {
                list.Add($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
            }
            File.WriteAllLines(path, list);
            bs.DataSource = " ";
            bs.DataSource = studentlist;
            dataGridView1.DataSource = bs;
        }

        private void SEARCHtb_TextChanged(object sender, EventArgs e)
        {
            List<Student> filterdStudentList = DataHandler.FindID(SEARCHtb.Text, studentlist);
            bs.DataSource = filterdStudentList;

            dataGridView1.DataSource = bs;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Boolean notexist = !File.Exists(path);

            if (notexist)
            {
                File.CreateText(path);
            }
            if (new FileInfo(path).Length == 0)
            {

            }
            else
            {
                List<Student> list = new List<Student>();
                list = handler.format(myreader.read());
                studentlist = list;
            }
        }

        private void SUMMARYbtn_Click(object sender, EventArgs e)
        {
            //studentlist.Count
        }
    }
}
