class Reference
{

    private string _volume;
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse = 0;

    public string GetVolume()
    {
        return _volume;
    }
    public string GetBook()
    {
        return _book;
    }
    public int GetChapter()
    {
        return _chapter;
    }
    public int GetFirstVerse()
    {
        return _firstVerse;
    }
    public int GetLastVerse()
    {
        return _lastVerse;
    }
    public Reference(string volume, string book, int chapter, int verse)
    {
        _volume = volume;
        _book = book;
        _chapter = chapter;
        _firstVerse = verse;
    }

    public Reference(string volume, string book, int chapter, int firstVerse, int lastVerse)
    {
        _volume = volume;
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }



    public void Display()
    {
        string lastVerse = _lastVerse == 0 ? "" : $"-{_lastVerse}";
        Console.WriteLine($"{_volume}, {_book} {_chapter}:{_firstVerse}{lastVerse}");
    }
}