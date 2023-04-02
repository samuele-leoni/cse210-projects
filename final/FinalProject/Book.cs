class Book : BookMedia
{
    public override void Display()
    {
        base.Display();
        Console.WriteLine();
    }

    public Book(string title, string author, string genre, string publisher, DateTime releaseDate, int chapters, int pages, string description) : base(title, author, genre, publisher, releaseDate, chapters, pages, description)
    {
    }
}