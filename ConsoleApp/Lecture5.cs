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

internal class Lecture5
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Lecture5 Homework Task Selector");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Task 1: Find the Largest Number in an Array");
            Console.WriteLine("2. Task 2: Reverse a String");
            Console.WriteLine("3. Task 3: Generate Fibonacci Sequence");
            Console.WriteLine("4. Task 4: Check for Prime Numbers");
            Console.WriteLine("5. Task 5: Sort an Array in Ascending Order");
            Console.WriteLine("6. Task 6: Swap Two Numbers");
            Console.WriteLine("7. Task 7: Update Array Elements");
            Console.WriteLine("8. Task 8: Divide Two Numbers");
            Console.WriteLine("9. Task 9: Parse String to Number");
            Console.WriteLine("10. Exit");
            Console.Write("Select an option (1-10): ");

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
                    Task7();
                    break;
                case "8":
                    Task8();
                    break;
                case "9":
                    Task9();
                    break;
                case "10":
                    Console.WriteLine("\nThanks for reviewing!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the Lecture5 task selector menu...");
            Console.ReadKey(); // Pause before returning to the menu
        }
    }
    static void Task1()
    {
        Console.WriteLine();
        Console.WriteLine("Task 1: Find the Largest Number in an Array");
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine("\nEnter an array of integers and return the largest number:");
        List<int> numbers = new List<int>();
        bool isValidInput = false;

        // Continue asking for valid input until it's provided
        while (!isValidInput)
        {
            Console.Write("\nEnter integers separated by spaces: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\nNo input provided. Please try again.");
                continue; // Retry
            }

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            numbers.Clear(); // Clear the list in case of re-entry

            isValidInput = true; // Assume input is valid until proven otherwise
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"\nInvalid input: type integers only. Please try again.");
                    isValidInput = false; // Invalid input detected
                    break; // Exit this iteration and retry
                }
            }
        }

        // Convert the list to an array
        int[] array = numbers.ToArray();

        // Print the array elements before the check
        Console.WriteLine("\nDebug: Print the array elements before the check:");
        foreach (int element in array)
        {
            Console.WriteLine(element);
        }

        // Completing the task with creating a method
        int largest = FindLargestNumber(array);
        Console.WriteLine($"The largest number is: {largest}");

    }

    public static int FindLargestNumber(int[] arr)
    {
        // Find the largest number
        int largest = arr[0];
        foreach (int num in arr)
        {
            if (num > largest)
            {
                largest = num;
            }
        }

        return largest;

    }



    static void Task2()
    {
        Console.WriteLine();
        Console.WriteLine("Task 2: Reverse a String");
        Console.WriteLine("------------------------");

        // Example usage
        Console.Write("\nEnter a string to reverse: ");
        string input = Console.ReadLine();

        string reversed = ReverseString(input);

        Console.WriteLine($"Reversed string is: {reversed}");

    }

    static string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input; // Return the same string if it's null or empty
        }

        char[] charArray = input.ToCharArray(); // Convert string to a character array
        Array.Reverse(charArray); // Reverse the array
        return new string(charArray); // Convert the reversed array back to a string
    }

    static void Task3()
    {
        Console.WriteLine();
        Console.WriteLine("Task 3: Generate Fibonacci Sequence");
        Console.WriteLine("-----------------------------------");

        Console.Write("\nEnter the number of Fibonacci numbers to generate: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                List<int> fibonacci = GenerateFibonacci(n);

                Console.Write("Fibonacci sequence: ");
                Console.WriteLine(string.Join(", ", fibonacci));
                break;
            }
            else
            {
                Console.Write("Please enter a valid positive integer: ");
                continue;
            }
        }
    }

    static List<int> GenerateFibonacci(int n)
    {
        List<int> fibonacci = new List<int>();

        if (n >= 1) fibonacci.Add(0); // First Fibonacci number
        if (n >= 2) fibonacci.Add(1); // Second Fibonacci number

        for (int i = 2; i < n; i++)
        {
            int nextNumber = fibonacci[i - 1] + fibonacci[i - 2];
            fibonacci.Add(nextNumber);
        }

        return fibonacci;
    }
    static void Task4()
    {
        Console.WriteLine();
        Console.WriteLine("Task 4: Check for Prime Numbers");
        Console.WriteLine("-------------------------------");

        Console.WriteLine("Prime number is a whole number greater than 1 that cannot be exactly divided by"+
            " any whole number other than itself!");
        Console.Write("\nEnter a number to check if it's prime: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine($"{number} is a prime number.");
                    break;
                }
                else
                {
                    Console.WriteLine($"{number} is not a prime number.");
                    break;
                }
            }
            else
            {
                Console.Write("Please enter a valid integer: ");
                continue;
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false; // Numbers <= 1 are not prime

        for (int i = 2; i <= Math.Sqrt(number); i++) // Only check up to the square root
        {
            if (number % i == 0)
                return false; // Divisible by i, so not prime
        }

        return true; // If no divisors are found, it's prime
    }
    static void Task5()
    {
        Console.WriteLine();
        Console.WriteLine("Task 5: Sort an Array in Ascending Order");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine("\nEnter an array of integers and return it in ascending order:");
        List<int> numbers = new List<int>();
        bool isValidInput = false;

        // Continue asking for valid input until it's provided
        while (!isValidInput)
        {
            Console.Write("\nEnter integers separated by spaces: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\nNo input provided. Please try again.");
                continue; // Retry
            }

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            numbers.Clear(); // Clear the list in case of re-entry

            isValidInput = true; // Assume input is valid until proven otherwise
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"\nInvalid input: type integers only. Please try again.");
                    isValidInput = false; // Invalid input detected
                    break; // Exit this iteration and retry
                }
            }
        }

        // Convert the list to an array
        int[] array = numbers.ToArray();

        // Print the array elements before the check
        Console.WriteLine("\nDebug: Print the array elements before the check:");
        foreach (int element in array)
        {
            Console.WriteLine(element);
        }

        // Sort the array
        SortArrayAscending(array);

        // Print the sorted array
        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(" ", array));

    }

    static void SortArrayAscending(int[] array)
    {
        int n = array.Length;

        // Bubble Sort algorithm
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1]) // Swap if elements are in the wrong order
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    static void Task6()
    {
        Console.WriteLine();
        Console.WriteLine("Task 6: Swap Two Numbers");
        Console.WriteLine("------------------------");

        Console.WriteLine("\nSwap two numbers using the 'ref' keyword.");

        Console.Write("\nEnter the first integer (a): ");
        int a = GetPositiveInteger();

        Console.Write("Enter the second integer (b): ");
        int b = GetPositiveInteger();


        Console.WriteLine($"\nBefore swapping: a = {a}, b = {b}");

        // Call the Swap method
        Swap(ref a, ref b);

        Console.WriteLine($"After swapping: a = {a}, b = {b}");

    }
    // Get positive integer
    static int GetPositiveInteger()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number > 0)
            {
                return number; // Valid positive integer
            }

            Console.Write("Invalid input. Please enter a positive integer: ");
        }
    }

    static void Swap(ref int x, ref int y)
    {
        // Swap the values
        int temp = x;
        x = y;
        y = temp;
    }

    static void Task7()
    {
        Console.WriteLine();
        Console.WriteLine("Task 7: Update Array Elements");
        Console.WriteLine("-----------------------------");
        int factor;

        // Define an array of integers
        Console.WriteLine("\nEnter an array of integers and return it in ascending order:");
        List<int> numbers = new List<int>();
        bool isValidInput = false;

        // Continue asking for valid input until it's provided
        while (!isValidInput)
        {
            Console.Write("\nEnter integers separated by spaces: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\nNo input provided. Please try again.");
                continue; // Retry
            }

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            numbers.Clear(); // Clear the list in case of re-entry

            isValidInput = true; // Assume input is valid until proven otherwise
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"\nInvalid input: type integers only. Please try again.");
                    isValidInput = false; // Invalid input detected
                    break; // Exit this iteration and retry
                }
            }
        }

        // Convert the list to an array
        int[] array = numbers.ToArray();

        // Print the array elements before the check
        Console.WriteLine("\nDebug: Print the array elements before the check:");
        foreach (int element in array)
        {
            Console.WriteLine(element);
        }

        // Ask the user to input the factor and parse to int
        Console.Write("Enter the factor to multiply the elements by: ");
        factor = int.Parse(Console.ReadLine());

        Console.WriteLine("\nOriginal Array:");
        PrintArray(array);

        // Call the MultiplyElements method to multiply all elements by the given factor
        MultiplyElements(ref array, factor);

        Console.WriteLine("\nArray After Multiplication:");
        PrintArray(array);
    }

    // Method to multiply all elements in the array by a given factor
    static void MultiplyElements(ref int[] array, int factor)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= factor;  // Multiply each element by the factor
        }
    }

    // Helper method to print the array elements
    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static void Task8()
    {
        Console.WriteLine();
        Console.WriteLine("Task 8: Divide Two Numbers");
        Console.WriteLine("--------------------------");

        Console.Write("\nEnter the dividend: ");
        int dividend = GetPositiveInteger();

        Console.Write("Enter the divisor: ");
        int divisor = GetPositiveInteger();

        // Call the method
        CalculateQuotientAndRemainder(dividend, divisor, out int quotient, out int remainder);

        // Display the results
        Console.WriteLine($"Quotient: {quotient}, Remainder: {remainder}");

    }

    static void CalculateQuotientAndRemainder(int dividend, int divisor, out int quotient, out int remainder)
    {
        // Calculate quotient and remainder
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }


    static void Task9()
    {
        Console.WriteLine();
        Console.WriteLine("Task 9: Parse String to Number");
        Console.WriteLine("------------------------------");

        Console.Write("\nEnter a number: ");
        string input = Console.ReadLine();

        int result = TryConvertToInt(input, out int number);

        if (result == 1)
        {
            Console.WriteLine($"Conversion successful: {number}");
        }
        else
        {
            Console.WriteLine("Conversion failed. Default value: 0");
        }
    }

    static int TryConvertToInt(string input, out int number)
    {
        if (int.TryParse(input, out number))
        {
            // Conversion successful
            return 1;
        }
        else
        {
            // Conversion failed, set default value
            number = 0;
            return 0;
        }
    }

}

