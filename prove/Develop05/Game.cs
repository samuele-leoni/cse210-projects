class Game
{
    private List<Goal> _goals;
    private int _points;
    public int GetNumberOfGoals()
    {
        return _goals.Count;
    }
    public void RecordEvent(Goal goal)
    {
        _points += goal.PointsEarned();
        goal.MarkAsDone();
        Console.WriteLine(goal.GetCompletionString());
    }
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public Goal GetGoal(int goalIdx)
    {
        return _goals[goalIdx];
    }
    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_points.ToString());
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSavingString());
            }
        }
    }
    public void Load(string filename)
    {
        _goals = new List<Goal>();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (line == lines[0])
            {
                _points = int.Parse(line);
                continue;
            }
            string[] typesAndGoals = line.Split(':');
            string type = typesAndGoals[0];
            string[] goalInfo = typesAndGoals[1].Split(',');
            Goal goal = null;
            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]));
                    if (bool.Parse(goalInfo[3]))
                    {
                        goal.MarkAsDone();
                    }
                    break;
                case "ChecklistGoal":
                    goal = new ChecklistGoal(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]), int.Parse(goalInfo[4]), int.Parse(goalInfo[3]));
                    for (int i = 0; i < int.Parse(goalInfo[5]); i++)
                    {
                        goal.MarkAsDone();
                    }
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]));
                    break;
            }
            if(goal != null)
            {
                _goals.Add(goal);
            }
        }
    }
    public void DisplayActiveGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            if (!_goals[i].IsDone())
            {
                Console.WriteLine($"{i + 1}. {_goals[i]}");
            }
        }
    }
    public void Display()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. [{(_goals[i].IsDone() ? 'X' : ' ')}] {_goals[i]}");
        }
    }
    public int GetPoints()
    {
        return _points;
    }
    public Game()
    {
        _points = 0;
        _goals = new List<Goal>();
    }
}