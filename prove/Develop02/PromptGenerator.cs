class PromptGenerator
{
    public List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new(){
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?",
            "What did I learn today and how will I apply it to my life?",
            "Have I been a positive example to others today and in what ways?"
        };
    }

    public string GetPrompt()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(_prompts.Count);
        string prompt = _prompts[randomIndex];
        return prompt;
    }

    public void RemoveUsedPrompts(Journal journal)
    {
        foreach (JournalEntry entry in journal._entries)
        {
            _prompts.Remove(entry._prompt);
        }
    }
}