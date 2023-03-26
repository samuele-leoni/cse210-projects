class Media
{
    private int _id;
    private string _type;
    private string _title;
    private string _author;
    private string _genre;
    private string _publisher;
    private DateTime _releaseDate;
    private bool _isBorrowed;
    private int _borrowUserId;
    private DateTime _borrowStartDate;
    private DateTime _borrowEndDate;

    public void SetId(int id)
    {
        _id = id;
    }

    public int GetId()
    {
        return _id;
    }

    public string GetMediaType()
    {
        return _type;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public string GetGenre()
    {
        return _genre;
    }

    public string GetPublisher()
    {
        return _publisher;
    }

    public DateTime GetReleaseDate()
    {
        return _releaseDate;
    }

    public bool IsBorrowed()
    {
        return _isBorrowed;
    }

    public int GetBorrowUserId()
    {
        return _borrowUserId;
    }

    public DateTime GetBorrowStartDate()
    {
        return _borrowStartDate;
    }

    public DateTime GetBorrowEndDate()
    {
        return _borrowEndDate;
    }

    public virtual string GetSavingString()
    {
        return _id + "," + _type + "," + _title + "," + _author + "," + _genre + "," + _publisher + "," + _releaseDate.ToString("yyyy-MM-dd") + "," + _isBorrowed + "," + _borrowUserId + "," + _borrowStartDate.ToString("yyyy-MM-dd") + "," + _borrowEndDate.ToString("yyyy-MM-dd");
    }

    /// <summary> Sets the media as borrowed. It will also set the id of the user which borrowed it, the start date and the end date. </summary>
    /// <param name="userId"> The id of the user that borrowed the media. </param>
    /// <param name="startDate"> The date the media was borrowed. </param>
    /// <param name="endDate"> The date the media is due to be returned. </param>
    public void Borrowed(int userId, DateTime startDate, DateTime endDate)
    {
        _isBorrowed = true;
        _borrowUserId = userId;
        _borrowStartDate = startDate;
        _borrowEndDate = endDate;
    }

    /// <summary> Sets the media as returned. It will also reset the id of the user which borrowed it, the start date and the end date. </summary>
    public void Returned()
    {
        _isBorrowed = false;
        _borrowUserId = -1;
        _borrowStartDate = DateTime.MinValue;
        _borrowEndDate = DateTime.MinValue;
    }

    public virtual void Display()
    {
        //TODO: Display media info
    }

    public Media(int id, string type, string title, string author, string genre, string publisher, DateTime releaseDate)
    {
        _id = id;
        _type = type;
        _title = title;
        _author = author;
        _genre = genre;
        _publisher = publisher;
        _releaseDate = releaseDate;
        _isBorrowed = false;
        _borrowUserId = -1;
        _borrowStartDate = DateTime.MinValue;
        _borrowEndDate = DateTime.MinValue;
    }
}