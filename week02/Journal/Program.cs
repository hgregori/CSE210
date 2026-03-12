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

                    var entries = Responses.GetResponses();
                    Saving.SaveTxtWithPipeSeparator(fileName, entries);
                    break;

                case 4:

                    Console.Write("\nEnter a TXT file name to load (e.g., journal.txt): ");
                    fileName = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        Console.WriteLine("\n⚠️ File name cannot be empty.");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(Path.GetExtension(fileName)))
                    {
                        fileName = Path.ChangeExtension(fileName, ".txt");
                    }

                    var loaded = Loading.LoadTxtWithPipeSeparator(fileName);
                    Responses.LoadResponses(loaded);
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
   
    }
}