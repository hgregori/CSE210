using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _Goals;
    private int _TotalPoints;

    public GoalManager()
    {
        _Goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        _Goals.Add(goal);
    }

    public List<Goal> GetGoals()
    {
        return _Goals;
    }

    public void Start()
    {
        int Option = 0;
        do {
            Console.WriteLine("\nCurrent Total Points: " + GetTotalPoints());
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect an option: ");
            Option = int.Parse(Console.ReadLine());

            switch (Option)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    RecordEvent();
                    break;
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
                    break;
                case 6:
                    Console.WriteLine("Thank you for playing Eternal Quest! Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        } while (Option != 6);
    }

    public int GetTotalPoints()
    {
        return _TotalPoints;
    }
    public void AddPoints(int points)
    {
        _TotalPoints += points;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Total Points: {_TotalPoints}");
    }
    public void ListGoalNames()
    {
        
    }

    public void ListGoalDetails()
    {
    for (int i = 0; i < _Goals.Count; i++)
    {
        string status = _Goals[i].IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_Goals[i].GetDetailString()}");
    }
    }


    public void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Back to Main Menu");
        Console.Write("\nEnter your choice: "); 
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            AddGoal(new SimpleGoal(name, description, points));
        }
        else if (choice == 2)
        {
            AddGoal(new EternalGoal(name, description, points));
        }
        else if (choice == 3)
        {
            Console.Write("Enter the number of times to complete the checklist: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points for completing the checklist: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
        }
        else if (choice == 4)
        {
            // Do nothing, return to main menu
        }
        else
        {
            Console.WriteLine("Invalid choice. Goal not created.");
        }
    }

   public void RecordEvent()
{
    Console.WriteLine("Choose a goal:");
    for (int i = 0; i < _Goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_Goals[i].GetGoalName()}");
    }

    int index = int.Parse(Console.ReadLine()) - 1;

    Goal goal = _Goals[index];
    goal.RecordEvent();

    int earned = goal.GetPoints();
    _TotalPoints += earned;

    Console.WriteLine($"You earned {earned} points!");
    }

    public void SaveGoals()
    {
        Console.WriteLine("\nEnter the file path to save goals:");
        string filePath = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(_TotalPoints); // Save total points at the beginning of the file
            foreach (Goal goal in _Goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine("\nEnter the file path to load goals:");

        string filePath = Console.ReadLine();
        if (File.ReadAllLines(filePath).Length == 0)
        {
            Console.WriteLine("The file is empty. No goals loaded.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        _TotalPoints = int.Parse(lines[0]); // Load total points from the first line of the file
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                if (isComplete)
                {
                    simpleGoal.RecordEvent();
                }
                AddGoal(simpleGoal);
            }
            else if (goalType == "EternalGoal")
            {
                AddGoal(new EternalGoal(name, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                int timesCompleted = int.Parse(parts[4]);
                int timesToComplete = int.Parse(parts[5]);
                int bonusPoints = int.Parse(parts[6]);
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, timesToComplete, bonusPoints);
                for (int j = 0; j < timesCompleted; j++)
                {
                    checklistGoal.RecordEvent();
                }
                AddGoal(checklistGoal);
            }
        }
    }
}