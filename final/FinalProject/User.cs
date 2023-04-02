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

    public void AddBorrowedMediaIdx(int idx)
    {
        _borrowedMediaIdx.Add(idx);
    }

    public void RemoveBorrowedMediaIdx(int idx)
    {
        _borrowedMediaIdx.Remove(idx);
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public void SetId(int id)
    {
        _id = id;
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    public void Activate()
    {
        _isActive = true;
    }

    public string GetSavingString()
    {
        string savingString = $"{_id}|{_name}|{_lastName}|{_email}|{_birthDate.ToString("yyyy-MM-dd")}|{_isActive}\\";
        foreach (int idx in _borrowedMediaIdx)
        {
            savingString += $"{idx}|";
        }
        savingString = savingString.Remove(savingString.Length - 1);
        return savingString;
    }
    
    public void Display()
    {
        Console.WriteLine($"Id: {_id}");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Last Name: {_lastName}");
        Console.WriteLine($"Email: {_email}");
        Console.WriteLine($"Birth Date: {_birthDate.ToString("yyyy-MM-dd")}");
        Console.WriteLine($"Active: {_isActive}");
        Console.WriteLine("Borrowed Media:");
        foreach (int idx in _borrowedMediaIdx)
        {
            Console.WriteLine(idx);
        }
    }

    public User(string name, string lastName, string email, DateTime birthDate)
    {
        _id = 0;
        _name = name;
        _lastName = lastName;
        _email = email;
        _birthDate = birthDate;
        _borrowedMediaIdx = new List<int>();
        _isActive = true;
    }

    public User(int id, string name, string lastName, string email, DateTime birthDate, bool isActive, List<int> borrowedMediaIdx)
    {
        _id = id;
        _name = name;
        _lastName = lastName;
        _email = email;
        _birthDate = birthDate;
        _borrowedMediaIdx = borrowedMediaIdx.ToList();
        _isActive = isActive;
    }
}