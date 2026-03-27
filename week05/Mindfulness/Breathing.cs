using System;
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
        Console.Write("How long would you like to do this activity? ");
        int duration = int.Parse(Console.ReadLine());
        return duration;
    }

    public void StartBreathingActivity(int duration)
    {
        Console.WriteLine("Get ready to start the breathing activity...");
        Thread.Sleep(5000); // Pause for 5 seconds before starting

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(5000); // Breathe in for 5 seconds
            // Console.Write("|");
            // for (int j = 0; j < 5; j++)
            // {
            //     Console.Write("|");
            //     Thread.Sleep(500); // Pause for 0.5 seconds between each | character
            //     Console.Write("\b \b"); // Erase the | character
            //     Console.Write("/");
            //     Thread.Sleep(500);
            //     Console.Write("\b \b"); // Erase the | character
            //     Console.Write("-");
            //     Thread.Sleep(500);
            //     Console.Write("\b \b"); // Erase the | character
            //     Console.Write("\");
            // }
            
            Console.WriteLine("Breathe out...");
            Thread.Sleep(5000); // Breathe out for 5 seconds
        }

        Console.WriteLine("Great job! You've completed the breathing activity.");
        Thread.Sleep(2000); // Pause for 2 seconds before ending the activity
    }
}