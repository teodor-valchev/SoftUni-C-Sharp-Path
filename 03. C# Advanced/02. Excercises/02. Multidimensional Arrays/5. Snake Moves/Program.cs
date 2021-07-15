using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            string[,] matrix = new string[size[0], size[1]];
            string input = Console.ReadLine();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    for (int i = matrix.GetLength(0); i < input.Length; i++)
                    {
                        Console.Write(input);
                    }
                }               
            }
        }
    }
}
