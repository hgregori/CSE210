using System;

class Writing : Student
{

    private string _title;

    public Writing(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

     public string GetWritingInformation()
    {
        return _title + " by " + GetName();
    }
}