using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Ask the user for a series of numbers and append each one to a list
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a series of numbers. Enter 0 to stop.");

        while (true)
        {
            Console.Write("Enter a number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                break; // Stop when the user enters 0
            }

            numbers.Add(input);
        }

        // Step 2: Compute the sum of the numbers in the list
        int sum = numbers.Sum();

        // Step 3: Compute the average of the numbers in the list
        double average = numbers.Average();

        // Step 4: Find the maximum number in the list
        int maxNumber = numbers.Max();

        // Step 5: Find the smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();

        // Step 6: Sort the numbers in the list
        numbers.Sort();

        // Display results
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Maximum Number: {maxNumber}");
        Console.WriteLine($"Smallest Positive Number: {smallestPositive}");
        Console.WriteLine("Sorted List: " + string.Join(", ", numbers));
    }
}
