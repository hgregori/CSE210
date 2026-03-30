using System;

class Listening
{
    public void DisplayWelcomeMessageListening()
    {
        Console.WriteLine("Welcome to the Mindfulness Project! This class will guide you through mindful listening exercises.");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. This will help you recognize the good things in your life and how they can help you in other aspects of your life.");
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
    public string GetARandomPrompt()
    {
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }

    public int GetListeningDuration()
    {
        Console.Write("\nHow long in seconds would you like to do this activity? ");
        int duration = int.Parse(Console.ReadLine());
        return duration;
    }

    public void StartListeningActivity(int duration)
    {
        Console.WriteLine("Get ready to start the listening activity...");
        ShowSpinner(5); 

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Reflect upon: {0}", GetARandomPrompt());
            ShowSpinner(10); 
        }

        Console.WriteLine("Great job! You've completed the listening activity.");
        ShowSpinner(2);
        Console.Clear();
    }
}
