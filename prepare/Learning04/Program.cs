using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        Console.WriteLine($"\nExample 1:\n{a1.GetSummary()}");
        Console.WriteLine($"\nExample 2:\n{a2.GetSummary()}\n{a2.GetHomeworkList()}");
        Console.WriteLine($"\nExample 3:\n{a3.GetSummary()}\n{a3.GetWritingInformation()}\n");
    }
}