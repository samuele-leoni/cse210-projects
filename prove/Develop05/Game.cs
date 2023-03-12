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
        switch (goal.GetType().Name)
        {
            case "SimpleGoal":
                SimpleGoal simpleGoal = (SimpleGoal)goal;
                simpleGoal.MarkAsDone();
                break;
            case "ChecklistGoal":
                ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                checklistGoal.CheckDone();
                break;
        }
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
            switch (type)
            {
                case "SimpleGoal":
                    SimpleGoal simpleGoal = new SimpleGoal(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]));
                    if (bool.Parse(goalInfo[3]))
                    {
                        simpleGoal.MarkAsDone();
                    }
                    _goals.Add(simpleGoal);
                    break;
                case "ChecklistGoal":
                    ChecklistGoal checklistGoal = new ChecklistGoal(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]), int.Parse(goalInfo[4]), int.Parse(goalInfo[3]));
                    for (int i = 0; i < int.Parse(goalInfo[5]); i++)
                    {
                        checklistGoal.CheckDone();
                    }
                    _goals.Add(checklistGoal);
                    break;
                case "EternalGoal":
                    EternalGoal eternalGoal = new EternalGoal(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]));
                    _goals.Add(eternalGoal);
                    break;
            }
        }
    }
    public void DisplayActiveGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            bool isDone = false;
            if (_goals[i].GetType().Name == "SimpleGoal")
            {
                SimpleGoal simpleGoal = (SimpleGoal)_goals[i];
                isDone = simpleGoal.IsDone();
            }
            else if (_goals[i].GetType().Name == "ChecklistGoal")
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)_goals[i];
                isDone = checklistGoal.IsDone();
            }
            if (!isDone)
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
            char c = ' ';
            if(_goals[i].GetType().Name == "SimpleGoal")
            {
                SimpleGoal simpleGoal = (SimpleGoal)_goals[i];
                if (simpleGoal.IsDone())
                {
                    c = 'X';
                }
            }
            else if (_goals[i].GetType().Name == "ChecklistGoal")
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)_goals[i];
                if (checklistGoal.IsDone())
                {
                    c = 'X';
                }
            }
            Console.WriteLine($"{i + 1}. [{c}] {_goals[i]}");
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