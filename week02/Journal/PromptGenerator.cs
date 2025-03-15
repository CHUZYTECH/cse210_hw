using System;
using System.Collections.Generic;
using System.IO;

class PromptGenerator
{
    private List<string> prompts = new List<string>();

    public PromptGenerator()
    {
        LoadPromptsFromCSV("prompts.csv");
    }

    private void LoadPromptsFromCSV(string fileName)
    {
        if (File.Exists(fileName))
        {
            prompts.AddRange(File.ReadAllLines(fileName));
        }
        else
        {
            Console.WriteLine("⚠ Prompt file not found! Using default prompts.");
            prompts.Add("What made you smile today?");
            prompts.Add("What are you grateful for?");
        }
    }

    public string GetRandomPrompt()
    {
        if (prompts.Count == 0) return "Write about anything!";
        Random rand = new Random();
        return prompts[rand.Next(prompts.Count)];
    }
}
