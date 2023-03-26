class Movie : VideoMedia
{
    private int _length;

    public override void Display()
    {
        // TODO: Implement overridden Display method
    }

    public Movie(int id, string title, string author, string genre, string publisher, DateTime releaseDate, string supportType, string director, string description, int length) : base(id, typeof(Movie).Name, title, author, genre, publisher, releaseDate, supportType, director, description)
    {
        _length = length;
    }
}