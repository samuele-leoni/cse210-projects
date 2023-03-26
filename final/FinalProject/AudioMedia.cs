class AudioMedia : Media
{
    private List<string> _tracks;

    public override void Display()
    {
        //TODO: Implement overridden Display method
    }

    public void AddTrack(string track)
    {
        _tracks.Add(track);
    }

    public void RemoveTrack(string track)
    {
        _tracks.Remove(track);
    }

    public int GetNumberOfTracks()
    {
        return _tracks.Count;
    }

    public AudioMedia(int id, string type, string title, string author, string genre, string publisher, DateTime releaseDate) : base(id, type, title, author, genre, publisher, releaseDate)
    {
        _tracks = new List<string>();
    }

    public AudioMedia(int id, string type, string title, string author, string genre, string publisher, DateTime releaseDate, List<string> tracks) : base(id, type, title, author, genre, publisher, releaseDate)
    {
        _tracks = tracks.ToList();
    }
}