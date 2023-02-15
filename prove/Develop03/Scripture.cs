using System.Globalization;
using CsvHelper;
class Scripture
{
    public enum IDX_CSV
    {
        VERSE_ID,
        VOLUME_TITLE,
        BOOK_TITLE,
        CHAPTER_NUMBER,
        VERSE_NUMBER,
        SCRIPTURE_TEXT
    }

    private static List<string[]> scriptures;
    private Reference _reference;
    private List<Word> _text;

    public static void LoadScriptures(string path)
    {
        scriptures = new();
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                string verse_id = csv.GetField<string>("verse_id");
                string volume_title = csv.GetField<string>("volume_title");
                string book_title = csv.GetField<string>("book_title");
                string chapter_number = csv.GetField<string>("chapter_number");
                string verse_number = csv.GetField<string>("verse_number");
                string scripture_text = csv.GetField<string>("scripture_text");
                scriptures.Add(new string[] { verse_id, volume_title, book_title, chapter_number, verse_number, scripture_text });
            }
        }
    }

    public static List<string[]> GetScripturesSelection(int field, int offset = 0, int limit = 0)
    {
        List<string[]> result = new();

        if (limit == 0)
        {
            limit = scriptures.Count;
        }

        string volume = scriptures[0][field];
        string tmpVolume = "";

        result.Add(new string[] { "0", volume });

        for (int i = offset; i < limit; i++)
        {
            tmpVolume = scriptures[i][field];
            if (tmpVolume != volume)
            {
                result.Add(new string[] { i.ToString(), tmpVolume });
                volume = tmpVolume;
            }
        }

        return result;
    }
    private List<Word> WordsListToString(int x)
    {
        List<Word> text = new();
        text.Add(new($"{scriptures[x][(int)IDX_CSV.VERSE_NUMBER].ToString()}:"));
        string[] tmpString = scriptures[x][(int)IDX_CSV.SCRIPTURE_TEXT].Split(" ");
        foreach (string s in tmpString)
        {
            text.Add(new(s));
        }
        return text;
    }
    public Scripture()
    {
        _text = new();
        Random rand = new();
        int i = rand.Next(scriptures.Count);
        string[] scripture = scriptures[i];

        string volume = scripture[(int)IDX_CSV.VOLUME_TITLE];
        string book = scripture[(int)IDX_CSV.BOOK_TITLE];
        int chapter = int.Parse(scripture[(int)IDX_CSV.CHAPTER_NUMBER]);
        int firstVerse = int.Parse(scripture[(int)IDX_CSV.VERSE_NUMBER]);

        i += rand.Next(5);

        string[] newScripture = scriptures[i];

        if (scripture[(int)IDX_CSV.BOOK_TITLE] == newScripture[(int)IDX_CSV.BOOK_TITLE] && scripture[(int)IDX_CSV.CHAPTER_NUMBER] == newScripture[(int)IDX_CSV.CHAPTER_NUMBER] && int.Parse(newScripture[(int)IDX_CSV.VERSE_ID]) - int.Parse(scripture[(int)IDX_CSV.VERSE_ID]) > 1)
        {
            int lastVerse = int.Parse(newScripture[(int)IDX_CSV.VERSE_NUMBER]);
            _reference = new(volume, book, chapter, firstVerse, lastVerse);
            for (int x = int.Parse(scripture[(int)IDX_CSV.VERSE_ID]) - 1; x < int.Parse(newScripture[(int)IDX_CSV.VERSE_ID]); x++)
            {
                List<Word> lst = WordsListToString(x);
                _text = _text.Concat(lst).ToList();
            }
        }
        else
        {
            _reference = new(volume, book, chapter, firstVerse);
            List<Word> lst = WordsListToString(i);
            _text = _text.Concat(lst).ToList();
        }
    }
    public Scripture(Reference reference)
    {
        _text = new();
        _reference = reference;

        string volume = reference.GetVolume();
        string book = reference.GetBook();
        int chapter = reference.GetChapter();
        int firstVerse = reference.GetFirstVerse();
        int lastVerse = reference.GetLastVerse();

        bool volumeBool = false;
        bool bookBool = false;
        bool chapterBool = false;
        bool verseBool = false;
        int field = (int)IDX_CSV.VOLUME_TITLE;
        string[] scripture = new string[6];
        for (int i = 0; i < scriptures.Count && !verseBool; i++)
        {
            if (!volumeBool && scriptures[i][field] == volume)
            {
                volumeBool = true;
                field = (int)IDX_CSV.BOOK_TITLE;
            }
            if (!bookBool && volumeBool && scriptures[i][field] == book)
            {
                bookBool = true;
                field = (int)IDX_CSV.CHAPTER_NUMBER;
            }
            if (!chapterBool && bookBool && int.Parse(scriptures[i][field]) == chapter)
            {
                chapterBool = true;
                field = (int)IDX_CSV.VERSE_NUMBER;
            }
            if (!verseBool && chapterBool && int.Parse(scriptures[i][field]) == chapter)
            {
                verseBool = true;
                scripture = scriptures[i];
            }
        }
        if (lastVerse != 0)
        {
            for (int x = int.Parse(scripture[(int)IDX_CSV.VERSE_ID]) - 1; x < int.Parse(scripture[(int)IDX_CSV.VERSE_ID]) + (lastVerse - firstVerse); x++)
            {
                List<Word> lst = WordsListToString(x);
                _text = _text.Concat(lst).ToList();
            }
        }
        else
        {
            _reference = new(volume, book, chapter, firstVerse);
            List<Word> lst = WordsListToString(int.Parse(scripture[(int)IDX_CSV.VERSE_ID]));
            _text = _text.Concat(lst).ToList();
        }
    }

    public void HideWord(int numberOfWords = 1)
    {
        Random rand = new();
        Word word = _text[rand.Next(_text.Count())];
        for (int i = 0; i < numberOfWords && !IsCompletelyHidden(); i++)
        {
            while (word.IsHidden())
            {
                word = _text[rand.Next(_text.Count())];
            }
            word.Hide();
        }
    }

    public void Display()
    {
        _reference.Display();
        Console.WriteLine(GetRenderedText());
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