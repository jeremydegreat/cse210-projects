using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class for all types of goals
public abstract class Goal
{
    public string Name { get; protected set; }
    public int Value { get; protected set; }

    // Constructor
    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    // Abstract method to record progress
    public abstract void RecordProgress();
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    public bool Completed { get; private set; }

    public SimpleGoal(string name, int value) : base(name, value)
    {
        Completed = false;
    }

    public override void RecordProgress()
    {
        if (!Completed)
        {
            Completed = true;
            Console.WriteLine($"Congratulations! You've completed the goal: {Name}. You've earned {Value} points.");
        }
        else
        {
            Console.WriteLine($"You've already completed the goal: {Name}.");
        }
    }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override void RecordProgress()
    {
        Console.WriteLine($"You've made progress towards the eternal goal: {Name}. You've earned {Value} points.");
    }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;

    public ChecklistGoal(string name, int value, int targetProgress) : base(name, value)
    {
        _currentProgress = 0;
        _targetProgress = targetProgress;
    }

    public override void RecordProgress()
    {
        _currentProgress++;
        if (_currentProgress < _targetProgress)
        {
            Console.WriteLine($"You've made progress towards the checklist goal: {Name}. You've earned {Value} points.");
        }
        else if (_currentProgress == _targetProgress)
        {
            Console.WriteLine($"Congratulations! You've completed the checklist goal: {Name}. You've earned {Value} points and a bonus.");
        }
        else
        {
            Console.WriteLine($"You've already completed the checklist goal: {Name}.");
        }
    }
}

// Class to manage user's goals and scores
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Add a new goal
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    // Record progress for a goal
    public void RecordProgress(string goalName)
    {
        var goal = _goals.FirstOrDefault(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordProgress();
            _score += goal.Value;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    // Display user's score
    public void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {_score} points.");
    }

    // Save goals and scores to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Value}");
            }
            writer.WriteLine($"Score,{_score}");
        }
    }

    // Load goals and scores from a file
    public void LoadFromFile(string filename)
    {
        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts[0] == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2])));
                }
                else if (parts[0] == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3])));
                }
                else if (parts[0] == "Score")
                {
                    _score = int.Parse(parts[1]);
                }
            }
        }
    }
// Show list of goals
public void ShowGoals()
{
    Console.WriteLine("Your goals:");
    foreach (var goal in _goals)
    {
        if (goal is SimpleGoal simpleGoal)
        {
            Console.WriteLine($"{(simpleGoal.Completed ? "[X]" : "[ ]")} {goal.Name}");
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            Console.WriteLine($"{(checklistGoal.Progress >= checklistGoal.Target ? "[X]" : "[ ]")} {goal.Name} - Completed {checklistGoal.Progress}/{checklistGoal.Target} times");
        }
        else
        {
            Console.WriteLine($"[ ] {goal.Name}");
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
        // Sample usage
        GoalManager goalManager = new GoalManager();
        goalManager.AddGoal(new SimpleGoal("Run a marathon", 1000));
        goalManager.AddGoal(new EternalGoal("Read scriptures", 100));
        goalManager.AddGoal(new ChecklistGoal("Attend the temple", 50, 10));

        goalManager.ShowGoals();

        goalManager.RecordProgress("Run a marathon");
        goalManager.RecordProgress("Read scriptures");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple");
        goalManager.RecordProgress("Attend the temple"); // Should trigger bonus

        goalManager.DisplayScore();

        goalManager.SaveToFile("goals.txt");

        // Clear goals and load from file
        goalManager = new GoalManager();
        goalManager.LoadFromFile("goals.txt");

        goalManager.ShowGoals();
        goalManager.DisplayScore();
    }
}
