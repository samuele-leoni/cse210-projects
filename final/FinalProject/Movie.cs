class Movie : VideoMedia
{
    private int _length;

    public void SetLength(int length)
    {
        _length = length;
    }

    public override string GetSavingString()
    {
        return $"{base.GetSavingString()}|{_length}";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Length: {_length}");
    }

    public Movie(string title, string author, string genre, string publisher, DateTime releaseDate, string supportType, string director, string description, int length) : base(title, author, genre, publisher, releaseDate, supportType, director, description)
    {
        _length = length;
    }
}