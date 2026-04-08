class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _timesToComplete;
    private int _bonusPoints;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _timesToComplete = target;
        _bonusPoints = bonus;
    }

    public override void RecordEvent()
    {
        if (_timesCompleted < _timesToComplete)
        {
            _timesCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _timesToComplete;
    }

    public override int GetPoints()
    {
        if (_timesCompleted == _timesToComplete)
        {
            return _goalPoints + _bonusPoints;
        }

        return _goalPoints;
    }
    public override string GetDetailString()
    {
    return $"Goal: {GetGoalName()}\n" +
           $"Description: {GetGoalDescription()}\n" +
           $"Points per completion: {GetPoints()}\n" +
           $"Status: {_timesCompleted}/{_timesToComplete} completed\n" +
           $"Bonus Points: {_bonusPoints}";
    }


    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetGoalName()}|{GetGoalDescription()}|{GetPoints()}|{_timesCompleted}|{_timesToComplete}|{_bonusPoints}";
    }
}