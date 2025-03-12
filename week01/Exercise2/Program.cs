using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        // Convert the input string to an integer
        int gradePercentage = int.Parse(input);

        // Variables to hold the letter grade and sign
        string letter = "";
        string sign = "";

        // ------------------ Core Requirement: Determine Letter Grade ------------------
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // ------------------ Core Requirement: Pass or Fail Message ------------------
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard and you will improve next time.");
        }

        // ------------------ Stretch Challenge: Add "+" or "-" Sign ------------------
        int lastDigit = gradePercentage % 10; // Get the last digit to determine the sign

        // Logic for adding sign
        if (letter != "F") // No "+" or "-" for F
        {
            if (letter == "A")
            {
                // A- for 90-92
                if (gradePercentage < 93)
                {
                    sign = "-";
                }
                // No A+ (so sign remains empty if not A-)
            }
            else
            {
                // Add "+" if last digit is 7, 8, 9
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                // Add "-" if last digit is 0, 1, 2
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
                // No sign if last digit is between 3 and 6
            }
        }

        // ------------------ Final Output ------------------
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
    }
}
