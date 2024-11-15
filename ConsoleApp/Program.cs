using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Homework Task Selector");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Task 1: Convert and Add Two Numbers");
            Console.WriteLine("2. Task 2: Format a Full Name");
            Console.WriteLine("3. Task 3: Extract and Modify Substring");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1-4): ");

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
                    Console.WriteLine("Goodbye!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(); // Pause before returning to the menu
        }
    }

    static void Task1()
    {

        Console.WriteLine("Task 1: Convert and Add Two Numbers");
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
        Console.WriteLine("Task 2: Format a Full Name");
        Console.Write("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());
        int sum = num1 + num2;
        Console.WriteLine($"The sum of {num1} and {num2} is {sum}.");
    }

    static void Task3()
    {
        Console.WriteLine("Task 3: Extract and Modify Substring");
        Console.Write("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());
        int result = num1 % num2;
        Console.WriteLine($"{num1} % {num2} = {result}");
    }
}


