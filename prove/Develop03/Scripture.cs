class Scripture
{
    private const int IDX_VERSE_ID = 3;
    private const int IDX_VOLUME_TITLE = 4;
    private const int IDX_BOOK_TITLE = 5;
    private const int IDX_CHAPTER_NUMBER = 14;
    private const int IDX_VERSE_NUMBER = 15;

    private static string[][] scriptures;

    private Reference _reference;
    private List<Word> _text;

    private static void LoadScriptures(string path)
    {
        scriptures = File.ReadAllLines(path).Skip(1).Select(row => row.Split(',')).ToArray();
    }

    public Scripture()
    {
        Random rand = new();
        int i = rand.Next(scriptures.Count());
        string[] scripture = scriptures[i];

        string volume = scripture[IDX_VOLUME_TITLE];
        string book = scripture[IDX_BOOK_TITLE];
        int chapter = int.Parse(scripture[IDX_CHAPTER_NUMBER]);
        int firstVerse = int.Parse(scripture[IDX_VERSE_NUMBER]);

        i += rand.Next(5);

        string[] newScripture = scriptures[i];

        if (scripture[IDX_BOOK_TITLE] == newScripture[IDX_BOOK_TITLE])
        {
            int lastVerse = int.Parse(newScripture[IDX_VERSE_NUMBER]);
            _reference = new(volume, book, chapter, lastVerse);
        }
        else
        {
            _reference = new(volume, book, chapter, firstVerse);
        }
    }
    public Scripture(Reference reference, List<Word> text)
    {
        _reference = reference;
        _text = text;
    }

    public void HideWord()
    {
        Random rand = new();
        _text[rand.Next(_text.Count())].Hide();
    }

    public void Display()
    {
        foreach (Word word in _text)
        {
            Console.WriteLine(GetRenderedText());
        }
    }

    private string GetRenderedText()
    {
        string renderedText = "";

        foreach (Word w in _text)
        {
            renderedText += w.GetRenderedText();
            renderedText += " ";
        }

        return renderedText;
    }

    public bool IsCompletelyHidden()
    {
        bool isCompletelyHidden = true;
        foreach (Word w in _text)
        {
            if (!w.IsHidden())
            {
                isCompletelyHidden = false;
            }
        }
        return isCompletelyHidden;
    }
}