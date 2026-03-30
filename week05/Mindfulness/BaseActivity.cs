using System;
using System.Collections.Generic;
using System.Threading;

class BaseActivity
{
    private string _activityName;
    private string _description;

    public BaseActivity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }

    public int StartActivity()
    {
        Console.WriteLine($"\n--- {_activityName} Activity ---");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like to do this activity? ");

        int duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(5);

        return duration;
    }

    public void EndActivity(int duration)
    {
        Console.WriteLine("\nGreat job! You have completed the activity.");
        Console.WriteLine($"You spent {duration} seconds on the {_activityName} activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            index = (index + 1) % spinner.Length;
        }
    }
}