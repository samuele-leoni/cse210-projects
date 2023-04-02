class Series : VideoMedia
{
    private int _season;
    private int _numberOfEpisodes;
    private int _episodeLength;

    public void SetSeason(int season)
    {
        _season = season;
    }

    public void SetNumberOfEpisodes(int numberOfEpisodes)
    {
        _numberOfEpisodes = numberOfEpisodes;
    }

    public void SetEpisodeLength(int episodeLength)
    {
        _episodeLength = episodeLength;
    }

    public override string GetSavingString()
    {
        return $"{base.GetSavingString()}|{_season}|{_numberOfEpisodes}|{_episodeLength}";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Season: {_season}");
        Console.WriteLine($"Number of Episodes: {_numberOfEpisodes}");
        Console.WriteLine($"Episode Length: {_episodeLength}");
        Console.WriteLine();
    }

    public Series(string title, string author, string genre, string publisher, DateTime releaseDate, string supportType, string director, string description, int season, int numberOfEpisodes, int episodeLength) : base(title, author, genre, publisher, releaseDate, supportType, director, description)
    {
        _season = season;
        _numberOfEpisodes = numberOfEpisodes;
        _episodeLength = episodeLength;
    }
}