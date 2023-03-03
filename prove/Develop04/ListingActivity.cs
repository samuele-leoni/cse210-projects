class ListingActivity : PromptActivity
{
    private List<string> _responses;
    private bool running = false;
    private const string _activityName = "Listing Activity";
    private const string _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    private static string[] _prompts = { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };
    public void Countdown()
    {
        for (int i = GetDuration(); i > 0; i--)
        {
            Thread.Sleep(1000);
        }
        running = false;
    }
    public override void DisplayPrompt()
    {
        Console.WriteLine("List as many responses you can to the following prompt:");
        base.DisplayPrompt();
        StartingCountdown();
    }
    public void DisplayListingActivity()
    {
        running = true;
        Thread t = new(Countdown);
        t.Start();
        Console.WriteLine();
        while (running)
        {
            Console.Write("> ");
            _responses.Add(Console.ReadLine());
        }
        Console.WriteLine($"You listed {GetNumberOfItems()} items!");
        Console.WriteLine();
    }
    public int GetNumberOfItems()
    {
        return _responses.Count;
    }
    public ListingActivity() : base(_activityName, _description, _prompts)
    {
        _responses = new();
    }
}