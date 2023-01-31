class Program
{
    const int MENU_MAIN = 0;
    const int MENU_WRITE = 1;
    const int MENU_DISPLAY = 2;
    const int MENU_LOAD = 3;
    const int MENU_SAVE = 4;
    const int MENU_QUIT = 5;

    private static PromptGenerator generator = new();

    private static Journal journal = new();

    public static void Main(string[] args)
    {
        int menu = MENU_MAIN;
        while (menu != MENU_QUIT)
        {
            menu = DisplayMenu(menu);
        }
    }

    public static int DisplayMenu(int menu)
    {
        int mtl = MENU_MAIN;
        switch (menu)
        {
            case MENU_MAIN:
                Console.WriteLine("Welcome to the Journal Program!");
                Console.WriteLine("Please select one of the following choices");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");
                mtl = int.Parse(Console.ReadLine());
                break;
            case MENU_WRITE:
                string prompt = generator.GetPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                JournalEntry entry = new(DateTime.Now.ToShortDateString(), prompt, response);
                journal.Add(entry);
                break;
            case MENU_DISPLAY:
                journal.Display();
                break;
            case MENU_LOAD:
                Console.WriteLine("What is the filename?");
                string fileToLoad = Console.ReadLine();
                journal.Load(fileToLoad, generator);
                break;
            case MENU_SAVE:
                Console.WriteLine("What is the filename?");
                string fileToSave = Console.ReadLine();
                journal.Save(fileToSave);
                break;
        }
        return mtl;
    }
}