using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the YouTube Videos Project!");
        Console.WriteLine();

        // Create a list of videos
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video v1 = new Video("How to Cook Pasta", "Chef Gordon", 300, new Date(15, 8, 2023));
        v1.AddComment(new Comment("Alice", "This was so helpful!"));
        v1.AddComment(new Comment("Bob", "I love pasta!"));
        v1.AddComment(new Comment("Carla", "Great explanation!"));
        videos.Add(v1);

        // --- Video 2 ---
        Video v2 = new Video("Learn C# in 10 Minutes", "Tech Academy", 600, new Date(20, 9, 2023));
        v2.AddComment(new Comment("Henrique", "Very clear tutorial!"));
        v2.AddComment(new Comment("Carlos", "I learned a lot, thanks!"));
        v2.AddComment(new Comment("Mia", "Can you make one about classes?"));
        videos.Add(v2);

        // --- Video 3 ---
        Video v3 = new Video("Top 10 Travel Destinations", "WanderWorld", 480, new Date(5, 10, 2023));
        v3.AddComment(new Comment("Luis", "I want to go to all of them!"));
        v3.AddComment(new Comment("Ana", "Amazing list!"));
        v3.AddComment(new Comment("Sofia", "I just booked my trip to Brazil!"));
        videos.Add(v3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}