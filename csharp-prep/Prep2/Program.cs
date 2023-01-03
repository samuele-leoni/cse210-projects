using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Insert your grade percentage: ");
        int gradeNum = int.Parse(Console.ReadLine());
        string gradeStr = "";

        if(gradeNum >= 90)
        {
            gradeStr = "A";
        }
        else if(gradeNum >= 80)
        {
            gradeStr = "B";
        }
        else if(gradeNum >= 70)
        {
            gradeStr = "C";
        }
        else if(gradeNum >= 60)
        {
            gradeStr = "D";
        }
        else
        {
            gradeStr = "F";
        }

        Console.WriteLine($"Your grade is {gradeStr}.");
        Console.WriteLine(gradeNum >= 70?"Congratulations! You passed the class!":"Unfortunately you didn't pass.");
    }
}