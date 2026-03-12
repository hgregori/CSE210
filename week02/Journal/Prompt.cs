using System;
using System.Collections.Generic;

class Prompt
{
    private static string[] promptList = {
        "What was the most memorable part of your day? How did it make you feel? What did you learn from it?",
        "What are you grateful for today? List three things and explain why they are important to you.",
        "Describe a challenge you faced today and how you overcame it. What did you learn from the experience?",
        "Write about a moment of kindness you witnessed or experienced today. How did it impact you or others?",
        "Reflect on a goal you have for the future. What steps can you take to achieve it, and what motivates you to pursue it?"
        };

    private readonly Random random = new Random();
    public string GetRandomPrompt()
    {
        int index = random.Next(promptList.Length);
        return promptList[index];
    }
}

class Responses
{

    private static readonly List<string> _responseList = new List<string>();

    public void AddResponse(string response)
    {   
        if (!string.IsNullOrWhiteSpace(response))
        {
            _responseList.Add(response);
        }
    }

    public static List<string> GetResponses()
    {
        return new List<string>(_responseList);
    }
}