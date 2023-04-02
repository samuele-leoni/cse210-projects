class ComicBook : BookMedia
{
    private string _illustrator;
    private int _issueNumber;

    public void SetIllustrator(string illustrator)
    {
        _illustrator = illustrator;
    }

    public void SetIssueNumber(int issueNumber)
    {
        _issueNumber = issueNumber;
    }

    public override string GetSavingString()
    {
        return $"{base.GetSavingString()}|{_illustrator}|{_issueNumber}";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Illustrator: {_illustrator}");
        Console.WriteLine($"Issue Number: {_issueNumber}");
        Console.WriteLine();
    }

    public ComicBook(string title, string author, string genre, string publisher, DateTime releaseDate, int chapters, int pages, string description, string illustrator, int issueNumber) : base(title, author, genre, publisher, releaseDate, chapters, pages, description)
    {
        _illustrator = illustrator;
        _issueNumber = issueNumber;
    }
}