using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!\n\nWhich scripture would you like to memorize?");
        Console.WriteLine("Please first, What is the reference?");
        string reference = Console.ReadLine();
        Console.WriteLine("Please enter the scripture text:");
        string text = Console.ReadLine();
        Scripture scripture = new Scripture(reference, new string[] { text });
        Console.Clear();
        do
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide a word, or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            } 
            scripture.HideRandomWord(1);
            Console.Clear();
            scripture.GetDisplayText();
        } while (!scripture.IsCompletelyHidden());
    }
}