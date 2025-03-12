using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the function to display welcome message
        DisplayWelcome();

        // Call function to prompt user's name and store the result
        string userName = PromptUserName();

        // Call function to prompt user's favorite number and store the result
        int favoriteNumber = PromptUserNumber();

        // Call function to square the user's favorite number and store the result
        int squaredNumber = SquareNumber(favoriteNumber);

        // Call function to display the final result
        DisplayResult(userName, squaredNumber);
    }

    /// <summary>
    /// Displays a welcome message.
    /// </summary>
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    /// <summary>
    /// Prompts the user to enter their name and returns it.
    /// </summary>
    /// <returns>User's name as a string</returns>
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    /// <summary>
    /// Prompts the user to enter their favorite number and returns it as an integer.
    /// </summary>
    /// <returns>User's favorite number as an integer</returns>
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input); // Convert string input to integer
        return number;
    }

    /// <summary>
    /// Squares the given number.
    /// </summary>
    /// <param name="number">Integer number to be squared</param>
    /// <returns>Squared value of the number</returns>
    static int SquareNumber(int number)
    {
        return number * number;
    }

    /// <summary>
    /// Displays the user's name and the squared number result.
    /// </summary>
    /// <param name="name">User's name</param>
    /// <param name="squaredNumber">Squared number</param>
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
