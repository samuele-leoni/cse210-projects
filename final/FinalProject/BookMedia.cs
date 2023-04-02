class BookMedia : Media
{
    private int _chapters;
    private int _pages;
    private string _description;

    public void SetChapters(int chapters)
    {
        _chapters = chapters;
    }

    public void SetPages(int pages)
    {
        _pages = pages;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public override string GetSavingString()
    {
        return $"{base.GetSavingString()}\\{_chapters}|{_pages}|{_description}";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Chapters: {_chapters}");
        Console.WriteLine($"Pages: {_pages}");
        Console.WriteLine("Description:");
        string[] description = _description.Split(' ');
        int counter = 0;
        foreach (string word in description)
        {
            counter += word.Length;
            Console.Write(word);
            if (counter >= 25)
            {
                Console.WriteLine();
                counter = 0;
            }
            else
            {
                Console.Write(" ");
            }
        }
    }

    public BookMedia(string title, string author, string genre, string publisher, DateTime releaseDate, int chapters, int pages, string description) : base(title, author, genre, publisher, releaseDate)
    {
        _chapters = chapters;
        _pages = pages;
        _description = description;
    }
}