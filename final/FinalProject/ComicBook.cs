class ComicBook : BookMedia
{
    private string _illustrator;
    private int _issueNumber;

    public ComicBook(int id, string title, string author, string genre, string publisher, DateTime releaseDate, string illustrator, int issueNumber) : base(id, typeof(ComicBook).Name, title, author, genre, publisher, releaseDate)
    {
        _illustrator = illustrator;
        _issueNumber = issueNumber;
    }
}