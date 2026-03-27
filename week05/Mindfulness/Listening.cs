using System;

class Listening
{
    public void DisplayWelcomeMessageListening()
    {
        Console.WriteLine("Welcome to the Mindfulness Project! This class will guide you through mindful listening exercises.");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. This will help you recognize the good things in your life and how they can help you in other aspects of your life.");
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

    
}
