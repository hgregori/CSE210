using System;

class Program
{
    static void Main(string[] args)
    {
        Student a1 = new Student("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        Math a2 = new Math("Roberto Rodriguez", "Fractions", 7.3, "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetProblem());

        Writing a3 = new Writing("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());

    }
}