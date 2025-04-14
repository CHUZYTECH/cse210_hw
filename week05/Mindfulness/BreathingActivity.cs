using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding you through slow breathing.";
    }

    protected override void PerformActivity()
    {
        int cycles = _duration / 8;
        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in... ");
            ShowBreathAnimation(4);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowBreathAnimation(4);
            Console.WriteLine();
        }
    }

    private void ShowBreathAnimation(int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            Console.Write("*");
            Thread.Sleep(1000);
        }
        Console.Write("\b \b");
    }
}
