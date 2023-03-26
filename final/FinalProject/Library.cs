class Library
{
    private List<Media> _media;
    private List<User> _users;

    /// <summary> Adds a media to the library. </summary>
    /// <param name="media"> The media to add. </param>
    public void AddMedia(Media media)
    {
        if (_media.Count > 0)
        {
            int lastId = _media[_media.Count - 1].GetId();
            media.SetId(lastId + 1);
        }
        else
        {
            media.SetId(0);
        }
        _media.Add(media);
    }

    /// <summary> Returns the media at the given index. </summary>
    /// <param name="idx"> The index of the media to return. </param>
    /// <returns> The media at the given index. </returns>
    public Media GetMedia(int idx)
    {
        return _media[idx];
    }

    /// <summary> Returns a list of media that match the given filter. If a filter is not given, it will not be used. </summary>
    /// <param name="title"> The title of the media. </param>
    /// <param name="author"> The author of the media. </param>
    /// <param name="genre"> The genre of the media. </param>
    /// <param name="mediaType"> The type of media. </param>
    /// <returns> A list of media that match the given filter. </returns>
    public List<Media> GetMediaByFilter(string title = null, string author = null, string genre = null, string mediaType = null)
    {
        List<Media> mediaList = new List<Media>();
        foreach (Media media in _media)
        {
            if ((media.GetTitle() == title || title == null)
             && (media.GetAuthor() == author || author == null)
             && (media.GetGenre() == genre || genre == null)
             && (media.GetMediaType() == mediaType || mediaType == null))
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
        _media.RemoveAt(idx);
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
            user.SetId(0);
        }
        _users.Add(user);
    }

    /// <summary> Returns the user at the given index. </summary>
    /// <param name="idx"> The id of the user to return which corresponds to the list index. </param>
    /// <returns> The user at the given index. </returns>
    public User GetUser(int idx)
    {
        return _users[idx];
    }

    /// <summary> Returns a user that matches the given filter. If a filter is not given, it will not be used. </summary>
    /// <param name="lastName"> The last name of the user. </param>
    /// <param name="email"> The email of the user. </param>
    /// <param name="phone"> The phone number of the user. </param>
    /// <returns> A user that matches the given filter. </returns>
    public List<User> getUserByFilter(string lastName = null, string email = null)
    {
        List<User> userList = new();
        foreach (User user in _users)
        {
            if ((user.GetLastName() == lastName || lastName == null)
             && (user.GetEmail() == email || email == null))
            {
                userList.Add(user);
            }
        }
        return userList;
    }

    public void RemoveUser(int idx)
    {
        _users.RemoveAt(idx);
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
        // TODO: Implement Load method
    }
}