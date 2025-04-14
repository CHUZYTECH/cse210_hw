using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself through this experience?",
        "How did you feel when it was complete?",
        "What could you learn from this experience that applies to other situations?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength.";
    }

    protected override void PerformActivity()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        Random rand = new Random();
        while (DateTime.Now < end)
        {
            string q = _questions[rand.Next(_questions.Count)];
            Console.Write($"\n> {q} ");
            ShowSpinner(5);
        }
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
