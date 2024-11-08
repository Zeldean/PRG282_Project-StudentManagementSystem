using System;

namespace StudentManagementSystem
{
    /// <summary>
    /// Class representing a student in the system.
    /// </summary>
    internal class Student
    {
        // Fields
        private string studentID;
        private string name;
        private string surname;
        private string phoneNumber;
        private int age;
        private string course;

        // Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Student() { }

        /// <summary>
        /// Parameterized constructor to initialize a student with specific details.
        /// </summary>
        /// <param name="studentID">The ID of the student.</param>
        /// <param name="name">The name of the student.</param>
        /// <param name="surname">The surname of the student.</param>
        /// <param name="age">The age of the student.</param>
        /// <param name="phoneNumber">The phone number of the student.</param>
        /// <param name="course">The course in which the student is enrolled.</param>
        public Student(string studentID, string name, string surname, int age, string phoneNumber, string course)
        {
            this.StudentID = studentID;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
            this.Course = course;
        }

        // Properties
        /// <summary>
        /// Gets or sets the student ID.
        /// </summary>
        public string StudentID { get => studentID; set => studentID = value; }

        /// <summary>
        /// Gets or sets the student's name.
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the student's surname.
        /// </summary>
        public string Surname { get => surname; set => surname = value; }

        /// <summary>
        /// Gets or sets the student's age.
        /// </summary>
        public int Age { get => age; set => age = value; }

        /// <summary>
        /// Gets or sets the course the student is enrolled in.
        /// </summary>
        public string Course { get => course; set => course = value; }

        /// <summary>
        /// Gets or sets the student's phone number.
        /// </summary>
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
