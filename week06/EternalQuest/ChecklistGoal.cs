// ChecklistGoal.cs
public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int timesCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsComplete() => _timesCompleted >= _target;

    public override string GetStatus()
    {
        string mark = IsComplete() ? "X" : " ";
        return $"[{mark}] {Name} ({Description}) -- Completed: {_timesCompleted}/{_target}";
    }

    public override string SaveString() =>
        $"ChecklistGoal|{Name}|{Description}|{Points}|{_target}|{_bonus}|{_timesCompleted}";

    public int GetBonus() => _bonus;
    public int GetTarget() => _target;
    public int GetTimesCompleted() => _timesCompleted;
}
