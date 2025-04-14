using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 4, 14), 30, 4.8),
            new Cycling(new DateTime(2024, 4, 15), 45, 20.0),
            new Swimming(new DateTime(2024, 4, 16), 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
