using System;

namespace SimpleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call the function to write text to the console
            WriteToConsole("Hello Petar, this is a message from the console!");
        }

        // Function to write text to the console
        static void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}

