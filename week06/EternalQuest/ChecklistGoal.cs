using System;

class ChecklistGoal : Goal
{
    private int _TimesCompleted;
    private int _TimesToComplete;
    private int _BonusPoints;

    public ChecklistGoal(string goalName, string goalDescription, int goalPoints, int timesToComplete, int bonusPoints) : base(goalName, goalDescription, goalPoints)
    {
        _TimesCompleted = 0;
        _TimesToComplete = timesToComplete;
        _BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (_TimesCompleted < _TimesToComplete)
        {
            _TimesCompleted++;
        }
    }   

    public override bool IsComplete()
    {
        return _TimesCompleted >= _TimesToComplete;
    }

    public override string GetDetailString()
    {
        return $"Goal: {GetGoalName()}\nDescription: {GetGoalDescription()}\nPoints: {GetGoalPoints()}\nStatus: {_TimesCompleted}/{_TimesToComplete} completed\nBonus Points: {_BonusPoints}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetGoalName()}|{GetGoalDescription()}|{GetGoalPoints()}|{_TimesCompleted}|{_TimesToComplete}|{_BonusPoints}";
    }
}