class SimpleGoal : Goal
{
    private bool _done;
    public bool IsDone()
    {
        return _done;
    }
    public void MarkAsDone()
    {
        _done = true;
    }
    public override string GetSavingString()
    {
        return $"{base.GetSavingString()}, {_done}";
    }
    public SimpleGoal(string name, string description, int points): base(typeof(SimpleGoal).Name, name, description, points)
    {
        
    }
}