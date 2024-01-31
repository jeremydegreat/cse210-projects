using System;
using System.Collections.Generic;

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (StartVerse == EndVerse)
            return $"{Book} {Chapter}:{StartVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

public class Word
{
    private string Text { get; }
    private bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        return IsHidden ? "****" : Text;
    }
}

public class Scripture
{
    private Reference Reference { get; }
    private List<Word> Words { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = new List<Word>();

        foreach (var word in text.Split(' '))
        {
            Words.Add(new Word(word));
        }
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(Words.Count);
        Words[index].Hide();
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", Words.ConvertAll(word => word.GetDisplayText()));
        string result = $"{Reference.GetDisplayText()}: {scriptureText}";
        Console.WriteLine(result);
        return result;
    }
}

class Program
{
    static void Main()
    {
        Reference john316Ref = new Reference("John", 3, 16, 16);

        Scripture john316 = new Scripture(john316Ref, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            Console.Clear();
            string displayText = john316.GetDisplayText();  // Store the display text in a variable
            Console.WriteLine(displayText);  // Display the current text

            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            john316.HideRandomWord();
        }
    }
}
