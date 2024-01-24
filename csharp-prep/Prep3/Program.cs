using System;

class Program
{
    static void Main(string[] args)
    {
        // Loop for restarting the game
        while (true)
        {
            // Step 1: Generate a random magic number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            // Initialize the number of guesses
            int numberOfGuesses = 0;

            // Loop until the user guesses the correct number
            while (true)
            {
                // Step 2: Ask the user for a guess
                Console.Write("Enter your guess: ");
                int userGuess = int.Parse(Console.ReadLine());

                // Increment the number of guesses
                numberOfGuesses++;

                // Step 3: Use an if statement to determine if the guess is higher, lower, or correct
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Guess higher next time.");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Guess lower next time.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the magic number in {numberOfGuesses} guesses!");
                    break; // Exit the loop when the correct number is guessed
                }
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();

            // Exit the loop if the user does not want to play again
            if (playAgain != "yes")
            {
                break;
            }
        }
    }
}
    