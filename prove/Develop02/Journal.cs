class Journal
{
    public List<JournalEntry> _entries;

    public Journal()
    {
        _entries = new();
    }

    public void Add(JournalEntry entry)
    {
        _entries.Add(entry);
    }

    public void Save(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // You can add text to the file with the WriteLine method
            foreach (JournalEntry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}, {entry._prompt}, {entry._response}");
            }
        }
    }

    public void Load(string fileName, PromptGenerator generator)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            _entries.Add(new(parts[0], parts[1], parts[2]));
        }
    }

    public void Display()
    {
        foreach (JournalEntry entry in _entries)
        {
            entry.Display();
        }
    }
}