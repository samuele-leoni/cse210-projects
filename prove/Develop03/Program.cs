class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the scripture memorizing helper!");
        Console.WriteLine("Select your choice:");
        Console.WriteLine("1-I want a random scripture");
        Console.WriteLine("2-I want to choose one myself\n");

        int choice = int.Parse(Console.ReadLine());
        Console.Clear();

        Scripture.LoadScriptures("lds-scriptures.csv");
        Scripture scripture;
        if (choice == 1)
        {
            scripture = new();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Select a Volume:");
            List<string[]> volumes = Scripture.GetScripturesSelection((int)Scripture.IDX_CSV.VOLUME_TITLE);
            for (int i = 0; i < volumes.Count; i++)
            {
                Console.WriteLine($"{i + 1}-{volumes[i][1]}");
            }
            int volIdx = int.Parse(Console.ReadLine()) - 1;
            string[] volume = volumes[volIdx];
            string[] nextVol = volIdx == (volumes.Count - 1) ? null : volumes[volIdx + 1];
            Console.Clear();

            Console.WriteLine("Select a Book:");
            List<string[]> books = Scripture.GetScripturesSelection((int)Scripture.IDX_CSV.BOOK_TITLE, int.Parse(volume[0]), nextVol != null?int.Parse(nextVol[0]):0);
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}-{books[i][1]}");
            }
            int bookIdx = int.Parse(Console.ReadLine()) - 1;
            string[] book = books[bookIdx];
            string[] nextBook = bookIdx == (books.Count - 1) ? null : books[bookIdx + 1];
            Console.Clear();

            Console.WriteLine("Select a Chapter:");
            List<string[]> chapters = Scripture.GetScripturesSelection((int)Scripture.IDX_CSV.CHAPTER_NUMBER, int.Parse(book[0]), nextBook != null?int.Parse(nextBook[0]):0);
            for (int i = 0; i < chapters.Count; i++)
            {
                Console.WriteLine($"{chapters[i][1]}");
            }
            int chapterIdx = int.Parse(Console.ReadLine()) - 1;
            string[] chapter = chapters[chapterIdx];
            string[] nextChapter = chapterIdx == (chapters.Count - 1) ? null : chapters[chapterIdx + 1];
            Console.Clear();

            Console.WriteLine("Select the first Verse:");
            List<string[]> verses = Scripture.GetScripturesSelection((int)Scripture.IDX_CSV.CHAPTER_NUMBER, int.Parse(book[0]), nextBook != null?int.Parse(nextBook[0]):0);
            for (int i = 0; i < verses.Count; i++)
            {
                Console.WriteLine($"{verses[i][1]}");
            }
            int firstVerseIdx = int.Parse(Console.ReadLine()) - 1;
            string[] firstVerse = verses[firstVerseIdx];
            Console.Clear();

            Console.WriteLine("Select the last Verse:");
            verses = Scripture.GetScripturesSelection((int)Scripture.IDX_CSV.CHAPTER_NUMBER, int.Parse(firstVerse[0]), nextBook != null?int.Parse(nextBook[0]):0);
            for (int i = 0; i < verses.Count; i++)
            {
                Console.WriteLine($"{verses[i][1]}");
            }
            int lastVerseIdx = int.Parse(Console.ReadLine()) - 1;
            string[] lastVerse = verses[lastVerseIdx];
            Console.Clear();

            Reference reference;

            if(lastVerse != null)
            {
                reference = new(volume[1], book[1], int.Parse(chapter[1]), int.Parse(firstVerse[1]), int.Parse(lastVerse[1]));
            }
            else
            {
                reference = new(volume[1], book[1], int.Parse(chapter[1]), int.Parse(firstVerse[1]));
            }

            scripture = new(reference);
        }
        else
        {
            Console.WriteLine("No valid choice selected");
            return;
        }

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.ReadLine();
            scripture.HideWord(3);
        }

        Console.WriteLine("\nI hope you memorized it, see you!");
    }
}