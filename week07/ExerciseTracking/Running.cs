using System;

public class Running : Exercices
{
    private double _distance;

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        double speed = ( _distance / GetMinutes()) * 60;
        return speed;
    }

    public override double GetPace()
    {
        double pace = GetMinutes() / _distance;
        return pace;
    }
}
