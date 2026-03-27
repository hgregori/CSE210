using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("\nHello World! This is the Mindfulness Project.");
        Console.WriteLine("This project will help you practice mindfulness and reflection through various activities. Let's get started!");
        
        int choice = 0;
        do
        {
            choice = DisplayMenu();
            switch (choice)
            {
                case 1:
                    Breathing breathingActivity = new Breathing();
                    breathingActivity.DisplayWelcomeMessageBreathing();
                    int duration = breathingActivity.GetBreathingDuration();
                    breathingActivity.StartBreathingActivity(duration);
                    break;
                case 2:
                    Listening listeningActivity = new Listening();
                    listeningActivity.DisplayWelcomeMessageListening();
                    string prompt = listeningActivity.GetARandomPrompt();
                    Console.WriteLine($"\nYour prompt is: {prompt}");
                    Console.WriteLine("Take a moment to reflect on this prompt and think about your answer.");
                    break;
                case 3:
                    Reflection reflectionActivity = new Reflection();
                    reflectionActivity.DisplayWelcomeMessageReflection();
                    Console.WriteLine("\nTake a moment to reflect on a time in your life when you showed strength and resilience. Think about how you overcame challenges and what you learned from that experience.");
                    break;
                case 4:
                    Console.WriteLine("Thank you for participating in the Mindfulness Project! Remember to take time for yourself and practice mindfulness regularly. Have a great day!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }

        } while (choice != 4);
    }

    public static int DisplayMenu()
    {
        Console.WriteLine("\nPlease select an activity:");
        Console.WriteLine("1. Breathing Exercise");
        Console.WriteLine("2. Listening Exercise");
        Console.WriteLine("3. Reflection Exercise");
        Console.Write("4. Exit\n");
        Console.Write("Enter the number of your choice: ");
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }
}