using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization; // For TextInfo should be removed
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

internal class Lecture4
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Lecture4 Homework Task Selector");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Task 1: Common Elements");
            Console.WriteLine("2. Task 2: Max Sequence of Equal Elements");
            Console.WriteLine("3. Task 3: Train");
            Console.WriteLine("4. Task 4: Cards Game");
            Console.WriteLine("5. Task 5: Count Chars in a String");
            Console.WriteLine("6. Task 6: A Miner Task");
            Console.WriteLine("7. Task 7: Basic Stack Operations");
            Console.WriteLine("8. Task 8: Basic Queue Operations");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option (1-9): ");

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
                    Console.WriteLine("\nThanks for reviewing!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the Lecture4 task selector menu...");
            Console.ReadKey(); // Pause before returning to the menu
        }
    }
    static void Task1()
    {
        Console.WriteLine();
        Console.WriteLine("Task 1: Common Elements");
        Console.WriteLine("-----------------------");

        // Input: Two arrays
        Console.Write("\nEnter elements of the first array separated by spaces: ");
        string[] firstArray = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Console.Write("\nEnter elements of the second array separated by spaces: ");
        string[] secondArray = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Find common elements
        Console.WriteLine("\nCommon elements:");
        foreach (var element in secondArray)
        {
            if (Array.Exists(firstArray, e => e == element))
            {

                Console.Write($"{element} ");
            }
        }

        Console.WriteLine(); // For a clean output

        // Second option is to Create a list to hold common elements - uncomment following
        //List<string> commonElements = new List<string>();

        //// Find common elements
        //foreach (var element in secondArray)
        //{
        //    if (Array.Exists(firstArray, e => e == element) && !commonElements.Contains(element))
        //    {
        //        commonElements.Add(element);
        //    }
        //}

        //// Convert the list to an array
        //string[] commonArray = commonElements.ToArray();

        //// Print the common elements
        //Console.WriteLine("Common elements:");
        //Console.WriteLine(string.Join(" ", commonArray));

    }

    static void Task2()
    {
        Console.WriteLine();
        Console.WriteLine("Task 2: Max Sequence of Equal Elements");
        Console.WriteLine("--------------------------------------");

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

        // Variables to track the longest sequence
        int maxLength = 1;
        int currentLength = 1;
        int longestStartIndex = 0;

        // Iterate through the array to find the longest sequence
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                currentLength++;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    longestStartIndex = i - maxLength + 1;
                }
            }
            else
            {
                currentLength = 1; // Reset current length for a new sequence
            }
        }

        // Extract the longest sequence
        int[] longestSequence = numbers.Skip(longestStartIndex).Take(maxLength).ToArray();

        // Output the longest sequence
        Console.WriteLine("\nLongest sequence of equal elements:");
        Console.WriteLine(string.Join(" ", longestSequence));
    }

    static void Task3()
    {
        Console.WriteLine();
        Console.WriteLine("Task 3: Train");
        Console.WriteLine("-------------");

        // Write instructions
        Console.WriteLine("\nEnter integers representing the number " +
            "of passengers that are currently in each wagon.");

        List<int> wagons = new List<int>();
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
            wagons.Clear(); // Clear the list in case of re-entry

            isValidInput = true; // Assume input is valid until proven otherwise
            int totalWagons = 0;
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number) && number >= 0)
                {
                    totalWagons++;
                    wagons.Add(number);
                }
                else
                {
                    Console.WriteLine($"\nInvalid input: type 0 or positive integers only. Please try again.");
                    isValidInput = false; // Invalid input detected
                    break; // Exit this iteration and retry
                }
            }
            Console.WriteLine($"There are {totalWagons} waggons in the train.");
        }
        Console.WriteLine($"\nDebug: print the content of the created list:");
        Console.WriteLine(string.Join(" ", wagons));

        // Check if MaxPassengers is equal or more than the wagon with most current passangers???
        // Find the maximum number of passengers in any of the wagons
        int mostPassengers = wagons.Max();

        // Print the maximum number
        Console.WriteLine($"\nDebug: print the maximum number in the list:");
        Console.WriteLine($"The most passengers in any of the waggons is: {mostPassengers}");

        // Read the max number of passengers in each wagon and validate
        Console.WriteLine("\nNext, enter the max number of passengers allowed in each wagon");
        int maxPassengers = MaxPassengers("\nEnter the number of the most paassengers allowed: ", mostPassengers);

        // 
        while (true)
        {
            Console.Clear(); // Clear the console for a clean menu display
            Console.WriteLine("Options to modify the train:");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Add a wagon with passengers to the end of the composition.");
            Console.WriteLine("2. Add passengers to the existing railway composition.");
            Console.WriteLine("3. End, no more changes!");

            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n1. Add a wagon with passengers to the end of the composition.");
                    // Add wagon at the end, with passengers not more than max allowed
                    // Prompt user for number of passengers
                    int passengers = GetPositiveInteger("\nEnter the number of passengers to add: ", maxPassengers);
                    wagons.Add(passengers);
                    Console.WriteLine($"\nDebug: print the content of the created list:");
                    Console.WriteLine(string.Join(" ", wagons));
                    //Console.ReadKey(); // Pause before returning to the menu
                    break;
                case "2":
                    Console.WriteLine("\n2. Add passengers to the existing railway composition.");
                    // Prompt user for number of passengers to add
                    int passengersToAdd = GetPositiveInteger("\nEnter the number of passengers to add: ", maxPassengers);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengersToAdd <= maxPassengers)
                        {
                            wagons[i] += passengersToAdd;
                            break;
                        }
                        Console.WriteLine($"\nNot possible. Consider adding empty wagon!");
                        break;
                    }
                    Console.WriteLine($"\nDebug: print the content of the created list:");
                    Console.WriteLine(string.Join(" ", wagons));
                    //Console.ReadKey(); // Pause before returning to the menu
                    break;
                case "3":
                    Console.WriteLine("\n3. End, no more changes!");
                    // Print the final state of the train
                    Console.WriteLine(string.Join(" ", wagons));
                    //Console.ReadKey(); // Pause before returning to the menu
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
            Console.WriteLine("\nPress any key to make another selection");
            Console.ReadKey(true); // Pause before returning to the menu
        }

    }

    static int MaxPassengers(string prompt, int mostPassengers)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int passengers) && passengers >= 1 && passengers >= mostPassengers)
            {
                return passengers; // Valid positive integer
            }

            Console.WriteLine($"Invalid input. Please enter a positive integer larger than {mostPassengers}.");
        }
    }

    static int GetPositiveInteger(string prompt, int maxPassengers)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number > 0 && number <= maxPassengers)
            {
                return number; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }
    static void Task4()
    {
        Console.WriteLine();
        Console.WriteLine("Task 4: Cards Game");
        Console.WriteLine("------------------");

        // Players instructions
        Console.WriteLine("\nTen random cards are dealth to two players!");
        System.Threading.Thread.Sleep(1500); // Simulate delay
        Console.WriteLine("\nPress a key to genarate random card hands to two players.");
        Console.ReadKey(true); // Pause before returning to the menu

        // Initialize a random number generator
        Random random = new Random();

        // Create a list to store the random numbers
        List<int> firstPlayerDeck = new List<int>();

        // Generate 10 random numbers between 1 and 15
        for (int i = 0; i < 10; i++)
        {
            int randomNumber = random.Next(1, 16); // 1 is inclusive, 16 is exclusive
            firstPlayerDeck.Add(randomNumber);
        }

        // Create a list to store the random numbers
        List<int> secondPlayerDeck = new List<int>();

        // Generate 10 random numbers between 1 and 15
        for (int i = 0; i < 10; i++)
        {
            int randomNumber = random.Next(1, 16); // 1 is inclusive, 16 is exclusive
            secondPlayerDeck.Add(randomNumber);
        }

        // Debug: Read the two hands of cards
        Console.WriteLine("\nPlayer 1 random numbers: " + string.Join(", ", firstPlayerDeck));
        Console.WriteLine("Player 2 random numbers: " + string.Join(", ", secondPlayerDeck));

        {
            // Play the game
            while (firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0)
            {
                int firstCard = firstPlayerDeck[0];
                int secondCard = secondPlayerDeck[0];

                if (firstCard > secondCard)
                {
                    // First player wins the round
                    firstPlayerDeck.Add(firstCard);
                    firstPlayerDeck.Add(secondCard);
                }
                else if (secondCard > firstCard)
                {
                    // Second player wins the round
                    secondPlayerDeck.Add(secondCard);
                    secondPlayerDeck.Add(firstCard);
                }
                // Remove the played cards from the decks
                firstPlayerDeck.RemoveAt(0);
                secondPlayerDeck.RemoveAt(0);
            }

            // Determine the winner and calculate the sum of the winning deck
            Console.WriteLine("\nPress any key to calculate the winner!");
            Console.ReadKey(true);
            if (firstPlayerDeck.Count > 0)
            {
                Console.WriteLine($"\nFirst player wins! Sum: {firstPlayerDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"\nSecond player wins! Sum: {secondPlayerDeck.Sum()}");
            }
        }

    }
    static void Task5()
    {
        Console.WriteLine();
        Console.WriteLine("Task 5: Count Chars in a String");
        Console.WriteLine("-------------------------------");

        // Read the input string
        Console.Write("\nEnter a string: ");
        string input = Console.ReadLine();

        // Dictionary to store character occurrences
        Dictionary<char, int> charCounts = new Dictionary<char, int>();

        // Loop through the string and count characters
        foreach (char ch in input)
        {
            if (ch != ' ') // Ignore spaces
            {
                if (charCounts.ContainsKey(ch))
                {
                    charCounts[ch]++;
                }
                else
                {
                    charCounts[ch] = 1;
                }
            }
            else if (input.StartsWith(ch))
            {
                Console.WriteLine("\nEnter a string thta starts with character different than a space.");
                break;
            }
        }

        // Print the character occurrences
        foreach (var entry in charCounts)
        {
            Console.WriteLine($"{entry.Key} -> {entry.Value}");
        }

    }
    static void Task6()
    {
        Console.WriteLine();
        Console.WriteLine("Task 6: A Miner Task");
        Console.WriteLine("--------------------");

        // Read the input string
        Console.WriteLine("\nEnter a sequence of strings, resource and quantity, each on a new line:");
        //string input = Console.ReadLine();

        Dictionary<string, long> resources = new Dictionary<string, long>();

        while (true)
        {
            // Read the resource name
            Console.Write("\nEnter a resource or type 'stop' to exit: ");
            string resource = Console.ReadLine();

            // If the input is "stop", break out of the loop
            if (resource == "stop")
            {
                break;
            }

            // Read the quantity (assume valid integer input)
            Console.Write("\nEnter a quantity: ");
            int quantity = GetPositiveQuantity("Enter a quantity: ");

            // Update the resource quantities in the dictionary
            if (resources.ContainsKey(resource))
            {
                resources[resource] += quantity;
            }
            else
            {
                resources[resource] = quantity;
            }
        }

        // Print the resources and their quantities
        foreach (var kvp in resources)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }

    }

    static int GetPositiveQuantity(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number > 0 && number <= 2000000000)
            {
                return number; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer no larger than 2Bn.");
        }
    }
    static void Task7()
    {
        Console.WriteLine();
        Console.WriteLine("Task 7: Basic Stack Operations");
        Console.WriteLine("------------------------------");

        Console.WriteLine("\nEnter three integers in the following order:");
        Console.WriteLine("First integer is the elements to push.");
        Console.WriteLine("Second integer is the elements to pop.");
        Console.WriteLine("Third integer is the element to loock for.");
        string[] elements = null; // Declare the array outside the loop

        while (true)
        {
            Console.Write("\nEnter exactly three positive integers separated by spaces: ");

            // Read input from the user
            string input = Console.ReadLine();
            elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

            // Validate that the array contains exactly 3 elements
            if (elements.Length != 3)
            {
                Console.WriteLine("Error: Please enter exactly three values.");
                continue;
            }

            // Validate that all elements are positive integers
            bool isValid = true;
            foreach (string element in elements)
            {
                if (!int.TryParse(element, out int number) || number <= 0)
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Error: All values must be positive integers.");
                continue;
            }

            // If validation passes, print the array elements
            Console.WriteLine("Debug: You entered valid positive integers:");
            foreach (string element in elements)
            {
                Console.WriteLine(element);
            }

            // Exit the loop after successful input
            break;
        }

        // Input format: N, S, X
        int toBePushN = int.Parse(elements[0]); // Number of elements to push
        int toBePopS = int.Parse(elements[1]); // Number of elements to pop
        int toLookX = int.Parse(elements[2]); // Element to look for
        Console.WriteLine($"Based on your input number of elements to push is {toBePushN}, pop is {toBePopS}, and the element to look for is {toLookX}:");

        // Input for stack elements and its validations
        string[] pushElements = null; // Validation needed for 0 and integers

        while (true)
        {
            Console.Write($"\nEnter {toBePushN} elements to push separated by spaces: ");

            // Read input from the user
            string input = Console.ReadLine();
            pushElements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

            // Validate that the array contains exactly 3 elements
            if (pushElements.Length != toBePushN)
            {
                Console.WriteLine($"Error: Please enter exactly {toBePushN} integers.");
                continue;
            }

            // Validate that all elements are positive integers
            bool isValid = true;
            foreach (string element in pushElements)
            {
                if (!int.TryParse(element, out int number) || number <= 0)
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Error: All values must be positive integers.");
                continue;
            }

            // If validation passes, print the array elements
            Console.WriteLine("Debug: You entered valid positive integers:");
            foreach (string element in pushElements)
            {
                Console.WriteLine(element);
            }

            break; // Exit the loop after successful input
        }


        // Initialize stack
        Stack<int> stack = new Stack<int>();

        // Push N elements to the stack
        for (int i = 0; i < toBePushN && i < pushElements.Length; i++)
        {
            stack.Push(int.Parse(pushElements[i]));
        }

        // Pop S elements from the stack
        for (int i = 0; i < toBePopS && stack.Count > 0; i++)
        {
            stack.Pop();
        }

        // Print the stack elements before the check
        Console.WriteLine("\nDebug: Print the stack elements before the check:");
        foreach (int element in stack)
        {
            Console.WriteLine(element);
        }

        // Check for X in the stack
        Console.WriteLine("\nPrint 'true' if found, the smallest element if not or '0' if the stack is empty:");
        if (stack.Contains(toLookX))
        {
            Console.WriteLine("true");
        }
        else if (stack.Count > 0)
        { 
            Console.WriteLine(stack.Min()); // Print the smallest element in the stack
        }
        else
        {
            Console.WriteLine(0); // If stack is empty
        }


    }
    static void Task8()
    {
        Console.WriteLine();
        Console.WriteLine("Task 8: Basic Queue Operations");
        Console.WriteLine("------------------------------");


        Console.WriteLine("\nEnter three integers in the following order:");
        Console.WriteLine("First integer is the elements to enqueue (add).");
        Console.WriteLine("Second integer is the elements to dequeue (remove).");
        Console.WriteLine("Third integer is the element to loock for.");
        string[] elements = null; // Declare the array outside the loop

        while (true)
        {
            Console.Write("\nEnter exactly three positive integers separated by spaces: ");

            // Read input from the user
            string input = Console.ReadLine();
            elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

            // Validate that the array contains exactly 3 elements
            if (elements.Length != 3)
            {
                Console.WriteLine("Error: Please enter exactly three values.");
                continue;
            }

            // Validate that all elements are positive integers
            bool isValid = true;
            foreach (string element in elements)
            {
                if (!int.TryParse(element, out int number) || number <= 0)
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Error: All values must be positive integers.");
                continue;
            }

            // If validation passes, print the array elements
            Console.WriteLine("Debug: You entered valid positive integers:");
            foreach (string element in elements)
            {
                Console.WriteLine(element);
            }

            // Exit the loop after successful input
            break;
        }

        // Input format: N, S, X
        int toEnqueueN = int.Parse(elements[0]); // Number of elements to push
        int toDequeueS = int.Parse(elements[1]); // Number of elements to pop
        int toLookX = int.Parse(elements[2]); // Element to look for
        Console.WriteLine($"Based on your input number of elements to enqueue is {toEnqueueN}, dequeue is {toDequeueS}, and the element to look for is {toLookX}:");

        // Input for queue elements and its validations
        string[] pushElements = null; // Validation needed for 0 and integers

        while (true)
        {
            Console.Write($"\nEnter {toEnqueueN} elements to enqueue separated by spaces: ");

            // Read input from the user
            string input = Console.ReadLine();
            pushElements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

            // Validate that the array contains exactly 3 elements
            if (pushElements.Length != toEnqueueN)
            {
                Console.WriteLine($"Error: Please enter exactly {toEnqueueN} integers.");
                continue;
            }

            // Validate that all elements are positive integers
            bool isValid = true;
            foreach (string element in pushElements)
            {
                if (!int.TryParse(element, out int number) || number <= 0)
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Error: All values must be positive integers.");
                continue;
            }

            // If validation passes, print the array elements
            Console.WriteLine("Debug: You entered valid positive integers:");
            foreach (string element in pushElements)
            {
                Console.WriteLine(element);
            }

            break; // Exit the loop after successful input
        }


        // Initialize queue
        Queue<int> intQueue = new Queue<int>();

        // Enqueue N elements to the queue
        for (int i = 0; i < toEnqueueN && i < pushElements.Length; i++)
        {
            intQueue.Enqueue(int.Parse(pushElements[i]));
        }

        // Dequeue S elements from the queue
        for (int i = 0; i < toDequeueS && intQueue.Count > 0; i++)
        {
            intQueue.Dequeue();
        }

        // Print the queue elements before the check
        Console.WriteLine("\nDebug: Print the queue elements before the check:");
        foreach (int element in intQueue)
        {
            Console.WriteLine(element);
        }

        // Check for X in the queue
        Console.WriteLine("\nPrint 'true' if found, the smallest element if not or '0' if the stack is empty:");
        if (intQueue.Contains(toLookX))
        {
            Console.WriteLine("true");
        }
        else if (intQueue.Count > 0)
        {
            Console.WriteLine(intQueue.Min()); // Print the smallest element in the queue
        }
        else
        {
            Console.WriteLine(0); // If queue is empty
        }

    }
}
