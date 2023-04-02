class VideoMedia : Media
{
    private string _supportType;
    private string _director;
    private string _description;

    public void SetSupportType(string supportType)
    {
        _supportType = supportType;
    }

    public void SetDirector(string director)
    {
        _director = director;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public override string GetSavingString()
    {
        return $"{base.GetSavingString()}\\{_supportType}|{_director}|{_description}";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Support Type: {_supportType}");
        Console.WriteLine($"Director: {_director}");
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
        Console.WriteLine();
    }

    public VideoMedia(string title, string author, string genre, string publisher, DateTime releaseDate, string supportType, string director, string description) : base(title, author, genre, publisher, releaseDate)
    {
        _supportType = supportType;
        _director = director;
        _description = description;
    }
}