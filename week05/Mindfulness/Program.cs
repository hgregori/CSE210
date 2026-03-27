using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Breathing breathingActivity = new Breathing();
        breathingActivity.DisplayWelcomeMessageBreathing();
        int breathingDuration = breathingActivity.GetBreathingDuration();
        breathingActivity.StartBreathingActivity(breathingDuration);
    }
}