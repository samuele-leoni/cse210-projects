class ChecklistGoal : Goal
{
    private int _timesToGetBonus;
    private int _bonusPoints;
    private int _timesCompleted;
    public bool IsDone()
    {
        return _timesCompleted == _timesToGetBonus;
    }
    public override int PointsEarned()
    {
        return IsDone() ? base.PointsEarned() + _bonusPoints : base.PointsEarned();
    }
    public override string ToString()
    {
        return $"{base.ToString()} -- Currently Completed {_timesCompleted}/{_timesToGetBonus}";
    }
    public override string GetSavingString()
    {
        return $"{base.GetSavingString()},{_bonusPoints},{_timesToGetBonus},{_timesCompleted}";
    }
    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }
    public int GetTimesToGetBonus()
    {
        return _timesToGetBonus;
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    public ChecklistGoal(string name, string description, int points, int timesToGetBonus, int bonusPoints) : base(typeof(ChecklistGoal).Name, name, description, points)
    {
        _timesToGetBonus = timesToGetBonus;
        _bonusPoints = bonusPoints;
    }
}