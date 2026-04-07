using System;
using System.Collections.Generic;

class GoalManager
{
    private List<Goal> _Goals;
    private int _TotalPoints;

    public GoalManager()
    {
        _Goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        _Goals.Add(goal);
    }

    public List<Goal> GetGoals()
    {
        return _Goals;
    }
}