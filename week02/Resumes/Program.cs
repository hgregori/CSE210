using System;

namespace ResumeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main orchestrates the flow ONLY (no direct Console.ReadLine here).
            string name = PromptUserName();

            Console.WriteLine("Welcome to the Resume App.");

            Job job1 = new Job
            {
                _jobTitle = PromptUserString("Title of role 1: "),
                _company = PromptUserString("Company name 1: "),
                _startYear = PromptUserNumber("Start year 1: "),
                _endYear = PromptUserNumber("End year 1: ")
            };

            Job job2 = new Job
            {
                _jobTitle = PromptUserString("Title of role 2: "),
                _company = PromptUserString("Company name 2: "),
                _startYear = PromptUserNumber("Start year 2: "),
                _endYear = PromptUserNumber("End year 2: ")
            };

            Resume myResume = new Resume
            {
                _name = name
            };

            myResume._jobs.Add(job1);
            myResume._jobs.Add(job2);

            Console.WriteLine();
            myResume.Display();
        }

        // === Required by the assignment ===
        // Asks for and RETURNS the user's name (string).
        public static string PromptUserName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            // Optional: basic guard
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Invalid name. Enter your name: ");
                name = Console.ReadLine();
            }
            return name.Trim();
        }

        // Asks for and RETURNS a number (int).
        public static int PromptUserNumber(string prompt)
        {
            Console.Write(prompt);
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                Console.Write("Invalid value. " + prompt);
            }
        }

        // (Optional helper) Asks for and RETURNS a string with a prompt.
        public static string PromptUserString(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(value))
            {
                Console.Write("Empty input. " + prompt);
                value = Console.ReadLine();
            }
            return value.Trim();
        }
    }
}