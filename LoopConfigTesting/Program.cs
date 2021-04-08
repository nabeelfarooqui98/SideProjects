using System;

namespace LoopConfigTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            printBetween(5, 20);
        }
        static void printBetween(int first, int second)
        {
            for(int i = first; i <= second; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
