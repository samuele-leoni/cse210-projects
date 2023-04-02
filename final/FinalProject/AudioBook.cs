class AudioBook : AudioMedia
{
    private string _narrator;

    public void SetNarrator(string narrator)
    {
        _narrator = narrator;
    }

    public override string GetSavingString()
    {
        return $"{base.GetSavingString()}\\{_narrator}";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Narrator: {_narrator}");
    }
    
    public AudioBook(string title, string author, string genre, string publisher, DateTime releaseDate, string narrator, List<string> tracks) : base(title, author, genre, publisher, releaseDate, tracks)
    {
        _narrator = narrator;
    }
}