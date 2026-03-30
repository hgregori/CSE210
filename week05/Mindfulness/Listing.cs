using System;
using System.Collections.Generic;

class Listing : BaseActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Listing() : base("Listing",
        "This activity will help you reflect on the good things in your life by listing items.")
    {
    }

    public void StartListingActivity()
    {
        int duration = StartActivity();

        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Length)];

        Console.WriteLine($"\nList as many responses as you can to:");
        Console.WriteLine($"→ {prompt}");

        Console.WriteLine("\nYou may begin in:");
        ShowSpinner(5);

        List<string> responses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                responses.Add(item);
            }
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        EndActivity(duration);
    }
}