class AudioBook : AudioMedia
{
    private string _narrator;

    public override void Display()
    {
        //TODO: Implement overridden Display method
    }

    public AudioBook(int id, string title, string author, string genre, string publisher, DateTime releaseDate, string narrator) : base(id, typeof(AudioBook).Name, title, author, genre, publisher, releaseDate)
    {
        _narrator = narrator;
    }
    
    public AudioBook(int id, string title, string author, string genre, string publisher, DateTime releaseDate, string narrator, List<string> tracks) : base(id, typeof(AudioBook).Name, title, author, genre, publisher, releaseDate, tracks)
    {
        _narrator = narrator;
    }
}