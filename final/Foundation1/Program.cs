using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment comment = new Comment(commenterName, text);
        comments.Add(comment);
    }

    public int GetNumComments()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length: " + Length + " seconds");
        Console.WriteLine("Number of Comments: " + GetNumComments());
        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            Console.WriteLine($"\t{comment.CommenterName}: {comment.Text}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Title1", "Author1", 120);
        video1.AddComment("User1", "Comment1-1");
        video1.AddComment("User2", "Comment1-2");
        video1.AddComment("User3", "Comment1-3");
        videos.Add(video1);

        Video video2 = new Video("Title2", "Author2", 180);
        video2.AddComment("User4", "Comment2-1");
        video2.AddComment("User5", "Comment2-2");
        video2.AddComment("User6", "Comment2-3");
        videos.Add(video2);

        // Add more videos and comments if needed

        foreach (Video video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine();
        }
    }
}
