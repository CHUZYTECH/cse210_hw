using System;

// Abstract base class for Video
abstract class Video
{
    public abstract void Play();
    public abstract void Like();
    public abstract string GetDetails();
}

// Concrete class implementing Video
class YouTubeVideo : Video
{
    private string title;
    private int duration;
    private int views;
    private int likes;

    public YouTubeVideo(string title, int duration)
    {
        this.title = title;
        this.duration = duration;
        this.views = 0;
        this.likes = 0;
    }

    public override void Play()
    {
        views++;
        Console.WriteLine($"Playing '{title}' ({duration} mins). Views: {views}");
    }

    public override void Like()
    {
        likes++;
        Console.WriteLine($"Liked '{title}'. Total Likes: {likes}");
    }

    public override string GetDetails()
    {
        return $"Title: {title}, Duration: {duration} mins, Views: {views}, Likes: {likes}";
    }
}

// Main Program
class Program
{
    static void Main()
    {
        YouTubeVideo video1 = new YouTubeVideo("Introduction to OOP", 10);
        video1.Play();
        video1.Like();
        Console.WriteLine(video1.GetDetails());
    }
}
