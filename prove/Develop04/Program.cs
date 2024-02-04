using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    public string Activity_name { get; private set; }
    public string Activity_description { get; private set; }
    public int Activity_duration { get; private set; }

    public Activity(string name, string description, int duration)
    {
        Activity_name = name;
        Activity_description = description;
        Activity_duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"--- {Activity_name} ---");
        Console.WriteLine(Activity_description);
        Console.WriteLine($"Set duration (seconds): {Activity_duration}");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You've completed {Activity_name}.");
        Console.WriteLine($"Duration: {Activity_duration} seconds");
        Thread.Sleep(3000);
    }

    public void ShowSpinner(int seconds)
    {
        // Implement spinner animation (optional)
    }

    public void ShowCountDown(int seconds)
    {
        // Implement countdown animation (optional)
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity(int durationInSeconds) : base("Breathing Activity", "Clear your mind and focus on your breath.", durationInSeconds) { }

    public void Run()
    {
        DisplayStartingMessage();
        for (int i = Activity_duration; i >= 0; i--)
        {
            Console.WriteLine(i == 0 ? "Breathe in..." : i.ToString());
            Thread.Sleep(1000);
        }
        DisplayEndingMessage();
    }
}

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity(int durationInSeconds) : base("Listing Activity", "List as many positive things as you can.", durationInSeconds) { }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Think about the prompt...");
        Thread.Sleep(3000);
        // User can list items here (you can customize this part)
        _count = 10; // Example: assume 10 items were listed
        Console.WriteLine($"Number of items listed: {_count}");
        DisplayEndingMessage();
    }
}

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity(int durationInSeconds) : base("Reflecting Activity", "Reflect on times when you've shown strength and resilience.", durationInSeconds)
    {
        // Initialize prompts and questions (customize as needed)
        _prompts.Add("stood up for someone else");
        _prompts.Add("did something difficult");
        _prompts.Add("helped someone in need");
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("How did you feel when it was complete?");
    }

    public void Run()
    {
        DisplayStartingMessage();
        string selectedPrompt = GetRandomPrompt();
        Console.WriteLine($"Think of a time when you {selectedPrompt}.");
        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000);
        }
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Mindfulness Activities Program!");
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Listing Activity");
        Console.WriteLine("3. Reflecting Activity");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                new BreathingActivity(120).Run(); // 2 minutes duration
                break;
            case 2:
                new ListingActivity(240).Run(); // 4 minutes duration
                break;
            case 3:
                new ReflectingActivity(180).Run(); // 3 minutes duration
                break;
            default:
                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                break;
        }
    }
}
