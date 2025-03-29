// Comment.cs
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }
    
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video.cs
using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    public List<Comment> Comments { get; set; }
    
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
}

// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Creating 3 videos
        Video video1 = new Video("C# Basics", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I finally understand this topic!"));

        Video video2 = new Video("Advanced C#", "Jane Smith", 1200);
        video2.AddComment(new Comment("Dave", "This is exactly what I needed!"));
        video2.AddComment(new Comment("Eve", "Well-structured and clear."));
        video2.AddComment(new Comment("Frank", "Could you cover more on LINQ?"));

        Video video3 = new Video("C# Design Patterns", "Emily Johnson", 900);
        video3.AddComment(new Comment("Grace", "Awesome content!"));
        video3.AddComment(new Comment("Hank", "Very insightful, learned a lot."));
        video3.AddComment(new Comment("Ivy", "Best video on this topic!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying all videos and their comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }
            
            Console.WriteLine();
        }
    }
}
