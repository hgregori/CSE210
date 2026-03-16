using System;

public class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(DateTime date, string prompt, string response)
    {
        Date = date.ToShortDateString();
        Prompt = prompt ?? string.Empty;
        Response = response ?? string.Empty;
    }

    public override string ToString()
    {
        return $"Date: {Date} - Prompt: {Prompt}\n- Response: {Response}";
    }
}