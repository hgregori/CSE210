using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program.");
        }
        
        static void PromptUserName(string name)
        {
            Console.WriteLine($"Your name is {name}.");
        }
    
        static void PromptUserNumber(int num)
        {
            Console.WriteLine($"Your favorite number is {num}.");
        }

        static int SquareNumber(int num)
        {
            int squared = num * num;
            return squared;
        }

        static void DisplayResult(string name, int num)
        {
            Console.WriteLine($"Name: {name} | Squared num: {num}");
        }

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Please enter your name: ");
        string favNum = Console.ReadLine();
        int num = int.Parse(favNum);

        DisplayWelcome();
        PromptUserName(name);
        PromptUserNumber(num);
        int squared = SquareNumber(num);
        DisplayResult(name, squared);

    }
}