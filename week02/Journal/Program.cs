using System;
using System.Data;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        // Create a prompt from the list I create and save the response with the data an teh response
        int answer = 0;
        do
        {
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine("1. Create a new journal entry");
            Console.WriteLine("2. Display the journal entries");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit the program");
            Console.Write("\nPlease, enter an option: ");
            answer = int.Parse(Console.ReadLine());
             switch (answer)
            {
                case 1:
                    string prompt = new Prompt().GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    DateTime theCurrentTime = DateTime.Now;
                    string dateText = theCurrentTime.ToShortDateString();
                    string journalEntry = $"Date: {dateText} - Prompt: {prompt}\n- Response: {response}";
                    Responses responses = new Responses();
                    responses.AddResponse(journalEntry);
                    break;
                case 2:
                var responseList = Responses.GetResponses();

                if (responseList.Count == 0)
                {
                    Console.WriteLine("\nNo entries yet.");
                }
                else
                {
                    Console.WriteLine("\n--- Journal Entries ---");
                    for (int i = 0; i < responseList.Count; i++)
                    {
                        Console.WriteLine($"\nEntry #{i + 1}");
                        Console.WriteLine(responseList[i]);
                        Console.WriteLine(new string('-', 40));
                    }
                    Console.WriteLine("\n");
                }
                break;
                case 3:
                    
                Console.Write("\nEnter a filename to save (e.g., journal.txt): ");
                string? filename = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(filename))
                {
                    Console.WriteLine("Invalid filename.");
                    break;
                }
                var responseList = Responses.GetResponses();
                try
                {
                    System.IO.File.WriteAllLines(filename, responseList);
                    Console.WriteLine($"Saved {responseList.Count} entries to '{filename}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving file: {ex.Message}");
                }
                break;

                case 4:    
                Console.Write("\nEnter a filename to load (e.g., journal.txt): ");
                string? filename = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(filename))
                {
                    Console.WriteLine("Invalid filename.");
                    break;
                }

                if (!System.IO.File.Exists(filename))
                {
                    Console.WriteLine("File not found.");
                    break;
                }

                try
                {
                    var lines = System.IO.File.ReadAllLines(filename);
                    // If your Responses class only has Add via constructor:
                    foreach (var line in lines)
                    {
                        new Responses(line);
                    }
                    Console.WriteLine($"Loaded {lines.Length} entries from '{filename}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading file: {ex.Message}");
                }
                break;
                case 5:
                    Console.Write("Are you sure you want to quit? (y/n): ");
                    string confirm = Console.ReadLine().ToLower();
                    if (confirm == "y")
                    {
                        Console.WriteLine("\nQuitting the program...");
                    } else
                    {
                        answer = 0; // Reset answer to continue the loop
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
        while (answer != 5);
        // Display the journal entry with the prompt, response, and date on the console
        
        // Save tge journal to a file, ask the user for a filename to save the journal to, and then save the journal to that file.



        // Load the journal from a file, ask the user for a filename to load the journal from, and then load the journal from that file and display the entries on the console.



        // Create a menu that allows the user to choose to create a new journal entry, display the journal entries, save the journal to a file, load the journal from a file, or quit the program.



        // The list must contain at least 5 prompts, and the user should be able to choose a random prompt from the list when creating a new journal entry.



        // The interface should follow the example in

   
    }
}