using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store video objects
        List<Video> videos = new List<Video>();

        // Create videos and add them to the list
        Video video1 = new Video("Introduction to C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Clear and concise."));

        Video video2 = new Video("Object-Oriented Programming", "Jane Smith", 1200);
        video2.AddComment(new Comment("David", "OOP makes coding so much easier."));
        video2.AddComment(new Comment("Eve", "I love the examples used!"));
        video2.AddComment(new Comment("Frank", "Can you cover interfaces next?"));

        Video video3 = new Video("How to Debug in Visual Studio", "Mike Johnson", 900);
        video3.AddComment(new Comment("Grace", "Debugging tips are life savers!"));
        video3.AddComment(new Comment("Hannah", "Very informative video."));
        video3.AddComment(new Comment("Ian", "This improved my coding skills!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Iterate through the list and display video information
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine(); // Add spacing between videos
        }
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in Comments)
        {
            Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
        }
    }
}

// Comment class
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}
