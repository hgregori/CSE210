using System;
using System.Collections.Generic;

class Reflection : BaseActivity
{
    private List<string> _usedPrompts = new List<string>();
    private List<string> _usedQuestions = new List<string>();

    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What did you learn from this experience?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflection() : base("Reflection",
        "This activity will help you reflect on times when you showed strength.\nIt helps build confidence and resilience.")
    {
    }

    private string GetUniquePrompt()
    {
        if (_usedPrompts.Count == prompts.Length)
            _usedPrompts.Clear();

        Random rnd = new Random();
        string prompt;

        do { prompt = prompts[rnd.Next(prompts.Length)]; }
        while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }

    private string GetUniqueQuestion()
    {
        if (_usedQuestions.Count == questions.Length)
            _usedQuestions.Clear();

        Random rnd = new Random();
        string q;

        do { q = questions[rnd.Next(questions.Length)]; }
        while (_usedQuestions.Contains(q));

        _usedQuestions.Add(q);
        return q;
    }

    public void StartReflectionActivity()
    {
        int duration = StartActivity();

        string prompt = GetUniquePrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Take a moment to reflect...");
        ShowSpinner(10);

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string q = GetUniqueQuestion();
            Console.WriteLine($"\nQuestion: {q}");
            ShowSpinner(10);
        }

        EndActivity(duration);
    }
}