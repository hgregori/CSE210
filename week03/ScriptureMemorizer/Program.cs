using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!\n");

        Console.Write("What is the scripture reference? ");
        string referenceInput = Console.ReadLine();

        Console.Write("Enter the scripture text: ");
        string text = Console.ReadLine();

        Reference reference = Reference.FromString(referenceInput);
        Scripture scripture = new Scripture(reference, text);

        Console.Clear();

        string input;
        do
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
            input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(1);
            Console.Clear();

        } while (!scripture.IsCompletelyHidden());

        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden — program ending.");
    }
}



