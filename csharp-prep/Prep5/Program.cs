using System;

class Program
{
    static void Main(string[] args)
    {
         // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName function
        string userName = PromptUserName();

        // Call PromptUserNumber function
        int userNumber = PromptUserNumber();

        // Call SquareNumber function
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt and get user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt and get user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            Console.Write("Please enter your favorite number: ");
        }
        return number;
    }

    // Function to square a given number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"Hello, {userName}! Your favorite number squared is: {squaredNumber}");
    }
}