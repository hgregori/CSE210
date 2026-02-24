using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        string answer = "yes";

        do {
            Console.Write("What is the magic number? ");
            string magicNumber = Console.ReadLine();
            int number = int.Parse(magicNumber);

            Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                int guessed = int.Parse(guess);

            int count = 0;

            do
            {
                count += 1;

                if (guessed < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guessed > number)
                {
                    Console.WriteLine("Lower");
                } 
                else if (guessed == number)
                {
                    Console.WriteLine("You guessed the number! Congratulations!");
                }

                Console.Write("What is your guess? ");
                guess = Console.ReadLine();
                guessed = int.Parse(guess);

            } while (number != guessed); 
                Console.WriteLine($"You took {count} guesses to find the number.");

                count = 0;

            Console.Write("Would you like to play again? ");
            answer = Console.ReadLine();

        } while (answer == "yes"); 
    }
}