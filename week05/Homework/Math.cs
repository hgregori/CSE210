using System;

class Math : Student
{

    private double _section;
    private string _problem;

    public Math(string name, string topic, double section, string problem) : base(name, topic)
    {
        _section = section;
        _problem = problem;
    }

    public string GetProblem()
    {
        return $"Section: {_section}, Problem: {_problem}";
    }
}