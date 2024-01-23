using System;

class Program
{
    static void Main(string[] args)
    {
         // Prompt the First anme
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

         // prompt the Last name
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

         // Display full name in the specified format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");
    }
}