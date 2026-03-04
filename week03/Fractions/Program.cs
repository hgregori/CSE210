using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fra1 = new Fraction();
        Console.WriteLine(fra1.GetFractionString());
        Console.WriteLine(fra1.GetDecimalValue());

        Fraction fra2 = new Fraction(5);
        Console.WriteLine(fra2.GetFractionString());
        Console.WriteLine(fra2.GetDecimalValue());

        Fraction fra3 = new Fraction(3, 4);
        Console.WriteLine(fra3.GetFractionString());
        Console.WriteLine(fra3.GetDecimalValue());

        Fraction fra4 = new Fraction(1, 3);
        Console.WriteLine(fra4.GetFractionString());
        Console.WriteLine(fra4.GetDecimalValue());
    }
}