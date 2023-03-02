class ReflectionActivity : Activity
{
    private string[] prompts = { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    private List<string> questions = new() { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };
    public string GetRandomPrompt()
    {
        Random rand = new();
        return prompts[rand.Next(prompts.Count())];
    }
    public string GetRandomQuestion()
    {
        Random rand = new();
        int idx = rand.Next(questions.Count);
        string s = questions[idx];
        questions.RemoveAt(idx);
        return s;
    }
    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.WriteLine();
        Console.ReadLine();
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
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
    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {

    }
}