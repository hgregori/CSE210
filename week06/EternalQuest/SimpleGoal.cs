using System;

class SimpleGoal : Goal
{
    private bool _IsComplete;

    public SimpleGoal(string goalName, string goalDescription, int goalPoints) : base(goalName, goalDescription, goalPoints)
    {
        _IsComplete = false;
    }

    public override void RecordEvent()
    {
        _IsComplete = true;
    }

    public override bool IsComplete()
    {
        return _IsComplete;
    }

    public override string GetDetailString()
    {
        return $"Goal: {GetGoalName()}\nDescription: {GetGoalDescription()}\nPoints: {GetPoints()}\nStatus: {( _IsComplete ? "Completed" : "Not Completed" )}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetGoalName()}|{GetGoalDescription()}|{GetPoints()}|{_IsComplete}";
    }

}