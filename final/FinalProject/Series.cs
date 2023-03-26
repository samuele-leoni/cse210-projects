class Series : VideoMedia
{
    private int _season;
    private int _numberOfEpisodes;
    private int _episodeLength;

    public override void Display()
    {
        // TODO: Implement overridden Display method
    }

    public Series(int id, string title, string author, string genre, string publisher, DateTime releaseDate, string supportType, string director, string description) : base(id, typeof(Series).Name, title, author, genre, publisher, releaseDate, supportType, director, description)
    {
    }
}