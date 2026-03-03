using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();
        int numb = -1;
         
         do
        {
            Console.Write("Write a number(0 to stop): ");
            string num = Console.ReadLine();
            numb = int.Parse(num);
            if (numb != 0)
            {
                numbers.Add(numb);
            }
        } while (numb != 0);

        int total = 0;
        int max = numbers[0];

        foreach (int number in numbers)
        {
            total += number;
            if (number > max)
            {
                max = number;
            }
        }

        float average = total/numbers.Count;

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

    }
}