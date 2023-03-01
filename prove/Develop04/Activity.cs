class Activity
{
    private string _activityName;
    private string _description;
    private int _duration;
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        Activity.SpinnerAnimation(4);
        Console.WriteLine();
        Console.WriteLine();
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        Activity.SpinnerAnimation(4);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_activityName}.");
        Activity.SpinnerAnimation(4);
    }
    /*
        In this method I decided to use the a parameter to determine how much time in seconds the spinner animation will run.
    */
    public static void SpinnerAnimation(int time)
    {
        int i = 0;
        string[] arr = { "|", "/", "-", @"\" };
        for (int _ = 0; _ < time * 2; _++)
        {
            Console.Write(arr[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            if (++i > 3) i = 0;
        }
    }
    public int GetDuration()
    {
        return _duration;
    }
    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }
}