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
        public Form1()
        {
            InitializeComponent();
        }
        string filename = @"C:\Users\Cash\OneDrive - belgiumcampus.ac.za\Documents\Belgium\Year2\PRG282\Project\282Project\StudentManagementSystem\Content.txt";
        BindingSource bs = new BindingSource();
        List<Student> studentlist = new List<Student>();

        private void VIEWbtn_Click(object sender, EventArgs e)
        {
            Read myreader = new Read();
            DataHandler handler = new DataHandler();
            List<Student> list = new List<Student>();
            list = handler.format(myreader.read());
            studentlist = list;

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
            File.WriteAllLines(filename, list);
            bs.DataSource = " ";
            bs.DataSource = studentlist;
            dataGridView1.DataSource = bs;
        }
    }
}
