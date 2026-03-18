using System;

public class Prompt
{
    private static readonly string[] _promptList =
    {
        "What was the most memorable part of your day? How did it make you feel? What did you learn from it?",
        "What are you grateful for today? List three things and explain why they are important to you.",
        "Describe a challenge you faced today and how you overcame it. What did you learn from the experience?",
        "Write about a moment of kindness you witnessed or experienced today. How did it impact you or others?",
        "Reflect on a goal you have for the future. What steps can you take to achieve it, and what motivates you to pursue it?"
    };

    private readonly Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_promptList.Length);
        return _promptList[index];
    }
}