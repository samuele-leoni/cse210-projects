class Game
{
    private List<Goal> _goals;
    private int _points;
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
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSavingString());
            }
        }
    }
    public void Load(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
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
                        ChecklistGoal checklistGoal = new ChecklistGoal(goalInfo[0], goalInfo[1], int.Parse(goalInfo[2]), int.Parse(goalInfo[3]), int.Parse(goalInfo[4]));
                        for(int i = 0; i < int.Parse(goalInfo[5]); i++)
                        {
                            //TODO after implementing RecordEvent() checklistGoal.RecordEvent();
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
    }
    public void Display()
    {
        //TODO: Add logic to display game
    }
    public Game()
    {
        _goals = new List<Goal>();
    }
}