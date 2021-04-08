using System;

namespace HotOrCold
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rm = new Random();
            int randomNum = rm.Next(0, 100);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("I've generated a random number from 0 to 100, guess and I'll tell you if you're hot or cold. ;)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            while (true)
            {
                int userInput = Int32.Parse(Console.ReadLine());

                if (randomNum == userInput)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got it! Nice going!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else if (Math.Abs(randomNum - userInput) < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're super hot!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (Math.Abs(randomNum - userInput) < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're hot!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (Math.Abs(randomNum - userInput) < 30)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're warm!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (Math.Abs(randomNum - userInput) < 40)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("You're getting kind of cold!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (Math.Abs(randomNum - userInput) < 50)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You're cold!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (Math.Abs(randomNum - userInput) < 60)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You're freezing!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }
        }
    }
}
