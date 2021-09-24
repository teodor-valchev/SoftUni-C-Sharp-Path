using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            string[] coordinatesValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int activeCells = 0;
            int sum = 0;

            for (int i = 0; i < coordinatesValues.Length; i++)
            {
                string[] splitted = coordinatesValues[i].Split(",");
                int cuurentRow = int.Parse(splitted[0]);
                int cuurentCol = int.Parse(splitted[1]);
                int bombDamage = matrix[cuurentRow, cuurentCol];

                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == cuurentRow && col == cuurentCol)
                        {


                            if (IsInside(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                            {

                                matrix[cuurentRow, cuurentCol - 1] -= bombDamage;
                            }
                            if (IsInside(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                            {
                                matrix[cuurentRow, cuurentCol + 1] -= bombDamage;

                            }
                            if (IsInside(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                            {
                                matrix[cuurentRow - 1, cuurentCol] -= bombDamage;


                            }
                            if (IsInside(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                            {
                                matrix[cuurentRow + 1, cuurentCol] -= bombDamage;

                            }
                            if (IsInside(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                            {
                                matrix[cuurentRow - 1, cuurentCol - 1] -= bombDamage;

                            }
                            if (IsInside(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                            {
                                matrix[cuurentRow - 1, cuurentCol + 1] -= bombDamage;

                            }
                            if (IsInside(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                            {
                                matrix[cuurentRow + 1, cuurentCol + 1] -= bombDamage;

                            }
                            if (IsInside(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                            {
                                matrix[cuurentRow + 1, cuurentCol - 1] -= bombDamage;

                            }
                            matrix[row, col] = 0;





                        }

                    }
                }


            }

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    activeCells++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");
            Print(matrix);





        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
