using System;
using System.Collections.Generic;
using System.Globalization; // For TextInfo
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Lecture2
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Lecture2 Homework Task Selector");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Task 1: Convert and Add Two Numbers");
            Console.WriteLine("2. Task 2: Format a Full Name");
            Console.WriteLine("3. Task 3: Extract and Modify Substring");
            Console.WriteLine("4. Task 4: Calculate the Area of a Circle");
            Console.WriteLine("5. Task 5: Validate Age Input");
            Console.WriteLine("6. Exit to the main menu");
            Console.Write("Select an option (1-6): ");

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
                    Console.WriteLine("\nThanks for reviewing!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the Lecture2 task selector menu...");
            Console.ReadKey(true); // Pause before returning to the menu
        }
    }

    static void Task1()
    {
        Console.WriteLine();
        Console.WriteLine("Task 1: Convert and Add Two Numbers");
        Console.WriteLine("-----------------------------------");
        int number1, number2;
        while (true) // Loop until valid input is provided
        {
            Console.Write("Enter a number: ");
            string inputnumber1 = Console.ReadLine();
            if (int.TryParse(inputnumber1, out number1))
            {
                Console.WriteLine($"You entered the number: {number1}");
                break; // Exit the loop if conversion is successful
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

        }

        while (true) // Loop until second valid input is provided
        {
            Console.Write("Enter a second number: ");
            string inputnumber2 = Console.ReadLine();
            if (int.TryParse(inputnumber2, out number2))
            {
                Console.WriteLine($"You entered the number: {number2}");
                break; // Exit the loop if conversion is successful
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        Console.WriteLine($"Sum of the numbers is, {number1 + number2}!");
    }

    static void Task2()
    {
        Console.WriteLine();
        Console.WriteLine("Task 2: Format a Full Name");
        Console.WriteLine("--------------------------");

        // Prompt for first name
        Console.Write("Enter your first name: ");
        string fname = Console.ReadLine();

        // Prompt for last name
        Console.Write("Enter your last name: ");
        string lname = Console.ReadLine();

        // Capitalize the first letter of each name using ToTitleCase
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        fname = textInfo.ToTitleCase(fname.ToLower());
        lname = textInfo.ToTitleCase(lname.ToLower());

        // Combine and display in the format "Last Name, First Name"
        Console.WriteLine($"Thanks {lname}, {fname}.");
    }

    static void Task3()
    {
        Console.WriteLine();
        Console.WriteLine("Task 3: Extract and Modify Substring");
        Console.WriteLine("------------------------------------");

        string netZero = "Working on problems such as net zero emissions in aviation will require" +
            " unique perspectives and imaginative solutions!";
        Console.Write($"The string used is: {netZero}");

        Console.WriteLine("\nPress any key to complete the task...");
        Console.ReadKey(); // Pause before continue

        // Extract a substring (e.g., the first 5 characters)
        string substring = netZero.Substring(32, 14); // "hello"

        // Convert the substring to uppercase
        string uppercaseSubstring = substring.ToUpper(); // "HELLO"

        // Display results
        Console.WriteLine($"\nUppercase Substring: {uppercaseSubstring}");
    }

    static void Task4()
    {
        Console.WriteLine();
        Console.WriteLine("Task 4: Calculate the Area of a Circle");
        Console.WriteLine("--------------------------------------");

        // Prompt user to input the radius as a string
        Console.Write("Enter the radius of the circle: ");
        string radiusInput = Console.ReadLine();

        try
        {
            // Convert the input string to a double using double.Parse()
            double radius = double.Parse(radiusInput);

            // Calculate the area of the circle (Area = π * r^2)
            double area = Math.PI * radius * radius;

            // Display the result
            Console.WriteLine($"The area of the circle with radius {radius} is {area:F2}.");
        }
        catch (FormatException)
        {
            // Handle the case where the input is not a valid double
            Console.WriteLine("Invalid input. Please enter a valid number for the radius.");
        }
        catch (OverflowException)
        {
            // Handle the case where the number is too large or too small
            Console.WriteLine("The radius value is too large or too small.");
        }
    }
    static void Task5()
    {
        Console.WriteLine();
        Console.WriteLine("Task 5: Validate Age Input");
        Console.WriteLine("--------------------------");

        // Prompt the user to enter their age
        Console.Write("Enter your age: ");
        string userInput = Console.ReadLine();

        // Use TryParse to check if the input is a valid integer
        if (int.TryParse(userInput, out int age))
        {
            // Check conditions based on the age
            if (age < 0)
            {
                Console.WriteLine("Age cannot be negative. Please enter a valid age.");
            }
            else if (age <= 120)
            {
                Console.WriteLine($"Your age is {age}. That seems possible.");
            }
            else
            {
                Console.WriteLine($"Your age is {age}. That doesn't seem likely.");
            }
        }
        else
        {
            // If TryParse fails, display an error message
            Console.WriteLine("Please enter your age as integer.");
        }
    }
}
