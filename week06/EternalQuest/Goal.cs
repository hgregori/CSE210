using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

public abstract class Goal
{
    private string _GoalName;
    private string _GoalDescription;
    private int _GoalPoints;

    public Goal(string goalName, string goalDescription, int goalPoints)
    {
        _GoalName = goalName;
        _GoalDescription = goalDescription;
        _GoalPoints = goalPoints;
    }

    public string GetGoalName()
    {
        return _GoalName;
    }

    public string GetGoalDescription()
    {
        return _GoalDescription;
    }

    public int GetGoalPoints()
    {
        return _GoalPoints;
    }

    public abstract void RecordEvent();
    
    public abstract bool IsComplete();

    public abstract string GetDetailString();

    public abstract string GetStringRepresentation();
}