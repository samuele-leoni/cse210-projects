class Book : BookMedia
{
    public override void Display()
    {
        // TODO: Implement overridden Display method
    }

    public Book(int id, string title, string author, string genre, string publisher, DateTime releaseDate) : base(id, typeof(Book).Name, title, author, genre, publisher, releaseDate)
    {
    }
}