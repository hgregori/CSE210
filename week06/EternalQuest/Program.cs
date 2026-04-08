using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("\nWelcome to Eternal Quest!");
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("\nYour adventure begins now...");
        System.Threading.Thread.Sleep(3000);
        Console.Clear();   
     
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    
    }
}