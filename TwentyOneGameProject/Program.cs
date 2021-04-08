using System;
using System.Threading;

namespace TwentyOneGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Random random = new Random();
            int coinBalance = 1000;
            int userCardCount = 0;
            Console.WriteLine("Welcome to 21, created by Carlos Hernandez in C#");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your current Balance of Coins is {coinBalance}.");
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                if (userCardCount > 21)
                {
                    coinBalance = coinBalance - 100;
                    userCardCount = 0;
                    Console.WriteLine("");
                    Console.WriteLine("Bust! You've went over 21 and lost.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your coin balance is now {coinBalance}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("New game? yes or no");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    string newGameAns = Console.ReadLine();
                    Console.WriteLine("");
                    if (newGameAns.Equals("yes")){
                        Console.WriteLine("Starting a new one.");
                    } else if (newGameAns.Equals("no"))
                    {
                        break;
                    }
                } else if(userCardCount == 21)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You win! Nice perfect 21.");
                    coinBalance += 100;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your coin balance is now {coinBalance}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    userCardCount = 0;
                    Console.WriteLine("");
                    Console.WriteLine("New game? yes or no");
                    Console.WriteLine("");
                    string newGameAnswerr = Console.ReadLine();
                    Console.WriteLine("");
                    if (newGameAnswerr.Equals("yes"))
                    {
                        Console.WriteLine("Starting a new one.");
                    }
                    else if (newGameAnswerr.Equals("no"))
                    {
                        break;
                    }
                    continue;
                } else
                {
                    Console.WriteLine(""); //spacer
                }
                if (coinBalance < 0)
                {
                    Console.WriteLine("You've lost all your money!");
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Would you like to draw, or stand?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string userInput = Console.ReadLine();
                Console.WriteLine("");
                if (userInput.Equals("draw"))
                {
                    int draw = random.Next(1, 11);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"You've drawn a {draw}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    userCardCount += draw;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Your total card count is {userCardCount}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                } else if (userInput.Equals("stand"))
                {
                    Console.WriteLine($"You've stood with {userCardCount}.");
                    Console.WriteLine("");
                    coinBalance = DealersTurn(userCardCount, coinBalance);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your coin balance is now {coinBalance}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    userCardCount = 0;
                    Console.WriteLine("");
                    Console.WriteLine("New game? yes or no");
                    Console.WriteLine("");
                    string newGameAnswer = Console.ReadLine();
                    Console.WriteLine("");
                    if (newGameAnswer.Equals("yes"))
                    {
                        Console.WriteLine("Starting a new one.");
                    }
                    else if (newGameAnswer.Equals("no"))
                    {
                        break;
                    }
                    continue;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game over.");
        }

        private static int DealersTurn(int userCardCount, int coinBalance)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It is now the dealers turn.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            int dealerCardCount = 0;
            Random random = new Random();
            while (true)
            {
                if (dealerCardCount <= 21 && dealerCardCount > userCardCount)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The dealer has won. His cards equal {dealerCardCount}, while yours equal {userCardCount}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return coinBalance - 100;
                }
                else if (dealerCardCount > 21)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Bust! The dealer lost. You win.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return coinBalance + 100;

                }
                else if (dealerCardCount == userCardCount)
                {
                    Console.WriteLine("It's a standoff. Draw.");
                    return coinBalance;
                }
                else if (dealerCardCount < 21)
                {
                    int dealerDraw = random.Next(1, 11);
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"The dealer pulls a {dealerDraw}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    dealerCardCount += dealerDraw;

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Their current card count is {dealerCardCount}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    continue;
                }
            }
        }
    }
}
