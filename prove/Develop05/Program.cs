using System;

class Program
{
    private static Game game;
    enum MENU
    {
        MAIN,
        NEW_GOAL,
        LIST,
        SAVE,
        LOAD,
        RECORD_EVENT,
        QUIT
    }
    static void Main(string[] args)
    {
        game = new Game();
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
        Console.WriteLine();
        switch (menuToLoad)
        {
            case (int)MENU.MAIN:
                Console.WriteLine($"You have {game.GetPoints()} points.");
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("    1. Create New Goal");
                Console.WriteLine("    2. List Goals");
                Console.WriteLine("    3. Save Goals");
                Console.WriteLine("    4. Load Goals");
                Console.WriteLine("    5. Record Event");
                Console.WriteLine("    6. Quit");
                Console.Write("Select a choice from the menu: ");
                mtl = int.Parse(Console.ReadLine());
                break;
            case (int)MENU.NEW_GOAL:
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("    1. Simple Goal");
                Console.WriteLine("    2. Eternal Goal");
                Console.WriteLine("    3. Checklist Goal");
                Console.Write("Which type of Goal would you like to create? ");
                int type = int.Parse(Console.ReadLine());
                Console.Write("What is the name of your Goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                Goal goal = null;
                switch (type)
                {
                    case 1:
                        goal = new SimpleGoal(name, description, points);
                        break;
                    case 2:
                        goal = new EternalGoal(name, description, points);
                        break;
                    case 3:
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        int timesToGetBonus = int.Parse(Console.ReadLine());
                        Console.Write("What is the bonus for accomplishing it that many times? ");
                        int bonus = int.Parse(Console.ReadLine());
                        goal = new ChecklistGoal(name, description, points, timesToGetBonus, bonus);
                        break;
                    default:
                        break;
                }
                if (goal != null)
                {
                    game.AddGoal(goal);
                }
                mtl = (int)MENU.MAIN;
                break;
            case (int)MENU.LIST:
                if (game.GetNumberOfGoals() == 0)
                {
                    Console.WriteLine("You have no goals.");
                    mtl = (int)MENU.MAIN;
                    break;
                }
                else
                {
                    game.Display();
                }
                mtl = (int)MENU.MAIN;
                break;
            case (int)MENU.SAVE:
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();
                game.Save(filename);
                mtl = (int)MENU.MAIN;
                break;
            case (int)MENU.LOAD:
                Console.Write("What is the filename for the goal file? ");
                filename = Console.ReadLine();
                game.Load(filename);
                mtl = (int)MENU.MAIN;
                break;
            case (int)MENU.RECORD_EVENT:
                game.DisplayActiveGoals();
                if (game.GetNumberOfGoals() == 0)
                {
                    Console.WriteLine("You have no goals.");
                    mtl = (int)MENU.MAIN;
                    break;
                }
                else
                {
                    Console.Write("Which goal did you accomplish? ");
                    int goalIdx = int.Parse(Console.ReadLine());
                    game.RecordEvent(game.GetGoal(goalIdx - 1));
                }
                mtl = (int)MENU.MAIN;
                break;
            default:
                break;
        }
        return mtl;
    }
}