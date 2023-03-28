using System;

class Program
{
    private static Library library;

    enum MENU
    {
        MAIN,
        MANAGE_USERS,
        MANAGE_MEDIA,
        SAVE,
        LOAD,
        QUIT,
        ADD_USER,
        REMOVE_USER,
        LIST_USERS,
        SEARCH_USERS,
        ADD_MEDIA,
        REMOVE_MEDIA,
        LIST_MEDIA,
        SEARCH_MEDIA
    }

    static void Main(string[] args)
    {
        library = new();
        int mtl = (int)MENU.MAIN;
        while (mtl != (int)MENU.QUIT)
        {
            mtl = LoadMenu(mtl);
        }
        Console.Clear();
        Console.WriteLine("Goodbye!");
    }

    /// <summary> Loads the menu specified by the menuToLoad parameter. The menu value is specified as the MENU enum. </summary>
    /// <param name="menuToLoad">The menu to load.</param>
    /// <returns>The menu to load next.</returns>
    private static int LoadMenu(int menuToLoad)
    {
        int mtl = menuToLoad;
        Console.WriteLine();
        int offset = 0;
        switch (menuToLoad)
        {
            case (int)MENU.MAIN:
                Console.WriteLine("Main Menu");
                Console.WriteLine("    1. Manage Users");
                Console.WriteLine("    2. Manage Media");
                Console.WriteLine("    3. Save");
                Console.WriteLine("    4. Load");
                Console.WriteLine("    5. Quit");
                Console.Write("Select an option: ");
                mtl = int.Parse(Console.ReadLine());
                break;

            case (int)MENU.MANAGE_USERS:
                offset = (int)MENU.QUIT;
                Console.WriteLine("User Management Menu");
                Console.WriteLine("    1. Add User");
                Console.WriteLine("    2. Remove User");
                Console.WriteLine("    3. List Users");
                Console.WriteLine("    4. Search Users");
                Console.WriteLine("    5. Back");
                Console.Write("Select an option: ");
                mtl = int.Parse(Console.ReadLine()) + offset;
                if (mtl == 5)
                {
                    mtl = (int)MENU.MAIN;
                }
                break;

            case (int)MENU.MANAGE_MEDIA:
                offset = (int)MENU.SEARCH_USERS;
                Console.WriteLine("Media Management Menu");
                Console.WriteLine("    1. Add Media");
                Console.WriteLine("    2. Remove Media");
                Console.WriteLine("    3. List Media");
                Console.WriteLine("    4. Search Media");
                Console.WriteLine("    5. Back");
                Console.Write("Select an option: ");
                mtl = int.Parse(Console.ReadLine()) + offset;
                if (mtl == 5)
                {
                    mtl = (int)MENU.MAIN;
                }
                break;

            case (int)MENU.SAVE:
                Console.WriteLine("Save Menu");
                Console.WriteLine("    1. Save Media");
                Console.WriteLine("    2. Save Users");
                Console.WriteLine("    3. Back");
                Console.Write("Select an option: ");
                mtl = int.Parse(Console.ReadLine());
                Console.Write("Enter the filename: ");
                string saveFileName = Console.ReadLine();
                if (mtl != 3)
                {
                    library.Save(saveFileName, mtl == 2);
                }
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.LOAD:
                Console.WriteLine("Load Menu");
                Console.WriteLine("    1. Load Media");
                Console.WriteLine("    2. Load Users");
                Console.WriteLine("    3. Back");
                Console.Write("Select an option: ");
                mtl = int.Parse(Console.ReadLine());
                Console.Write("Enter the filename: ");
                string loadFileName = Console.ReadLine();
                if (mtl != 3)
                {
                    library.Load(loadFileName, mtl == 2);
                }
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.ADD_USER:
                // TODO: Implement Add User Menu
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.REMOVE_USER:
                // TODO: Implement Remove User Menu
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.LIST_USERS:
                // TODO: Implement List Users Menu
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.SEARCH_USERS:
                // TODO: Implement Search Users Menu
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.ADD_MEDIA:
                // TODO: Implement Add Media Menu
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.REMOVE_MEDIA:
                // TODO: Implement Remove Media Menu
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.LIST_MEDIA:
                // TODO: Implement List Media Menu
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.SEARCH_MEDIA:
                // TODO: Implement Search Media Menu
                mtl = (int)MENU.MAIN;
                break;

            default:
                Console.WriteLine("Invalid menu option.");
                break;
        }
        return mtl;
    }
}