class ReflectionActivity : PromptActivity
{
    private const string _activityName = "Reflection Activity";
    private const string _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    private static string[] _prompts = { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    private List<string> _questions = new() { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

    public string GetRandomQuestion()
    {
        Random rand = new();
        int idx = rand.Next(_questions.Count);
        string s = _questions[idx];
        _questions.RemoveAt(idx);
        return s;
    }
    public override void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        base.DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        StartingCountdown();
    }
    public void DisplayQuestionsAboutPrompt()
    {
        Console.Clear();
        for (int _ = 0; _ < (GetDuration() > 19 ? (GetDuration() / 10) : 1); _++)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            Activity.SpinnerAnimation(10);
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public ReflectionActivity() : base(_activityName, _description, _prompts)
    {

    }
}