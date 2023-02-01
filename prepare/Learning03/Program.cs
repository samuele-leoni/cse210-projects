using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new(), f2 = new(5), f3 = new(3, 4), f4 = new(1, 3);

        Console.WriteLine($"{f1.GetFractionString()}\n{f1.GetDecimalValue()}\n{f2.GetFractionString()}\n{f2.GetDecimalValue()}\n{f3.GetFractionString()}\n{f3.GetDecimalValue()}\n{f4.GetFractionString()}\n{f4.GetDecimalValue()}");
    }
}