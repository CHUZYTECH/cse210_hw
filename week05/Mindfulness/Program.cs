using System;
using System.Collections.Generic;
using System.IO;

// Base class for all goals
abstract class Goal
{
    protected string _name;
    protected int _points;
    
    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }
    
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
}

// Simple goal that can be completed once
class SimpleGoal : Goal
{
    private bool _completed;
    
    public SimpleGoal(string name, int points) : base(name, points)
    {
        _completed = false;
    }
    
    public override void RecordEvent()
    {
        _completed = true;
        Console.WriteLine($"{_name} completed! You earned {_points} points.");
    }
    
    public override bool IsComplete()
    {
        return _completed;
    }
    
    public override string GetStatus()
    {
        return _completed ? "[X]" : "[ ]";
    }
}

// Eternal goal that never gets completed
class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }
    
    public override void RecordEvent()
    {
        Console.WriteLine($"{_name} recorded! You earned {_points} points.");
    }
    
    public override bool IsComplete()
    {
        return false;
    }
    
    public override string GetStatus()
    {
        return "[∞]";
    }
}

// Checklist goal that needs to be completed multiple times
class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;
    
    public ChecklistGoal(string name, int points, int target, int bonus) : base(name, points)
    {
        _target = target;
        _current = 0;
        _bonus = bonus;
    }
    
    public override void RecordEvent()
    {
        _current++;
        if (_current == _target)
        {
            Console.WriteLine($"{_name} completed! Bonus {_bonus} points awarded!");
        }
        else
        {
            Console.WriteLine($"{_name} recorded! {_points} points earned.");
        }
    }
    
    public override bool IsComplete()
    {
        return _current >= _target;
    }
    
    public override string GetStatus()
    {
        return IsComplete() ? "[✔]" : $"[{_current}/{_target}]";
    }
}

// Goal Manager to handle goals
class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    
    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetType().Name}: {_goals[i]._name}");
        }
    }
    
    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
        }
    }
    
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal._name},{goal._points}");
            }
        }
    }
    
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _goals.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                var parts = line.Split(',');
                if (parts[0] == "SimpleGoal") _goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2])));
                if (parts[0] == "EternalGoal") _goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                if (parts[0] == "ChecklistGoal") _goals.Add(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4])));
            }
        }
    }
}

// Main program class
class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        
        manager.AddGoal(new SimpleGoal("Run 5K", 50));
        manager.AddGoal(new EternalGoal("Read Scripture", 10));
        manager.AddGoal(new ChecklistGoal("Drink Water", 5, 10, 20));
        
        while (true)
        {
            Console.WriteLine("\n1. List Goals\n2. Record Event\n3. Save\n4. Load\n5. Exit");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());
            
            if (choice == 1) manager.ListGoals();
            else if (choice == 2)
            {
                Console.Write("Enter goal number: ");
                int goalIndex = int.Parse(Console.ReadLine()) - 1;
                manager.RecordEvent(goalIndex);
            }
            else if (choice == 3) manager.SaveToFile("goals.txt");
            else if (choice == 4) manager.LoadFromFile("goals.txt");
            else break;
        }
    }
}
