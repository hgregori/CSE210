using System;
using System.Data;
using System.Threading;

class Breathing
{
    public void DisplayWelcomeMessageBreathing()
    {
        Console.WriteLine("Welcome to the Mindfulness Project! This class will guide you through mindful breathing exercises.");
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    public int GetBreathingDuration()
    {
        Console.Write("\nHow long in seconds would you like to do this activity? ");
        int duration = int.Parse(Console.ReadLine());
        return duration;
    }

    public void ShowSpinner(int seconds)
{
    char[] spinner = { '|', '/', '-', '\\' };
    int index = 0;

    DateTime endTime = DateTime.Now.AddSeconds(seconds);

    while (DateTime.Now < endTime)
    {
        Console.Write(spinner[index]);
        Thread.Sleep(1000); // Controls speed of animation
        Console.Write("\b"); // Erase previous character

        index = (index + 1) % spinner.Length;
    }
}
  public void StartBreathingActivity(int duration)
{
    Console.WriteLine("Get ready to start the breathing activity...");
    ShowSpinner(5); 

    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(duration);

    while (DateTime.Now < endTime)
    {
        Console.WriteLine("Breathe in...");
        ShowSpinner(5); 

        Console.WriteLine("Breathe out...");
        ShowSpinner(5);
    }

    Console.WriteLine("Great job! You've completed the breathing activity.");
    ShowSpinner(2);
    Console.Clear();
}
}