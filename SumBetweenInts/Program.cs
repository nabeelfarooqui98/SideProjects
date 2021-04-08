using System;

namespace SumBetweenInts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSumBetween(2,6));
        }
        static int GetSumBetween(int first, int second)
        {
            int Sum = 0;
            first += 1;
            while(first <= second - 1)
            {
                Sum = Sum + first;
                first++;
            }
            return Sum;
        }
    }
}
