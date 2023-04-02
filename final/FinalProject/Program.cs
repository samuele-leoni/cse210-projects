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
        USER_STATE,
        ADD_MEDIA,
        REMOVE_MEDIA,
        LIST_MEDIA,
        BORROW_MEDIA,
        RETURN_MEDIA
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
        Console.Clear();
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
                try
                {
                    mtl = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                break;

            case (int)MENU.MANAGE_USERS:
                offset = (int)MENU.QUIT;
                Console.WriteLine("User Management Menu");
                Console.WriteLine("    1. Add User");
                Console.WriteLine("    2. Remove User");
                Console.WriteLine("    3. List Users");
                Console.WriteLine("    4. Change User State");
                Console.WriteLine("    5. Back");
                Console.Write("Select an option: ");
                try
                {
                    mtl = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                if (mtl == 5)
                {
                    mtl = (int)MENU.MAIN;
                }
                else
                {
                    mtl += offset;
                }
                break;

            case (int)MENU.MANAGE_MEDIA:
                offset = (int)MENU.USER_STATE;
                Console.WriteLine("Media Management Menu");
                Console.WriteLine("    1. Add Media");
                Console.WriteLine("    2. Remove Media");
                Console.WriteLine("    3. List Media");
                Console.WriteLine("    4. Borrow Media");
                Console.WriteLine("    5. Return Media");
                Console.WriteLine("    6. Back");
                Console.Write("Select an option: ");
                try
                {
                    mtl = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                if (mtl == 6)
                {
                    mtl = (int)MENU.MAIN;
                }
                else
                {
                    mtl += offset;
                }
                break;

            case (int)MENU.SAVE:
                Console.WriteLine("Save Menu");
                Console.WriteLine("    1. Save Media");
                Console.WriteLine("    2. Save Users");
                Console.WriteLine("    3. Back");
                Console.Write("Select an option: ");
                try
                {
                    mtl = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
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
                try
                {
                    mtl = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                Console.Write("Enter the filename: ");
                string loadFileName = Console.ReadLine();
                if (mtl != 3)
                {
                    library.Load(loadFileName, mtl == 2);
                }
                Console.WriteLine("Load complete.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.ADD_USER:
                Console.WriteLine("Add User Menu");
                Console.Write("Enter the user's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the user's last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter the user's email: ");
                string email = Console.ReadLine();
                Console.Write("Enter the user's birthdate (mm/dd/yyyy): ");
                string[] birthdate = Console.ReadLine().Split("/");
                DateTime birthdateDT = new(int.Parse(birthdate[2]), int.Parse(birthdate[0]), int.Parse(birthdate[1]));
                library.AddUser(new User(name, lastName, email, birthdateDT));
                Console.WriteLine("User added successfully.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.REMOVE_USER:
                Console.WriteLine("Remove User Menu");
                Console.Write("Enter the user's ID: ");
                int idx = 0;
                try
                {
                    idx = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                library.RemoveUser(idx);
                Console.WriteLine("User removed successfully.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.LIST_USERS:
                bool init = true;
                while (mtl != 5)
                {
                    Console.Clear();
                    Console.WriteLine("List Users Menu");
                    Console.WriteLine("    1. List All Users");
                    Console.WriteLine("    2. Filter by Last Name");
                    Console.WriteLine("    3. Filter by Email");
                    Console.WriteLine("    4. Filter by Birthdate");
                    Console.WriteLine("    5. Back to Main Menu");
                    Console.Write("Select an option: ");
                    try
                    {
                        mtl = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        continue;
                    }
                    List<User> users = new();
                    switch (mtl)
                    {
                        case 1:
                            users = library.GetUserByFilter(init: init);
                            break;
                        case 2:
                            Console.Write("Enter the last name: ");
                            string lastNameFilter = Console.ReadLine();
                            users = library.GetUserByFilter(lastName: lastNameFilter, init: init);
                            break;
                        case 3:
                            Console.Write("Enter the email: ");
                            string emailFilter = Console.ReadLine();
                            users = library.GetUserByFilter(email: emailFilter, init: init);
                            break;
                        case 4:
                            Console.Write("Enter the birthdate (mm/dd/yyyy): ");
                            string[] birthdateFilter = Console.ReadLine().Split("/");
                            DateTime birthdateDTFilter = new(int.Parse(birthdateFilter[2]), int.Parse(birthdateFilter[0]), int.Parse(birthdateFilter[1]));
                            users = library.GetUserByFilter(birthDate: birthdateDTFilter, init: init);
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine();
                    foreach (User u in users)
                    {
                        u.Display();
                        Console.WriteLine();
                    }
                    init = false;
                    if (mtl != 5)
                    {
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                }
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.USER_STATE:
                Console.WriteLine("User State Menu");
                Console.Write("Enter the user's ID: ");
                int userIdx = 0;
                try
                {
                    userIdx = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                Console.Clear();
                library.GetUser(userIdx).Display();
                Console.WriteLine();
                Console.WriteLine("User State Menu");
                Console.WriteLine("    1. Activate User");
                Console.WriteLine("    2. Deactivate User");
                Console.WriteLine("    3. Back to Main Menu");
                Console.Write("Select an option: ");
                try
                {
                    mtl = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                if (mtl == 1)
                {
                    library.ActivateUser(userIdx);
                }
                else if (mtl == 2)
                {
                    library.DeactivateUser(userIdx);
                }
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.ADD_MEDIA:
                Console.WriteLine("Add Media Menu");
                Console.WriteLine("    1. Add Book");
                Console.WriteLine("    2. Add Comicbook");
                Console.WriteLine("    3. Add Audiobook");
                Console.WriteLine("    4. Add Audio CD");
                Console.WriteLine("    5. Add Movie");
                Console.WriteLine("    6. Add Series");
                Console.WriteLine("    7. Back to Main Menu");
                Console.Write("Select an option: ");
                try
                {
                    mtl = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                if (mtl != 7)
                {
                    library.AddMedia(mtl);
                }
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.REMOVE_MEDIA:
                Console.WriteLine("Remove Media Menu");
                Console.Write("Enter the media ID: ");
                int mediaIdx = 0;
                try
                {
                    mediaIdx = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                library.RemoveMedia(mediaIdx);
                Console.WriteLine("Media removed successfully.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.LIST_MEDIA:
                bool initMedia = true;
                while (mtl != 6)
                {
                    Console.Clear();
                    Console.WriteLine("List Media Menu");
                    Console.WriteLine("    1. List All Media");
                    Console.WriteLine("    2. Filter by Title");
                    Console.WriteLine("    3. Filter by Author");
                    Console.WriteLine("    4. Filter by Genre");
                    Console.WriteLine("    5. Filter by Media Type");
                    Console.WriteLine("    6. Back to Main Menu");
                    Console.Write("Select an option: ");
                    try
                    {
                        mtl = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        continue;
                    }
                    List<Media> media = new();
                    switch (mtl)
                    {
                        case 1:
                            media = library.GetMediaByFilter(init: initMedia);
                            break;
                        case 2:
                            Console.Write("Enter the title: ");
                            string titleFilter = Console.ReadLine();
                            media = library.GetMediaByFilter(title: titleFilter, init: initMedia);
                            break;
                        case 3:
                            Console.Write("Enter the author: ");
                            string authorFilter = Console.ReadLine();
                            media = library.GetMediaByFilter(author: authorFilter, init: initMedia);
                            break;
                        case 4:
                            Console.Write("Enter the genre: ");
                            string genreFilter = Console.ReadLine();
                            media = library.GetMediaByFilter(genre: genreFilter, init: initMedia);
                            break;
                        case 5:
                            Console.Write("Enter the media type: ");
                            string mediaTypeFilter = Console.ReadLine();
                            media = library.GetMediaByFilter(mediaType: mediaTypeFilter, init: initMedia);
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine();
                    foreach (Media m in media)
                    {
                        m.Display();
                        Console.WriteLine();
                    }
                    init = false;
                    if (mtl != 6)
                    {
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                }
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.BORROW_MEDIA:
                Console.WriteLine("Borrow Media Menu");
                Console.Write("Enter the media ID: ");
                int mediaId = 0;
                try
                {
                    mediaId = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                library.GetMedia(mediaId).Display();
                Console.Write("Enter the user ID: ");
                int userId = 0;
                try
                {
                    userId = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                library.GetUser(userId).Display();
                library.BorrowMedia(userId, mediaId);
                Console.WriteLine("Media borrowed successfully.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                mtl = (int)MENU.MAIN;
                break;

            case (int)MENU.RETURN_MEDIA:
                Console.WriteLine("Return Media Menu");
                Console.Write("Enter the media ID: ");
                int mediaIdReturn = 0;
                try
                {
                    mediaIdReturn = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                library.GetMedia(mediaIdReturn).Display();
                Console.Write("Enter the user ID: ");
                int userIdReturn = 0;
                try
                {
                    userIdReturn = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    mtl = menuToLoad;
                    break;
                }
                User user = library.GetUser(userIdReturn);
                user.Display();
                if (user.GetBorrowedMediaIdx().Contains(mediaIdReturn))
                {
                    library.ReturnMedia(userIdReturn, mediaIdReturn);
                    Console.WriteLine("Media returned successfully.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("User has not borrowed this media.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                }
                mtl = (int)MENU.MAIN;
                break;

            default:
                Console.WriteLine("Invalid menu option.");
                break;
        }
        return mtl;
    }
}