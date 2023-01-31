class JournalEntry
{
    public string _date { get; set; }
    public string _prompt { get; set; }
    public string _response { get; set; }

    public JournalEntry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public JournalEntry()
    {
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
    }
}