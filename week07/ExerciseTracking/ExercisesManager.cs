using System;
using System.Collections.Generic;
using System.IO;

public class ExercisesManager
{
    private List<Exercices> _exercises = new List<Exercices>();
    private string _filename = "traker.txt";

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Exercise Tracker Menu ---");
            Console.WriteLine("1. Add Running Activity");
            Console.WriteLine("2. Add Biking Activity");
            Console.WriteLine("3. Add Swimming Activity");
            Console.WriteLine("4. Display Activities (Current Session)");
            Console.WriteLine("5. Save and Quit");
            Console.Write("Select an option: ");
            
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddRunning();
                    break;
                case "2":
                    AddBiking();
                    break;
                case "3":
                    AddSwimming();
                    break;
                case "4":
                    DisplayActivities();
                    break;
                case "5":
                    SaveActivities();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private string GetValidDate()
    {
        while (true)
        {
            Console.Write("Enter the date (e.g. 03 Nov 2022): ");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime parsedDate))
            {
                return parsedDate.ToString("dd MMM yyyy");
            }
            Console.WriteLine("Invalid date format. Please try again.");
        }
    }

    private void AddRunning()
    {
        string date = GetValidDate();
        Console.Write("Enter length in minutes: ");
        if (int.TryParse(Console.ReadLine(), out int minutes))
        {
            Console.Write("Enter distance in miles: ");
            if (double.TryParse(Console.ReadLine(), out double distance))
            {
                _exercises.Add(new Running(date, minutes, distance));
                Console.WriteLine("Running activity added successfully!");
                return;
            }
        }
        Console.WriteLine("Invalid input. Activity not added.");
    }

    private void AddBiking()
    {
        string date = GetValidDate();
        Console.Write("Enter length in minutes: ");
        if (int.TryParse(Console.ReadLine(), out int minutes))
        {
            Console.Write("Enter speed in mph: ");
            if (double.TryParse(Console.ReadLine(), out double speed))
            {
                _exercises.Add(new Biking(date, minutes, speed));
                Console.WriteLine("Biking activity added successfully!");
                return;
            }
        }
        Console.WriteLine("Invalid input. Activity not added.");
    }

    private void AddSwimming()
    {
        string date = GetValidDate();
        Console.Write("Enter length in minutes: ");
        if (int.TryParse(Console.ReadLine(), out int minutes))
        {
            Console.Write("Enter number of laps (50 meters each): ");
            if (int.TryParse(Console.ReadLine(), out int laps))
            {
                _exercises.Add(new Swimming(date, minutes, laps));
                Console.WriteLine("Swimming activity added successfully!");
                return;
            }
        }
        Console.WriteLine("Invalid input. Activity not added.");
    }

    private void DisplayActivities()
    {
        Console.WriteLine("\n--- Activities Recorded This Session ---");
        if (_exercises.Count == 0)
        {
            Console.WriteLine("No activities recorded yet.");
            return;
        }

        foreach (var exercise in _exercises)
        {
            Console.WriteLine(exercise.GetSummary());
        }
    }

    private void SaveActivities()
    {
        // Appends to the file to keep a continuous tracker for the gym staff
        using (StreamWriter outputFile = new StreamWriter(_filename, true))
        {
            foreach (var exercise in _exercises)
            {
                outputFile.WriteLine(exercise.GetSummary());
            }
        }
        Console.WriteLine($"\nActivities successfully saved to {_filename}.");
        Console.WriteLine("Goodbye!");
    }
}
