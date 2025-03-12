using System;

class Program
{
    static void Main(string[] args)
    {
        // Variable to control if the game should be repeated
        string playAgain;

        // Outer loop to allow playing multiple times
        do
        {
            Console.WriteLine("\nWelcome to the Guess My Number Game!");
            Console.WriteLine("I have selected a magic number between 1 and 100. Try to guess it!");

            // Generate a random magic number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101); // Range: 1 to 100

            // Uncomment this line to reveal the magic number for testing purposes
            // Console.WriteLine($"(For Testing: Magic Number is {magicNumber})");

            int guess = 0;
            int guessCount = 0;

            // Loop until user guesses the magic number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();

                // Input validation: ensure the user enters a valid number
                bool isValid = int.TryParse(userInput, out guess);
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue; // Skip the rest of the loop and prompt again
                }

                // Increment guess count
                guessCount++;

                // Check if guess is lower, higher, or correct
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! Congratulations!");
                    Console.WriteLine($"It took you {guessCount} guess(es) to find the magic number.");
                }
            }

            // Ask user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("\nThank you for playing! Goodbye!");
    }
}
