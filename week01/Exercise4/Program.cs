using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // List to store the numbers
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers from user until 0 is entered
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            // Check if input is a valid integer
            bool isValid = int.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            // Only add number if it's not zero
            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Check if any number was added
        if (numbers.Count == 0)
        {
            Console.WriteLine("No valid numbers were entered. Exiting program.");
            return;
        }

        // CORE REQUIREMENTS

        // 1. Compute the sum
        int sum = numbers.Sum();

        // 2. Compute the average
        double average = numbers.Average();

        // 3. Find the maximum number
        int maxNumber = numbers.Max();

        // Display core results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        // STRETCH CHALLENGES

        // 1. Find the smallest positive number
        // Select numbers greater than 0, then find the minimum
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        if (positiveNumbers.Count > 0)
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        // 2. Sort and display the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
