class BookMedia : Media
{
    private int _chapters;
    private int _pages;
    private string _description;

    public override void Display()
    {
        // TODO: Implement overridden Display method
    }

    public BookMedia(int id, string type, string title, string author, string genre, string publisher, DateTime releaseDate) : base(id, type, title, author, genre, publisher, releaseDate)
    {
    }
}