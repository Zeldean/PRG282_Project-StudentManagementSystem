# 🎓 Student Management System

## 👥 Members

- 👤 Herman Bantjes 601427
- 👤 Stiaan Megit 600819
- 👤 Dean van Zyl 600367
- 👤 Jan-Paul Seaman 578081

This project is a C# Windows Forms application that serves as a 🎓 Student Management System. The system provides functionality for managing student records and supporting collaboration through Git and GitHub for version control and source tracking. The application allows users to perform CRUD (✏️➕🔍✂️) operations and generate 📊 summary reports.

## ✨ Features

- **➕ Add New Student**: The application provides a form interface to input student details such as 🆔 Student ID, 📝 Name, 🧬 Surname, 🎂 Age, 📞 Phone Number, and 📚 Course. These details are saved to a text file named `students.txt`.

- **👀 View All Students**: The records from `students.txt` are displayed in a 📊 DataGridView control, offering a quick view of all students.

- **✏️ Update Student Information**: Users can select students by clicking on their entry in the DataGridView and edit their details, which are saved back to `students.txt`.

- **❌ Delete a Student**: Users can delete a student by selecting them from the DataGridView, removing the corresponding entry from the text file.

- **📊 Generate Summary Report**: The application calculates the total number of students and the average age, displaying these results on the form and saving them to `summary.txt`.

- **📝 Log Changes**: Each action performed on student records (➕, ✏️, ❌) is logged with details and timestamps, ensuring traceability.

- **⚠️ Error Handling and ✅ Validations**: Proper error messages are displayed in case of issues such as invalid input or file access problems. Validation is performed for required fields like 🆔 Student ID, 📝 Name, and 🎂 Age to ensure data integrity.

- **🔄 Version Control Integration**: The development process is tracked using Git, with regular commits after each feature implementation. The project has also been pushed to a GitHub repository for remote backup and collaboration.

## 🛠️ Technologies Used

- **💻 Programming Language**: C#
- **🔧 Framework**: .NET (Windows Forms)
- **🗄️ Database**: SQLite for storing logs of actions performed on the student records.
- **🔄 Version Control**: Git, GitHub

## 🎯 Milestones

- [x] 🏗️ Create the initial Windows Forms project structure.
- [x] 📝 Implement form interface for adding new student records.
- [x] 💾 Save student data to `students.txt` after adding new records.
- [x] 👀 Develop functionality to view all student records in a DataGridView.
- [x] ✏️ Enable updating and saving modifications to existing student records.
- [x] ❌ Add the capability to delete student records from the system.
- [x] 📊 Implement summary report generation with total students and average age.
- [x] 📝 Introduce logging of all actions (➕, ✏️, ❌) to an SQLite database.
- [x] ⚠️ Handle common errors (e.g., file access, validation errors) and display user-friendly messages.
- [x] ✅ Integrate input validation to ensure data integrity before saving.
- [x] 🔄 Refactor the code to improve readability and maintainability.
- [x] 🧪 Conduct testing to verify all features work as expected.
- [x] 🎨 Finalize UI design, including error messages and consistent styling.
- [x] ⚡ Optimize file handling for better performance, especially with larger datasets.
- [x] 📄 Prepare project documentation and README for GitHub.

## 🚀 Getting Started

1. **🔗 Clone the Repository**: Clone the GitHub repository to your local machine to get started.
2. **⚙️ Install Dependencies**: Ensure you have Visual Studio and the .NET framework installed.
3. **▶️ Run the Project**: Open the solution in Visual Studio and start debugging to launch the application.

