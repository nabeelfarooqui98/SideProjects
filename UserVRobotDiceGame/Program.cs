using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserVRobotDiceGame
{
    class Program
    {
        static void Main(string[] args)
        { //followed a tutorial for this, didn't try to copy code if I didn't need to, mainly saw what the program did and tried to replicate it
            Random rm = new Random();
            int randomUserDieNum;
            int randomAIDieNum;
            int userScore = 0;
            int aiScore = 0;
            int roundCount = 1;
            int roundMax = 5;
            for (int i = 0; i < roundMax; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Current Round: " + roundCount);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key to roll the dice.");
                randomUserDieNum = rm.Next(1, 7);
                Console.ReadKey(true);
                Console.WriteLine("You rolled a " + randomUserDieNum + ".");
                Console.WriteLine("");
                Console.WriteLine("...");
                Console.WriteLine("");
                Thread.Sleep(1000);
                randomAIDieNum = rm.Next(1, 7);
                Console.WriteLine($"Enemy AI rolled a {randomAIDieNum}");
                if(randomAIDieNum > randomUserDieNum)
                {
                    Console.WriteLine("Enemy AI won this round!");
                    aiScore++;
                } else if(randomAIDieNum < randomUserDieNum)
                {
                    Console.WriteLine($"User won this round!");
                    userScore++;
                } else
                {
                    Console.WriteLine("No one won. It's a standoff.");
                }
                Console.WriteLine("The score is now - User : " + userScore + ". Enemy : " + aiScore + ".");
                Console.WriteLine("");
                roundCount++;
            }
            if(aiScore > userScore)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("AI takes this game with a " + aiScore + " score!");
                Console.ForegroundColor = ConsoleColor.White;
            } else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("User takes this game with a " + userScore + " score!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadKey(true);
        }
    }
}
