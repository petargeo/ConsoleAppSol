using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization; // For TextInfo should be removed
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

internal class Lecture6
{
    static string[] _schoolSubjects = { "Math", "Biology", "History", "English", "Sport", "Physics" };

    public static void Run()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Lecture6 Student Data Management System");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Start SDMS");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option (1-2): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Console.WriteLine("\nThanks for reviewing!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the Lecture6 selector menu...");
            Console.ReadKey(); // Pause before returning to the menu
        }
    }

    public static void Task1()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Student Data Management System!");
        Console.WriteLine("----------------------------------------------");

        //Console.WriteLine("Welcome to the Student Data Management System!");
        Dictionary<string, Dictionary<string, List<double>>> students = new Dictionary<string, Dictionary<string, List<double>>>();

        //string studentName = null;

        while (true)
        {
            Console.Write("\nChoose an option:\r\n1. Add a new student\r\n2. Remove a student\r\n3. Assign student to subject\r\n4. Update a student's grades\r\n5. Display all students\r\n6. Exit\r\n\r\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent(students);
                    break;
                case "2":
                    RemoveStudent(students);
                    break;
                case "3":
                    AssignToSubject(students);
                    break;
                case "4":
                    UpdateStudentsGrades(students);
                    break;
                case "5":
                    DisplayAllStudents(students);
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;

            }
        }

    }


    public static void AddStudent(Dictionary<string, Dictionary<string, List<double>>> students)
    {
        Console.Write("\nEnter student name: ");
        string studentName = Console.ReadLine();

        string message = students.TryAdd(studentName, new Dictionary<string, List<double>>())
            ? $"Student {studentName} added successfully!"
           : $"Student {studentName} already exists!";

        Console.WriteLine(message);
    }

    public static void RemoveStudent(Dictionary<string, Dictionary<string, List<double>>> students)
    {

        Console.Write("\nEnter student name to remove: ");
        string studentName = Console.ReadLine();

        string message = students.Remove(studentName)
            ? $"Student {studentName} is successfully removed!"
            : $"Student {studentName} is not removed!";

        Console.WriteLine(message);

    }

    public static void AssignToSubject(Dictionary<string, Dictionary<string, List<double>>> students)
    {

        Console.Write("\nEnter a student and a subject, for example John Doe-Math: ");
        string subjectNameinput = Console.ReadLine();

        string[] items = subjectNameinput.Split("-");
        string studentName = items[0].Trim();
        string subject = items[1].Trim();

        if (!students.ContainsKey(studentName))
        {
            Console.WriteLine($"The student is not present in the system.");
            return;
        }

        if (!_schoolSubjects.Contains(subject))
        {
            Console.WriteLine("The subject is not present in the list.");
            return;
        }

        string message = students[studentName].TryAdd(subject, new List<double>())
        ? $"Student {studentName} has successfully enrolled in the {subject} class!"
            : $"Student is already enrolled!";
        Console.WriteLine(message);

    }

    public static void UpdateStudentsGrades(Dictionary<string, Dictionary<string, List<double>>> students)
    {

        Console.Write($"\nEnter a student name: ");
        string studentName = Console.ReadLine();

        if (!students.ContainsKey(studentName))
        {
            Console.WriteLine($"The student is not present in the system.");
            return;
        }

        Console.Write($"Enter a subject-grade: ");
        string subjectAndGrade = Console.ReadLine();

        string[] items = subjectAndGrade.Split("-");
        string subject = items[0];
        if (!double.TryParse(items[1], out double grade))
        {
            Console.WriteLine($"Invalid grade input.");
            return;
        }

        if (grade < 2 || grade > 6)
        {
            Console.WriteLine("Wrong range of the grade.");
            return;
        }

        if (!_schoolSubjects.Contains(subject))
        {
            Console.WriteLine("The subject is not present in the list.");
            return;
        }


        students[studentName][subject].Add(grade);
        Console.WriteLine("The grade is added.");

    }
    public static void DisplayAllStudents(Dictionary<string, Dictionary<string, List<double>>> students)
    {
        Console.Write("\nDisplaying all students: \n");
        // Iterate through the outer dictionary
        foreach (var studentEntry in students)
        {
            string studentName = studentEntry.Key;
            Console.WriteLine($"Student: {studentName}");

            // Iterate through the inner dictionary
            foreach (var subjectEntry in studentEntry.Value)
            {
                string subjectName = subjectEntry.Key;
                List<double> grades = subjectEntry.Value;

                // Display the subject and grades
                Console.WriteLine($"  Subject: {subjectName}");
                Console.WriteLine($"  Grades: {string.Join(", ", grades)}");
                // Calculate and display the average using .Average()
                if (grades.Count > 0)
                {
                    double average = grades.Average(); // LINQ method
                    Console.WriteLine($"  The average grade is: {average:F2}");
                }
                else
                {
                    Console.WriteLine("  No grades were entered.");
                }
            }
        }
    }

}
