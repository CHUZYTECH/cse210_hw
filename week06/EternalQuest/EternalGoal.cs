// EternalGoal.cs
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Points accumulate but never completes
    }

    public override bool IsComplete() => false;

    public override string GetStatus() =>
        $"[ ] {Name} ({Description})";

    public override string SaveString() =>
        $"EternalGoal|{Name}|{Description}|{Points}";
}
