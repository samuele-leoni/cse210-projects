class AudioCD : AudioMedia
{

    public override void Display()
    {
        base.Display();
        Console.WriteLine();
    }

    public AudioCD(string title, string author, string genre, string publisher, DateTime releaseDate, List<string> tracks) : base(title, author, genre, publisher, releaseDate, tracks)
    {
    }
}