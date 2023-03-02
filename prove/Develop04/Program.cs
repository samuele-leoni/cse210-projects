using System;

class Program
{
    enum MENU
    {
        MAIN,
        BREATHING,
        REFLECTING,
        LISTING,
        QUIT
    }
    static void Main(string[] args)
    {
        int mtl = (int)MENU.MAIN;
        while (mtl != (int)MENU.QUIT)
        {
            mtl = LoadMenu(mtl);
        }
        Console.Clear();
        Console.WriteLine("See you next time!");
    }
    private static int LoadMenu(int menuToLoad)
    {
        int mtl = menuToLoad;
        Console.Clear();
        switch (menuToLoad)
        {
            case (int)MENU.MAIN:
                Console.WriteLine("Menu Options:");
                Console.WriteLine("    1. Start breathing activity");
                Console.WriteLine("    2. Start reflecting activity");
                Console.WriteLine("    3. Start listing activity");
                Console.WriteLine("    4. Quit");
                Console.Write("Select a choice from the menu: ");
                mtl = int.Parse(Console.ReadLine());
                break;
            case (int)MENU.BREATHING:
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.DisplayStartingMessage();
                breathingActivity.DisplayBreathingMessages();
                breathingActivity.DisplayEndingMessage();
                mtl = (int)MENU.MAIN;
                break;
            case (int)MENU.REFLECTING:
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.DisplayStartingMessage();
                reflectionActivity.DisplayPrompt();
                reflectionActivity.DisplayQuestionsAboutPrompt();
                reflectionActivity.DisplayEndingMessage();
                mtl = (int)MENU.MAIN;
                break;
            case (int)MENU.LISTING:
                //TODO
                mtl = (int)MENU.MAIN;
                break;
            default:
                break;
        }
        return mtl;
    }
}