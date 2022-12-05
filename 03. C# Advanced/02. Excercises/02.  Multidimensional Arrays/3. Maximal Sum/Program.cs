using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int maxSum = 0;
            int maxCol = 0;
            int maxRow = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                         matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                         matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxCol = col;
                        maxRow = row;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");


            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {

                    Console.Write(matrix[row, col] + " ");

                }
                Console.WriteLine();
            }

        }
    }
}
