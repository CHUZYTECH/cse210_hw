using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        Entry newEntry = new Entry(prompt, response);
        entries.Add(newEntry);
        Console.WriteLine("✅ Entry added successfully!");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string fileName)
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(fileName, json);
        Console.WriteLine($"✅ Journal saved to {fileName}.");
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            entries = JsonConvert.DeserializeObject<List<Entry>>(json) ?? new List<Entry>();
            Console.WriteLine("✅ Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("⚠ Journal file not found. No data loaded.");
        }
    }
}
