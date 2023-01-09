using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int num = 0;

        do{
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            if(num != 0)
            {
                numbers.Add(num);
            }
        }while(num != 0);

        int sum = 0;

        foreach(int x in numbers)
        {
            sum += x;
        }

        double avg = (double)sum/numbers.Count;

        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");
    }
}