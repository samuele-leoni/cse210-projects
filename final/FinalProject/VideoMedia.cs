class VideoMedia : Media
{
    private string _supportType;
    private string _director;
    private string _description;

    public override void Display()
    {
        //TODO: Implement overridden Display method
    }

    public VideoMedia(int id, string type, string title, string author, string genre, string publisher, DateTime releaseDate, string supportType, string director, string description) : base(id, type, title, author, genre, publisher, releaseDate)
    {
        _supportType = supportType;
        _director = director;
        _description = description;
    }
}