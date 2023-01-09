using System;

class Program
{
    private static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    private static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    private static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favorite_number = int.Parse(Console.ReadLine());
        return favorite_number;
    }

    private static int SquareNumber(int num)
    {
        int sqrnum = num * num;
        return sqrnum;
    }

    private static void DisplayResult(string name, int sqrnum)
    {
        Console.WriteLine($"{name}, the square of your number is {sqrnum}");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int sqrnum = SquareNumber(num);
        DisplayResult(name, sqrnum);
    }
}