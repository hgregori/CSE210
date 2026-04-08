using System;

class EternalGoal : Goal
{
    public EternalGoal(string goalName, string goalDescription, int goalPoints) : base(goalName, goalDescription, goalPoints)
    {
        // No additional fields needed for an eternal goal.
    }
    public override void RecordEvent()
    {
        // This goal is eternal, so it never gets completed.
    }

    public override bool IsComplete()
    {
        return false; // This goal is never complete.
    }

    public override string GetDetailString()
    {
        return $"Goal: {GetGoalName()}\nDescription: {GetGoalDescription()}\nPoints: {GetPoints()}\nStatus: Eternal (never completed)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetGoalName()}|{GetGoalDescription()}|{GetPoints()}";
    }

}