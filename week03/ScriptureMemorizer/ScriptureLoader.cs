using System;
using System.Collections.Generic;
using System.IO;

class ScriptureLoader
{
    public static List<Scripture> LoadFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    Reference reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[1]));
                    scriptures.Add(new Scripture(reference, parts[1]));
                }
            }
        }
        return scriptures;
    }
}
