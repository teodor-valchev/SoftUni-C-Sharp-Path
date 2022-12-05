using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int primaryDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {

                        primaryDiagonal += matrix[row, col];
                    }
                }
            }
            int secondaryDiagonal = 0;
            int counter = size - 1;
            for (int row = 0; row < size; row++)
            {
                secondaryDiagonal += matrix[row, counter];
                counter--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));

        }
    }
}
