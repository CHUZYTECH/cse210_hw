using System;
using System.Collections.Generic;
using System.Threading;

class GratitudeActivity : Activity
{
    public GratitudeActivity()
    {
        _name = "Gratitude Activity";
        _description = "This activity helps you focus on what you’re thankful for today.";
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("\nStart thinking of people, experiences, or things you’re grateful for.");
        ShowCountdown(3);
        List<string> gratitudeList = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                gratitudeList.Add(item);
            }
        }

        Console.WriteLine($"\nYou expressed gratitude for {gratitudeList.Count} things. Nice work!");
    }
}
