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

internal class LectureTemplate
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Lecture3 Homework Task Selector");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Task 1: Cinema Hall");
            Console.WriteLine("2. Task 2: Fishing Trip");
            Console.WriteLine("3. Task 3: Salary Deduction");
            Console.WriteLine("4. Task 4: Steps to Reach a Goal");
            Console.WriteLine("5. Task 5: Birthday Cake");
            Console.WriteLine("6. Task 6: Password Generator");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option (1-7): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                case "6":
                    Task6();
                    break;
                case "7":
                    Console.WriteLine("\nThanks for reviewing!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the Lecture3 task selector menu...");
            Console.ReadKey(); // Pause before returning to the menu
        }
    }
    static void Task1()
    {
        Console.WriteLine();
        Console.WriteLine("Task 1: ");
        Console.WriteLine("-------------------");

    }

    static void Task2()
    {
        Console.WriteLine();
        Console.WriteLine("Task 2: ");
        Console.WriteLine("-------------------");

    }

    static void Task3()
    {
        Console.WriteLine();
        Console.WriteLine("Task 3: ");
        Console.WriteLine("-------------------");

    }
    static void Task4()
    {
        Console.WriteLine();
        Console.WriteLine("Task 4: ");
        Console.WriteLine("-------------------");

    }
    static void Task5()
    {
        Console.WriteLine();
        Console.WriteLine("Task 5: ");
        Console.WriteLine("-------------------");

    }
    static void Task6()
    {
        Console.WriteLine();
        Console.WriteLine("Task 6: ");
        Console.WriteLine("-------------------");

    }
    static void Task7()
    {
        Console.WriteLine();
        Console.WriteLine("Task 7: ");
        Console.WriteLine("-------------------");

    }
}

