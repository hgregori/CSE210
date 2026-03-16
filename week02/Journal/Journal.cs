using System;
using System.Collections.Generic;

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(DateTime date, string prompt, string response)
    {
        if (string.IsNullOrWhiteSpace(prompt) && string.IsNullOrWhiteSpace(response))
            return;

        _entries.Add(new Entry(date, prompt, response));
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries yet.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"\nEntry #{i + 1}");
            Console.WriteLine(_entries[i].ToString());
            Console.WriteLine(new string('-', 40));
        }
        Console.WriteLine();
    }

    public void Save(string filePath)
    {
        var serialized = new List<string>(_entries.Count);
        foreach (var e in _entries)
            serialized.Add(e.ToString());

        StorageService.SaveTxtWithPipeSeparator(filePath, serialized);
    }

    public void Load(string filePath)
    {
        var loaded = StorageService.LoadTxtWithPipeSeparator(filePath);
        _entries.Clear();

        foreach (var blob in loaded)
        {
            var date = DateTime.Now;
            string prompt = string.Empty;
            string response = blob;

            try
            {
                var lines = blob.Replace("\r\n", "\n").Split('\n');
                if (lines.Length > 0 && lines[0].StartsWith("Date: "))
                {
                    var first = lines[0];
                    int promptIdx = first.IndexOf(" - Prompt: ", StringComparison.OrdinalIgnoreCase);
                    if (promptIdx >= 0)
                    {
                        string datePart = first.Substring("Date: ".Length, promptIdx - "Date: ".Length).Trim();
                        string promptPart = first.Substring(promptIdx + " - Prompt: ".Length).Trim();

                        DateTime parsed;
                        if (DateTime.TryParse(datePart, out parsed))
                            date = parsed;

                        prompt = promptPart;
                    }
                }

                if (lines.Length > 1 && lines[1].StartsWith("- Response: "))
                {
                    response = lines[1].Substring("- Response: ".Length).Trim();
                }
            }
            catch
            {
                // Fallback: keep default parsing
            }

            _entries.Add(new Entry(date, prompt, response));
        }
    }
}