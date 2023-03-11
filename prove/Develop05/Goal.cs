class Goal
{
    private string _type;
    private string _name;
    private string _description;
    private int _points;
    public virtual int PointsEarned()
    {
        return _points;
    }
    public string GetCompletionString()
    {
        return $"Congratulations! You have earned {PointsEarned()} points!";
    }
    public override string ToString()
    {
        return $"{_name} ({_description})";
    }
    public virtual string GetSavingString()
    {
        return $"{_type}:{_name},{_description},{_points}";
    }
    public Goal(string type, string name, string description, int points)
    {

    }
}