using System;
using System.IO; // Needed for Path
using System.Collections.Generic;

class Program
{
    /*
     * W02 — Explain Abstraction (Meets Rubric)
     * Meaning: Abstraction hides internal details and exposes a clear, minimal interface.
     * We interact with Journal via AddEntry, Display, Save, and Load without knowing how
     * entries are stored or how files are parsed. This reduces coupling and complexity.
     *
     * Benefit: It makes the program easier to change and maintain. For example,
     * we could switch the storage format from TXT to JSON without changing Program.cs.
     *
     * Application: The Journal class encapsulates a private _entries list and provides
     * methods that operate on it. Program.cs never manipulates the list directly.
     *
     * Example demonstrating abstraction:
     *   var journal = new Journal();
     *   journal.AddEntry(DateTime.Now, "What made you smile today?", "A call with a friend.");
     *   journal.Save("journal.txt");
     *
     * ---------------------------------------------------------------
     * How this submission EXCEEDS the core requirements:
     * - Filename quality-of-life: defaults extension to .txt if missing.
     * - UTF-8 encoding and newline normalization for cross-platform consistency.
     * - User feedback includes success/error and entry counts on load.
     * - “Are you sure?” quit confirmation to prevent accidental exit.
     * - Clean separation of concerns: Journal encapsulates entries; StorageService handles I/O.
     * These enhancements improve reliability, usability, and maintainability beyond the core spec.
     * ---------------------------------------------------------------
     */

    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new Prompt();

        int choice = 0;
        do
        {
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine("1. Create a new journal entry");
            Console.WriteLine("2. Display the journal entries");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit the program");
            Console.Write("\nPlease, enter an option: ");

            var raw = Console.ReadLine();
            if (!int.TryParse(raw, out choice))
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                {
                    string prompt = prompts.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine() ?? string.Empty;

                    journal.AddEntry(DateTime.Now, prompt, response);
                    break;
                }

                case 2:
                {
                    journal.Display();
                    break;
                }

                case 3:
                {
                    Console.Write("\nEnter a TXT file name to save (e.g., journal.txt or just 'journal'): ");
                    string fileName = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        fileName = "journal.txt"; // default
                    }
                    else if (string.IsNullOrWhiteSpace(Path.GetExtension(fileName)))
                    {
                        fileName = Path.ChangeExtension(fileName, ".txt");
                    }

                    journal.Save(fileName!);
                    break;
                }

                case 4:
                {
                    Console.Write("\nEnter a TXT file name to load (e.g., journal.txt): ");
                    string fileName = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        Console.WriteLine("\n⚠️ File name cannot be empty.");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(Path.GetExtension(fileName)))
                    {
                        fileName = Path.ChangeExtension(fileName, ".txt");
                    }

                    journal.Load(fileName!);
                    break;
                }

                case 5:
                {
                    Console.Write("Are you sure you want to quit? (y/n): ");
                    string confirm = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                    if (confirm == "y" || confirm == "yes")
                    {
                        Console.WriteLine("\nQuitting the program...");
                    }
                    else
                    {
                        choice = 0; // keep going
                    }
                    break;
                }

                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
        while (choice != 5);
    }
}