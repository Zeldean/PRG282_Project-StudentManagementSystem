using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Student
    {
        string studentID, name, surname , phonmeNumber;
        int age;
        string course;

        public Student()
        {

        }
        public Student(string studentID, string name, string surname, int age, string phoneNumber, string course)
        {
            this.StudentID = studentID;
            this.Name = name;
            this.Age = age;
            this.Course = course;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
        }

        public string StudentID { get => studentID; set => studentID = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public string Course { get => course; set => course = value; }
        public string PhoneNumber { get => phonmeNumber; set => phonmeNumber = value; }
    }
}
