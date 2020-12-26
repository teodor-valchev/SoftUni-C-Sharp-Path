using System;
using System.Linq;

namespace _6._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int evensum = 0;
            int oddsum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentnum = numbers[i];
                if (currentnum%2==0)
                {
                    evensum += currentnum;
                }
                else if (currentnum%2==1)
                {
                    oddsum += currentnum;
                }
            }
            int result = evensum - oddsum;
            Console.WriteLine(result);
        }
    }
}
