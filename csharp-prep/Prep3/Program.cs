using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = 0;
        Random rand = new();
        int num = rand.Next(1,100);

        do{
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            if(guess < num)
            {
                Console.WriteLine("Higher");
            }
            else if(guess > num)
            {
                Console.WriteLine("Lower");
            }
        } while(guess != num);

        Console.WriteLine("You guessed it!");
    }
}