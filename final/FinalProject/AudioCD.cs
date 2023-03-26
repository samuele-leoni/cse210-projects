class AudioCD : AudioMedia
{

    public override void Display()
    {
        //TODO: Implement overridden Display method
    }

    public AudioCD(int id, string title, string author, string genre, string publisher, DateTime releaseDate) : base(id, typeof(AudioCD).Name, title, author, genre, publisher, releaseDate)
    {
    }

    public AudioCD(int id, string title, string author, string genre, string publisher, DateTime releaseDate, List<string> tracks) : base(id, typeof(AudioCD).Name, title, author, genre, publisher, releaseDate, tracks)
    {
    }
}