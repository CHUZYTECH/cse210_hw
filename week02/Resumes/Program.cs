using System;
using System.Collections.Generic;

public class Resume
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }

    public Resume()
    {
        Jobs = new List<Job>();
    }

    // Display the resume with the name and job details
    public void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Jobs:");
        foreach (var job in Jobs)
        {
            job.Display();
        }
    }
}

public class Job
{
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    // Display a single job's details
    public void Display()
    {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a new Resume instance
        Resume myResume = new Resume();
        myResume.Name = "Oko Samuel Ogbonnia"; // You can replace this with your real name

        // Add job experiences to the resume
        Job job1 = new Job()
        {
            Company = "CHUZYTECH GROUP OF COMPANY",
            JobTitle = "Software Developer",
            StartYear = 2020,
            EndYear = 2023
        };

        Job job2 = new Job()
        {
            Company = "TechSolutionCrib",
            JobTitle = "Content Writer",
            StartYear = 2023,
            EndYear = 2025
        };

        // Add jobs to the Resume's Jobs list
        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        // Display the Resume
        myResume.Display();
    }
}
