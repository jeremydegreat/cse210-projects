using System;
using System.Collections.Generic;
using System.IO;

// Entry class to represent a journal entry
class Entry
{
    // Properties
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // Constructor
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

// Journal class to manage entries
class Journal
{
    // Field
    private List<Entry> entries;

    // Constructor
    public Journal()
    {
        entries = new List<Entry>();
    }

    // Method to add an entry to the journal
    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    // Method to display all entries in the journal
    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
        }
    }

    // Method to save the journal to a file
    public void SaveToFile(string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    // Method to load the journal from a file
    public void LoadFromFile(string fileName)
    {
        entries.Clear();
        using (StreamReader sr = new StreamReader(fileName))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[1], parts[2], parts[0]);
                    entries.Add(entry);
                }
            }
        }
    }
}

// Program class to handle user interactions
class Program
{
    // Main method
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string prompt = GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Entry newEntry = new Entry(prompt, response, date);
                    journal.AddEntry(newEntry);
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    Console.Write("Enter file name to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case 4:
                    Console.Write("Enter file name to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Helper method to get a random prompt
    static string GetRandomPrompt()
    {
        // Add more prompts as needed
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Random random = new Random();
        return prompts[random.Next(prompts.Length)];
    }
}
