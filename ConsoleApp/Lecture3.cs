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

internal class Lecture3
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
        Console.WriteLine("Task 1: Cinema Hall");
        Console.WriteLine("-------------------");

        // Prompt user for screening type
        string screeningType = GetScreeningType();

        // Prompt user for number of rows
        int rows = GetPositiveInteger("\nEnter the number of rows in the hall:");

        // Prompt user for number of columns
        int columns = GetPositiveInteger("\nEnter the number of columns in the hall:");

        // Calculate total revenue
        double pricePerSeat = GetPrice(screeningType);
        int totalSeats = rows * columns;
        double totalRevenue = pricePerSeat * totalSeats;

        // Convert first leter to capital
        screeningType = char.ToUpper(screeningType[0]) + screeningType.Substring(1);

        // Display the result
        Console.WriteLine($"\nPress any key to calculate the revenue from a cinema hall with {totalSeats} seats and {screeningType} screening selected!");
        Console.ReadKey(true); // Pause before returning to the menu
        Console.WriteLine($"\nThe total revenue for a full hall is: {totalRevenue:F2} BGN");
    }

    static string GetScreeningType()
    {
        while (true)
        {
            Console.WriteLine("Screening Types:");
            Console.WriteLine("1. Premiere – premiere screening (12.00 BGN)");
            Console.WriteLine("2. Normal – standard screening (7.50 BGN)");
            Console.WriteLine("3. Discount – screenings for children, students, and pupils (5.00 BGN)");
            Console.WriteLine("\nEnter the screening type (Premiere, Normal, Discount)");
            string input = Console.ReadLine()?.Trim();

            if (input.Equals("Premiere", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Normal", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Discount", StringComparison.OrdinalIgnoreCase))
            {
                return input; // Valid input
            }

            Console.WriteLine("\nInvalid screening type. Please enter Premiere, Normal, or Discount.");
            Console.WriteLine("\nPress any key to return to try again...");
            Console.ReadKey(); // Pause before returning to the menu
            Console.Clear();
        }
    }

    static int GetPositiveInteger(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number > 0)
            {
                return number; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    static double GetPrice(string screeningType)
    {
        // Return the price based on screening type
        switch (screeningType.ToLower())
        {
            case "premiere":
                return 12.00;
            case "normal":
                return 7.50;
            case "discount":
                return 5.00;
            default:
                throw new ArgumentException("Invalid screening type.");
        }
    }

    static void Task2()
    {
        Console.WriteLine();
        Console.WriteLine("Task 2: Fishing Trip");
        Console.WriteLine("--------------------");

        // Prompt user for group budget
        Console.WriteLine("Budget range: 1 to 8000 BGN");
        int groupbudget = GetBudgetInteger("\nEnter the group budget:");

        // Prompt user for season
        string season = GetSeason();

        // Prompt user for number of fishermen
        int fishermen = GetFishermenInteger("\nEnter the number of fishermen (between 4 and 18):");

        // Calculates whether the fishermen can gather enough money"

        double pricePerBoat = GetBoatPrice(season);
        double groupdiscount = GetGroupDiscount(fishermen);
        double boatPriceDiscounted = pricePerBoat - ( pricePerBoat * groupdiscount );
        Console.WriteLine($"\nDebug: discount for number of fishermen");
        Console.WriteLine($"Price afer first discount: {boatPriceDiscounted}");

        double enoughbudget = groupbudget - boatPriceDiscounted;
        Console.WriteLine($"You're {enoughbudget} under/over the needed amount");

        // Calculate additiona discount
        double additionalDiscount = CalculateAdditionalDiscount(fishermen, season);
        Console.WriteLine($"\nDebug: discount for even number of fishermen except Autumn");
        Console.WriteLine($"groupdiscount is: {groupdiscount}, additionalDiscount is: {additionalDiscount}");
        double finalprice = pricePerBoat - ( pricePerBoat * ( groupdiscount + additionalDiscount));
        Console.WriteLine($"\nPrice afer final discount: {finalprice}");

        // Check if the finalprice is positive and greater than 1
        if (groupbudget > finalprice)
        {
            Console.WriteLine($"You can book a boat!");
        }
        else
        {
            Console.WriteLine($"Sorry, not enough budget to book a boat!");
        }
    }

    static int GetBudgetInteger(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int budget) && budget >= 1 && budget <= 8000)
            {
                return budget; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer between 1 and 8000.");
        }
    }

    static string GetSeason()
    {
        while (true)
        {
            Console.WriteLine("\nSeasons:");
            Console.WriteLine("1. Spring boat price (3000.00 BGN)");
            Console.WriteLine("2. Summer boat price (4200.00 BGN)");
            Console.WriteLine("3. Autumn boat prices (4200.00 BGN)");
            Console.WriteLine("4. Winter boat price (2600.00 BGN)");
            Console.WriteLine("\nEnter the season (Spring, Summer, Autumn, Winter)");
            string input = Console.ReadLine()?.Trim();

            if (input.Equals("Spring", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Summer", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Autumn", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Winter", StringComparison.OrdinalIgnoreCase))
            {
                return input; // Valid input
            }

            Console.WriteLine("\nInvalid season. Please enter Spring, Summer, Autumn or Winter.");
            Console.WriteLine("\nPress any key to return to try again...");
            Console.ReadKey(); // Pause before returning to the menu
            Console.Clear();
        }
    }
    static int GetFishermenInteger(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int fishermen) && fishermen >= 4 && fishermen <= 18)
            {
                return fishermen; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer between 4 and 18.");
        }
    }
    static double GetBoatPrice(string season)
    {
        // Return the price based on screening type
        switch (season.ToLower())
        {
            case "spring":
                return 3000.00;
            case "summer":
                return 4200.00;
            case "autumn":
                return 4200.00;
            case "winter":
                return 2600.00;
            default:
                throw new ArgumentException("Invalid season.");
        }
    }

    static double GetGroupDiscount(int fishermen)
    {
        // Return the discount based on number of fishermen
        switch (fishermen)
        {
            case <= 6:  // Up to 6 people
                return 0.10;
            case <= 11: // 7 to 11 people
                return 0.15;
            case <= 18: // 12 to 18 people
                return 0.25;
            //case "winter":
            //    return 2600.00;
            default:
                throw new ArgumentException("Invalid interger.");
        }
    }

    static double CalculateAdditionalDiscount(int fishermen, string season)
    {
        double additionalDiscount = 0.0;

        // Additional discount for even-numbered groups, except in autumn
        if (fishermen % 2 == 0 && !season.Equals("Autumn", StringComparison.OrdinalIgnoreCase))
        {
            additionalDiscount += 0.05; // Add 5% for even groups and season except Autumn
        }

        return additionalDiscount;
    }
    static void Task3()
    {
        Console.WriteLine();
        Console.WriteLine("Task 3: Salary Deduction");
        Console.WriteLine("------------------------");

        // Read number of open tabs in the browser
        Console.WriteLine("Stay away of facebook, instagram, reddit in your open tabs or else... :");

        // Read number of open tabs in the browser
        Console.WriteLine("\nNumber of open tabs range: 1 to 10:");
        int n = GetOpenTabs("\nEnter the number of tabs:");

        Console.WriteLine("\nEnter your salary range: 700 to 1500 BGN");
        int salary = GetSalary("\nEnter your salary:");

        // Iterate through the websites and apply fines
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter the name of website {i + 1}:");
            string website = Console.ReadLine()?.Trim();

            switch (website.ToLower())
            {
                case "facebook":
                    salary -= 150;
                    break;
                case "instagram":
                    salary -= 100;
                    break;
                case "reddit":
                    salary -= 50;
                    break;
                default:
                    // No fine for other websites
                    break;
            }

            // Check if salary is depleted
            if (salary <= 0)
            {
                Console.WriteLine("\nYou have lost your salary.");
                return; // Exit the program
            }
        }

        // Output the remaining salary
        Console.WriteLine($"\nYour remaining salary is: {salary} BGN");
    }

    static int GetOpenTabs(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int opentabs) && opentabs >= 1 && opentabs <= 10)
            {
                return opentabs; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer between 1 and 10.");
        }
    }

    static int GetSalary(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int salary) && salary >= 700 && salary <= 1500)
            {
                return salary; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer between 700 and 1500.");
        }
    }

    static void Task4()
    {
        Console.WriteLine();
        Console.WriteLine("Task 4: Steps to Reach a Goal");
        Console.WriteLine("-----------------------------");

        Console.WriteLine("\nDaily goal is 10000 steps!");
        const int goalSteps = 10000; // Goal of 10,000 steps
        int totalSteps = 0;         // Tracks the total steps taken
        int i = 0;                  // Used for iteration count

        //  Loop that runs as long as the total steps are less than the goal
        while (totalSteps < goalSteps)
        {
            Console.WriteLine($"\nGoing out for walk count: {i + 1}");
            Console.WriteLine("Enter the number of steps, or type 'Going home' if you're heading home:");
            string input = Console.ReadLine()?.Trim();

            if (IsValidInputSteps(input)) // Call Check valid input for cake task
            {

                if (input.Equals("Going home", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nEnter the number of steps you took on your way home:");
                    int homeSteps = int.Parse(Console.ReadLine());
                    totalSteps += homeSteps;
                    break; // Exit the loop after heading home
                }
                else
                {
                    int steps = int.Parse(input); // Parse steps input
                    totalSteps += steps;
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer or 'Going home'.");
            }

        }

        // Output based on whether the goal was reached
        if (totalSteps >= goalSteps)
        {
            Console.WriteLine("\nGoal reached! Good job!");
        }
        else
        {
            int stepsRemaining = goalSteps - totalSteps;
            Console.WriteLine($"\n{stepsRemaining} more steps to reach goal.");
        }
    }

    static bool IsValidInputSteps(string input) // Check valid input for steps task
    {
        // Check if input is "STOP"
        if (input.Equals("Going home", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        // Check if input is a positive integer
        if (int.TryParse(input, out int number) && number > 0)
        {
            return true;
        }

        // Input is invalid
        return false;
    }

    static void Task5()
    {
        Console.WriteLine();
        Console.WriteLine("Task 5: Birthday Cake");
        Console.WriteLine("---------------------");

        // Prompt the user for cake dimensions and calculate the cake pieces
        Console.Write("\nCake dimension is based on length and width that each ranges from 1 to 1000.");
        Console.WriteLine("\n");
        int cakeLength = GetCakeLength("Enter the cake length:");

        static int GetCakeLength(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int cakeLength) && cakeLength >= 1 && cakeLength <= 1000)
                {
                    return cakeLength; // Valid positive integer
                }

                Console.WriteLine("Invalid input. Please enter a positive integer between 1 and 1000.");
            }
        }

        //Console.Write("Enter the cake width range: 1 to 1000 ");
        int cakeWidth = GetCakeWidth("Enter the cake width:");
        
        static int GetCakeWidth(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int cakeWidth) && cakeWidth >= 1 && cakeWidth <= 1000)
                {
                    return cakeWidth; // Valid positive integer
                }

                Console.WriteLine("Invalid input. Please enter a positive integer between 1 and 1000.");
            }
        }

        int totalCakePieces = cakeLength * cakeWidth;

        int piecesTaken = 0;         // Tracks the total pieces taken
        int i = 0;                  // Used for iteration count

        //  Loop that runs as long as there are pieces left
        while (piecesTaken < totalCakePieces)
        {
            Console.WriteLine($"\nGuest {i + 1}:");
            Console.WriteLine("Enter the number of pieces, or type 'Stop' if you're done:");
            string input = Console.ReadLine()?.Trim();

            if (IsValidInputCake(input)) // Call Check valid input for cake task
            {

                if (input.Equals("Stop", StringComparison.OrdinalIgnoreCase)) // Output based on Stop
                {
                    Console.WriteLine($"\n{totalCakePieces - piecesTaken} pieces are left.");
                    break; // Exit the loop
                }
                else // 
                {
                    int piecesEachTurn = int.Parse(input); // Parse pieces input
                    piecesTaken += piecesEachTurn;
                    i++;
                }
            }

            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer or 'STOP'.");
            }
        }

        // Output based on whether there are not enough pieces
        if (piecesTaken > totalCakePieces)
        {
            Console.WriteLine($"\nNo more cake left! You need {piecesTaken - totalCakePieces} pieces more.");
        }

    }

    static bool IsValidInputCake(string input) // Check valid input for cake task
    {
        // Check if input is "STOP"
        if (input.Equals("STOP", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        // Check if input is a positive integer
        if (int.TryParse(input, out int number) && number > 0)
        {
            return true;
        }

        // Input is invalid
        return false;
    }

    static void Task6()
    {
        Console.WriteLine();
        Console.WriteLine("Task 5: Password Generator");
        Console.WriteLine("--------------------------");

        // Prompt user for integers
        Console.WriteLine("\nEnter integers range: 1 to 9");
        int n = GetNInteger("Enter the first integer:");
        int l = GetNInteger("Enter the second integer:");

        //Console.WriteLine("Enter an integer n (1 ≤ n ≤ 9):");

        // Read and validate input
        if (n >= 1 && n <= 9 && l >= 1 && l <= 9)
        {
            Console.WriteLine("\nGenerated passwords:");

            // Generate all combinations of Symbol 1 and Symbol 2
            for (int symbol1 = 1; symbol1 <= n; symbol1++)
            {
                for (int symbol2 = 1; symbol2 <= n; symbol2++)
                {
                    for (char symbol3 = 'a'; symbol3 < 'a' + l; symbol3++)
                    {
                        for (char symbol4 = 'a'; symbol4 <'a' + l; symbol4++)
                        {
                            for (int symbol5 = 1; symbol5 <= n; symbol5++)
                            {
                                if (symbol5 > symbol1 && symbol5 > symbol2) // Symbol 5 must be greater than symbol1 and symbol2
                                {
                                    // Print the combination in the required format
                                    Console.Write($"{symbol1}{symbol2}{symbol3}{symbol4}{symbol5} ");
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter an integer between 1 and 9.");
        }
    }

    static int GetNInteger(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int j) && j >= 1 && j <= 9)
            {
                return j; // Valid positive integer
            }

            Console.WriteLine("Invalid input. Please enter a positive integer between 1 and 9.");
        }
    }
}
