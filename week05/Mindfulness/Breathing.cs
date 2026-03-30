using System;

class Breathing : BaseActivity
{
    public Breathing() : base("Breathing",
        "This activity will help you relax by guiding you through slow, mindful breathing.\nClear your mind and focus on your breath.")
    {
    }

    public void StartBreathingActivity()
    {
        int duration = StartActivity();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            ShowSpinner(5);

            Console.WriteLine("Breathe out...");
            ShowSpinner(5);
        }

        EndActivity(duration);
    }
}