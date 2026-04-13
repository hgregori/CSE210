using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Exercise Tracking App!");
        ExercisesManager manager = new ExercisesManager();
        manager.Start();
    }
}