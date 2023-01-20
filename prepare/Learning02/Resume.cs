public class Resume
{
    public string _name { get; set; }
    public List<Job> _jobs = new();

    public void Display()
    {
        Console.WriteLine($"Name: {this._name}\nJobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}