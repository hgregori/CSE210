using System;

class Reflection
{
    public void DisplayWelcomeMessageReflection()
    {
        Console.WriteLine("Welcome to the Mindfulness Project! This class will guide you through mindful reflection exercises.");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }

    public string GetRandomPrompt()
    {
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }

    public string GetRandomQuestion()
    {
        string[] questions = {
            "What did you learn from this experience?",
            "How did this experience shape who you are today?",
            "What strengths did you use during this experience?",
            "How can you apply what you learned from this experience to other areas of your life?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        Random random = new Random();
        int index = random.Next(questions.Length);
        return questions[index];
    }

    public int GetReflectionDuration()
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
        Thread.Sleep(1000); 
        Console.Write("\b \b"); 

        index = (index + 1) % spinner.Length;
    }
}

public void StartReflectionActivity(int duration)
{
    string prompt = GetRandomPrompt();
    Console.WriteLine($"\nYour prompt is: {prompt}");
    Console.WriteLine("\nTake a moment to reflect on this prompt and think about your answer.");

    // Spinner during initial reflection time
    ShowSpinner(10);

    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(duration);

    while (DateTime.Now < endTime)
    {
        string question = GetRandomQuestion();
        Console.WriteLine($"\nNow, consider the following question: {question}");
        Console.WriteLine("Take a moment to reflect on this question and think about your answer.");
        ShowSpinner(10);
    }

    Console.WriteLine("\nReflection activity completed!");
    ShowSpinner(2);
}

}