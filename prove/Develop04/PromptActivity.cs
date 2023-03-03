class PromptActivity : Activity
{
    private string[] _prompts;
    public string GetRandomPrompt()
    {
        Random rand = new();
        return _prompts[rand.Next(_prompts.Count())];
    }
    public virtual void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine();
        
    }
    public void StartingCountdown()
    {
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public PromptActivity(string activityName, string description, string[] prompts) : base(activityName, description)
    {
        _prompts = prompts;
    }
}