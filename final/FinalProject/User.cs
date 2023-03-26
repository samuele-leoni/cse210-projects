class User
{
    private int _id;
    private string _name;
    private string _lastName;
    private string _email;
    private DateTime _birthDate;
    private List<int> _borrowedMediaIdx;
    private bool _isActive;

    public int GetId()
    {
        return _id;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetLastName()
    {
        return _lastName;
    }
    
    public string GetEmail()
    {
        return _email;
    }

    public DateTime GetBirthDate()
    {
        return _birthDate;
    }

    public List<int> GetBorrowedMediaIdx()
    {
        return _borrowedMediaIdx;
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public void SetId(int id)
    {
        _id = id;
    }

    public void ToggleActive()
    {
        _isActive = !_isActive;
    }

    public string GetSavingString()
    {
        string savingString = _id + "," + _name + "," + _lastName + "," + _email + "," + _birthDate.ToString("yyyy-MM-dd") + "," + _isActive;
        foreach (int idx in _borrowedMediaIdx)
        {
            savingString += "," + idx;
        }
        return savingString;
    }
    
    public void Display()
    {
        //TODO: Display user info
    }

    public User(int id, string name, string lastName, string email, DateTime birthDate)
    {
        _id = id;
        _name = name;
        _lastName = lastName;
        _email = email;
        _birthDate = birthDate;
        _borrowedMediaIdx = new List<int>();
        _isActive = true;
    }
}