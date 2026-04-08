public abstract class Goal
{
    private string _goalName;
    private string _goalDescription;
    protected int _goalPoints;

    protected Goal(string name, string description, int points)
    {
        _goalName = name;
        _goalDescription = description;
        _goalPoints = points;
    }

    public string GetGoalName() => _goalName;

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailString();
    public abstract string GetStringRepresentation();
    // ✅ virtual — NOT abstract
    public virtual int GetPoints()
    {
        return _goalPoints;
    }   

    public string GetGoalDescription()
    {
        return _goalDescription;
    }

}