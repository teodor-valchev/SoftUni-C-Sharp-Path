using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int resul = Sum(input, input.Length);
            Console.WriteLine(resul);
        }

        private static int Sum(int[] input, int index)
        {
            if (index == 0)
            {
                return 0;
            }
            return input[index-1] += Sum(input, index - 1);
        }
    }
}
