# Student Management System

## Members

- Herman Bantjes 601427
- Stiaan Megit 600819

This project is a C# Windows Forms application that serves as a Version-Controlled Student Management System. The system provides functionality for managing student records, and integrates Git version control and GitHub for collaboration and source tracking. The application allows users to perform CRUD operations (Create, Read, Update, Delete) and generate summary reports, all while maintaining proper version control.

## Features

- **Add New Student**: The application provides a form interface to input student details such as Student ID, Name, Age, and Course. These details are saved to a text file named `students.txt`.

- **View All Students**: The records from `students.txt` are displayed in a DataGridView control, offering a quick view of all students.

- **Update Student Information**: Users can search for students by their ID and edit their details, which are saved back to `students.txt`.

- **Delete a Student**: Users can delete a student by selecting them from the DataGridView, removing the corresponding entry from the text file.

- **Generate Summary Report**: The application calculates the total number of students and the average age, displaying these results on the form and saving them to `summary.txt`.

- **Version Control with Git**: The entire development process uses Git for version control, with regular commits made after each feature implementation. The project is also pushed to a GitHub repository for remote backup and collaboration.

## Technologies Used

- **Programming Language**: C#
- **Framework**: .NET (Windows Forms)
- **Version Control**: Git, GitHub

## Milestones

- [x] Create a Windows Forms project and initialize a Git repository.
- [ ] Implement "Add New Student" functionality and save to `students.txt`.
- [ ] Develop "View All Students" to read from `students.txt` and display in DataGridView.
- [ ] Enable editing and updating of student information.
- [ ] Implement student deletion from the DataGridView.
- [ ] Add functionality to generate a summary report and save to `summary.txt`.
- [ ] Stage and commit each feature addition and push to GitHub.
- [ ] Handle file errors and add meaningful error messages.
- [ ] Finalize the UI, including error messages and validation.
- [ ] Prepare the GitHub repository with a README, and push all commits.

## Getting Started

1. **Clone the Repository**: Clone the GitHub repository to your local machine to get started.
2. **Install Dependencies**: Ensure you have Visual Studio and the .NET framework installed.
3. **Run the Project**: Open the solution in Visual Studio and start debugging to launch the application.

## Version Control Process

- Initialize a Git repository at the start of the project.
- Make frequent commits after each major feature, ensuring detailed commit messages.
- Push all changes to the GitHub repository, ensuring team members have access to the latest codebase.

Feel free to use this as a starting point and adapt as needed. Are there any milestones you’d like to add or adjust?

