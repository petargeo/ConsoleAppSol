using System;
// using System.Globalization; // For TextInfo

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Homework Lecture Selector");
            Console.WriteLine("-------------------------");
            Console.WriteLine("|01| Lecture 1: Introduction to Automation Testing");
            Console.WriteLine("|02| Lecture 2: Primitive Data Types and Variables");
            Console.WriteLine("|03| Lecture 3: Operators, Conditional Statements, and Loops");
            Console.WriteLine("|04| Lecture 4: Data Structures and Collections");
            Console.WriteLine("|05| Lecture 5: Methods in C#: Fundamentals and Best Practices");
            Console.WriteLine("|06| Lecture 6: Applying Basic C# Knowledge");
            Console.WriteLine("|07| Lecture 7: Classes and Exceptions in C# - TBD");
            Console.WriteLine("|08| Lecture 8: Introduction to OOP: Inheritance and Polymorphism - TBD");
            Console.WriteLine("|09| Lecture 9: OOP: Abstraction, Encapsulation, Interfaces, and Abstract Classe - TBD");
            Console.WriteLine("|10| Exit the program");
            Console.Write("Select an option (1-10): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Lecture 1 has no homework");
                    break;
                case "2":
                    Lecture2.Run();
                    break;
                case "3":
                    Lecture3.Run();
                    break;
                case "4":
                    Lecture4.Run();
                    break;
                case "5":
                    Lecture5.Run();
                    break;
                case "6":
                    Lecture6.Run();
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case "9":
                    break;
                case "10":
                    Console.WriteLine("\nGoodbye!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the Lecture Selector menu...");
            Console.ReadKey(); // Pause before returning to the menu
        }
    }
}


