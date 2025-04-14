// SimpleGoal.cs
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStatus() =>
        $"[{"X",1}] {Name} ({Description})";

    public override string SaveString() =>
        $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
}
