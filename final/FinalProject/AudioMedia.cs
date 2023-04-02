class AudioMedia : Media
{
    private List<string> _tracks;

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Tracks:");
        foreach (string track in _tracks)
        {
            Console.WriteLine(track);
        }
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

    public override string GetSavingString()
    {
        string savingString = $"{base.GetSavingString()}\\";
        foreach (string track in _tracks)
        {
            savingString += $"{track}|";
        }
        savingString = savingString.Remove(savingString.Length - 1);

        return savingString;
    }

    public AudioMedia(string title, string author, string genre, string publisher, DateTime releaseDate, List<string> tracks) : base(title, author, genre, publisher, releaseDate)
    {
        _tracks = tracks.ToList();
    }
}