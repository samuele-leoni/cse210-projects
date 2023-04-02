class Library
{
    private List<Media> _media;
    private List<Media> _filteredMedia;
    private List<User> _users;
    private List<User> _filteredUsers;

    /// <summary> Adds a media to the library. </summary>
    /// <param name="mediaType"> The type of media to add.<br>1-Book<br>2-ComicBook<br>3-AudioBook<br>4-AudioCD<br>5-Movie<br>6-Series</param>
    public void AddMedia(int mediaType)
    {
        if (mediaType == 7)
        {
            return;
        }

        Console.Write("Enter the title: ");
        string title = Console.ReadLine();
        Console.Write("Enter the author: ");
        string author = Console.ReadLine();
        Console.Write("Enter the genre: ");
        string genre = Console.ReadLine();
        Console.Write("Enter the publisher: ");
        string publisher = Console.ReadLine();
        Console.Write("Enter the release date (mm/dd/yyyy): ");
        string releaseDate = Console.ReadLine();
        DateTime releaseDateDT = new(int.Parse(releaseDate.Split("/")[2]), int.Parse(releaseDate.Split("/")[0]), int.Parse(releaseDate.Split("/")[1]));
        Media media = null;
        int trackNumber = 0;
        List<string> trackList;

        switch (mediaType)
        {
            case 1:
                Console.Write("Enter the number of chapters: ");
                int chapters = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of pages: ");
                int pages = int.Parse(Console.ReadLine());
                Console.Write("Enter the description: ");
                string description = Console.ReadLine();
                media = new Book(title, author, genre, publisher, releaseDateDT, chapters, pages, description);
                break;
            case 2:
                Console.Write("Enter the number of chapters: ");
                int chaptersC = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of pages: ");
                int pagesC = int.Parse(Console.ReadLine());
                Console.Write("Enter the description: ");
                string descriptionC = Console.ReadLine();
                Console.Write("Enter the illustrator: ");
                string illustrator = Console.ReadLine();
                Console.Write("Enter the issue number: ");
                int issueNumber = int.Parse(Console.ReadLine());
                media = new ComicBook(title, author, genre, publisher, releaseDateDT, chaptersC, pagesC, descriptionC, illustrator, issueNumber);
                break;
            case 3:
                Console.Write("Enter the narrator: ");
                string narrator = Console.ReadLine();
                Console.Write("Enter the number of tracks: ");
                trackNumber = int.Parse(Console.ReadLine());
                trackList = new();
                for (int i = 0; i < trackNumber; i++)
                {
                    Console.Write("Enter the track name: ");
                    string trackName = $"{i}-{Console.ReadLine()}";
                    trackList.Add(trackName);
                }
                media = new AudioBook(title, author, genre, publisher, releaseDateDT, narrator, trackList);
                break;

            case 4:
                Console.Write("Enter the number of tracks: ");
                trackNumber = int.Parse(Console.ReadLine());
                trackList = new();
                for (int i = 0; i < trackNumber; i++)
                {
                    Console.Write("Enter the track name: ");
                    string trackName = $"{i}-{Console.ReadLine()}";
                    trackList.Add(trackName);
                }
                media = new AudioCD(title, author, genre, publisher, releaseDateDT, trackList);
                break;

            case 5:
                Console.Write("Enter the support type: ");
                string supportType = Console.ReadLine();
                Console.Write("Enter the director: ");
                string director = Console.ReadLine();
                Console.Write("Enter the description: ");
                string descriptionM = Console.ReadLine();
                Console.Write("Enter the length: ");
                int length = int.Parse(Console.ReadLine());
                media = new Movie(title, author, genre, publisher, releaseDateDT, supportType, director, descriptionM, length);
                break;
            case 6:
                Console.Write("Enter the support type: ");
                string supportTypeS = Console.ReadLine();
                Console.Write("Enter the director: ");
                string directorS = Console.ReadLine();
                Console.Write("Enter the description: ");
                string descriptionS = Console.ReadLine();
                Console.Write("Enter the season: ");
                int season = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of episodes: ");
                int numberOfEpisodes = int.Parse(Console.ReadLine());
                Console.Write("Enter the episode length: ");
                int episodeLength = int.Parse(Console.ReadLine());
                media = new Series(title, author, genre, publisher, releaseDateDT, supportTypeS, directorS, descriptionS, season, numberOfEpisodes, episodeLength);
                break;
        }
        if (media != null)
        {
            if (_media.Count > 0)
            {
                int lastId = _media[_media.Count - 1].GetId();
                media.SetId(lastId + 1);
            }
            else
            {
                media.SetId(1);
            }
            _media.Add(media);
        }
    }

    /// <summary> Adds a media to the library. </summary>
    /// <param name="media"> The media to add. </param>
    public void AddMedia(Media media)
    {
        _media.Add(media);
    }

    /// <summary> Returns the media at the given index. </summary>
    /// <param name="idx"> The index of the media to return. </param>
    /// <returns> The media at the given index. </returns>
    public Media GetMedia(int idx)
    {
        return _media[idx - 1];
    }

    /// <summary> Returns a list of media that match the given filter. If a filter is not given, it will not be used. </summary>
    /// <param name="title"> The title of the media. </param>
    /// <param name="author"> The author of the media. </param>
    /// <param name="genre"> The genre of the media. </param>
    /// <param name="mediaType"> The type of media. </param>
    /// <returns> A list of media that match the given filter. </returns>
    public List<Media> GetMediaByFilter(string title = null, string author = null, string genre = null, string mediaType = null, bool init = false)
    {
        List<Media> mediaList = new List<Media>();
        if (init)
        {
            _filteredMedia = _media.ToList();
        }
        foreach (Media media in _filteredMedia)
        {
            if (((title != null && media.GetTitle().ToLower() == title.ToLower()) || title == null)
             && ((author != null && media.GetAuthor().ToLower() == author.ToLower()) || author == null)
             && ((genre != null && media.GetGenre().ToLower() == genre.ToLower()) || genre == null)
             && ((mediaType != null && media.GetType().Name.ToLower() == mediaType.ToLower()) || mediaType == null))
            {
                mediaList.Add(media);
            }
        }
        return mediaList;
    }

    /// <summary> Removes the media at the given index. </summary>
    /// <param name="idx"> The index of the media to remove. </param>
    public void RemoveMedia(int idx)
    {
        _media.RemoveAt(idx - 1);
    }

    /// <summary> Adds a user to the library. </summary>
    /// <param name="user"> The user to add. </param>
    public void AddUser(User user)
    {
        if (_users.Count > 0)
        {
            int lastId = _users[_users.Count - 1].GetId();
            user.SetId(lastId + 1);
        }
        else
        {
            user.SetId(1);
        }
        _users.Add(user);
    }

    /// <summary> Returns the user at the given index. </summary>
    /// <param name="idx"> The id of the user to return which corresponds to the list index. </param>
    /// <returns> The user at the given index. </returns>
    public User GetUser(int idx)
    {
        return _users[idx - 1];
    }

    /// <summary> Returns a user that matches the given filter. If a filter is not given, it will not be used. </summary>
    /// <param name="lastName"> The last name of the user. </param>
    /// <param name="email"> The email of the user. </param>
    /// <param name="phone"> The phone number of the user. </param>
    /// <returns> A user that matches the given filter. </returns>
    public List<User> GetUserByFilter(string lastName = null, string email = null, DateTime? birthDate = null, bool init = false)
    {
        List<User> userList = new List<User>();
        if (init)
        {
            _filteredUsers = _users.ToList();
        }
        foreach (User user in _filteredUsers)
        {
            if (((lastName != null && user.GetLastName().ToLower() == lastName.ToLower()) || lastName == null)
             && ((email != null && user.GetEmail().ToLower() == email.ToLower()) || email == null)
             && ((birthDate != null && user.GetBirthDate().Equals(birthDate)) || birthDate == null))
            {
                userList.Add(user);
            }
        }
        _filteredUsers = userList;
        return _filteredUsers;
    }

    /// <summary> Activate the user at the given index. </summary>
    /// <param name="idx"> The index of the user to activate. </param>
    public void ActivateUser(int idx)
    {
        _users[idx - 1].Activate();
    }

    /// <summary> Deactivate the user at the given index. </summary>
    /// <param name="idx"> The index of the user to deactivate. </param>
    public void DeactivateUser(int idx)
    {
        _users[idx - 1].Deactivate();
    }

    /// <summary> Borrows a media to a user. </summary>
    /// <param name="userId"> The id of the user. </param>
    /// <param name="mediaId"> The id of the media. </param>
    public void BorrowMedia(int userId, int mediaId)
    {
        _media[mediaId - 1].Borrowed(userId, DateTime.Now, DateTime.Now.AddMonths(1));
        _users[userId - 1].AddBorrowedMediaIdx(mediaId);
    }

    /// <summary> Returns a media from a user. </summary>
    /// <param name="userId"> The id of the user. </param>
    /// <param name="mediaId"> The id of the media. </param>
    public void ReturnMedia(int userId, int mediaId)
    {
        _media[mediaId - 1].Returned();
        _users[userId - 1].RemoveBorrowedMediaIdx(mediaId);
    }

    public void RemoveUser(int idx)
    {
        _users.RemoveAt(idx - 1);
    }

    /// <summary> Saves the library to a file. It can save users or media depending on the saveUsers parameter value (default: Media). </summary>
    /// <param name="filename"> The name of the file to save to. </param>
    /// <param name="saveUsers"> If true it saves the users else it saves the media </param>
    public void Save(string filename, bool saveUsers = false)
    {
        using (StreamWriter outputFile = new(filename))
        {
            if (saveUsers)
            {
                foreach (User user in _users)
                {
                    outputFile.WriteLine(user.GetSavingString());
                }
            }
            else
            {
                foreach (Media media in _media)
                {
                    outputFile.WriteLine(media.GetSavingString());
                }
            }
        }
    }

    /// <summary> Loads the library from a file. It can load users or media depending on the loadUsers parameter value (default: Media). </summary>
    /// <param name="filename"> The name of the file to load from. </param>
    /// <param name="loadUsers"> If true it loads the users else it loads the media </param>
    public void Load(string filename, bool loadUsers = false)
    {
        if (loadUsers)
        {
            _users.Clear();
            _filteredUsers.Clear();
        }
        else
        {
            _media.Clear();
            _filteredMedia.Clear();
        }
        using (StreamReader inputFile = new(filename))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                if (loadUsers)
                {
                    string[] user = line.Split('\\');
                    string[] userData = user[0].Split('|');
                    string[] userMedia = new string[0];
                    try
                    {
                        userMedia = user[1].Split('|');
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                    int[] userMediaIdx = new int[userMedia.Length];
                    for (int i = 0; i < userMedia.Length; i++)
                    {
                        userMediaIdx[i] = int.Parse(userMedia[i]);
                    }
                    string[] userBirthDate = userData[4].Split('-');
                    AddUser(new User(int.Parse(userData[0]), userData[1], userData[2], userData[3], new DateTime(int.Parse(userBirthDate[0]), int.Parse(userBirthDate[1]), int.Parse(userBirthDate[2])), bool.Parse(userData[5]), userMediaIdx.ToList()));
                }
                else
                {
                    string[] media = line.Split('\\');
                    string mediaType = media[0];
                    string[] mediaData = media[1].Split('|');
                    string[] mediaReleaseDate = mediaData[5].Split('-');
                    string[] mediaBorrowStartDate = mediaData[8].Split('-');
                    string[] mediaBorrowEndDate = mediaData[9].Split('-');
                    int mediaId = int.Parse(mediaData[0]);
                    string mediaTitle = mediaData[1];
                    string mediaAuthor = mediaData[2];
                    string mediaGenre = mediaData[3];
                    string mediaPublisher = mediaData[4];
                    DateTime mediaRelease = new DateTime(int.Parse(mediaReleaseDate[0]), int.Parse(mediaReleaseDate[1]), int.Parse(mediaReleaseDate[2]));
                    bool mediaBorrowed = bool.Parse(mediaData[6]);
                    int mediaBorrowerUserId = int.Parse(mediaData[7]);
                    DateTime mediaBorrowStartDateDT = new DateTime(int.Parse(mediaBorrowStartDate[0]), int.Parse(mediaBorrowStartDate[1]), int.Parse(mediaBorrowStartDate[2]));
                    DateTime mediaBorrowEndDateDT = new DateTime(int.Parse(mediaBorrowEndDate[0]), int.Parse(mediaBorrowEndDate[1]), int.Parse(mediaBorrowEndDate[2]));
                    Media mediaObject = null;

                    switch (mediaType)
                    {
                        case "AudioBook":
                            string[] audioBookTracks = media[2].Split('|');
                            string narrator = media[3];
                            mediaObject = new AudioBook(mediaTitle, mediaAuthor, mediaGenre, mediaPublisher, mediaRelease, narrator, audioBookTracks.ToList());
                            break;
                        case "AudioCD":
                            string[] audioCDTracks = media[2].Split('|');
                            mediaObject = new AudioCD(mediaTitle, mediaAuthor, mediaGenre, mediaPublisher, mediaRelease, audioCDTracks.ToList());
                            break;
                        case "Book":
                            string[] bookInfo = media[2].Split('|');
                            int chapters = int.Parse(bookInfo[0]);
                            int pages = int.Parse(bookInfo[1]);
                            string description = bookInfo[2];
                            mediaObject = new Book(mediaTitle, mediaAuthor, mediaGenre, mediaPublisher, mediaRelease, chapters, pages, description);
                            break;
                        case "ComicBook":
                            string[] comicBookInfo = media[2].Split('|');
                            int chaptersC = int.Parse(comicBookInfo[0]);
                            int pagesC = int.Parse(comicBookInfo[1]);
                            string descriptionC = comicBookInfo[2];
                            string illustrator = comicBookInfo[3];
                            int issue = int.Parse(comicBookInfo[4]);
                            mediaObject = new ComicBook(mediaTitle, mediaAuthor, mediaGenre, mediaPublisher, mediaRelease, chaptersC, pagesC, descriptionC, illustrator, issue);
                            break;
                        case "Movie":
                            string[] movieInfo = media[2].Split('|');
                            string supportType = movieInfo[0];
                            string director = movieInfo[1];
                            string descriptionM = movieInfo[2];
                            int length = int.Parse(movieInfo[3]);
                            mediaObject = new Movie(mediaTitle, mediaAuthor, mediaGenre, mediaPublisher, mediaRelease, supportType, director, descriptionM, length);
                            break;
                        case "Series":
                            string[] seriesInfo = media[2].Split('|');
                            string supportTypeS = seriesInfo[0];
                            string directorS = seriesInfo[1];
                            string descriptionS = seriesInfo[2];
                            int season = int.Parse(seriesInfo[3]);
                            int numberOfEpisodes = int.Parse(seriesInfo[4]);
                            int episodeLength = int.Parse(seriesInfo[5]);
                            mediaObject = new Series(mediaTitle, mediaAuthor, mediaGenre, mediaPublisher, mediaRelease, supportTypeS, directorS, descriptionS, season, numberOfEpisodes, episodeLength);
                            break;
                        default:
                            break;
                    }
                    if (mediaObject != null)
                    {
                        mediaObject.SetId(mediaId);

                        if (mediaBorrowed)
                        {
                            mediaObject.Borrowed(mediaBorrowerUserId, mediaBorrowStartDateDT, mediaBorrowEndDateDT);
                        }

                        AddMedia(mediaObject);
                    }
                }
            }
        }
    }

    public Library()
    {
        _media = new List<Media>();
        _filteredMedia = new List<Media>();
        _users = new List<User>();
        _filteredUsers = new List<User>();
    }
}