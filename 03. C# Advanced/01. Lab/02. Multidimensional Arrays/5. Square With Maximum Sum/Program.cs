using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] arr = Console.ReadLine().Split(", ")
             .Select(int.Parse)
             .ToArray();


                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[row, cols] = arr[cols];

                }

            }

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                

                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    int sum = matrix[row, col] + matrix[row , col+1] + matrix[row+1, col] + matrix[row+1, col + 1];

                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }

                
            }

            for (int row = maxRow; row < maxRow+2; row++)
            {
                for (int col = maxCol; col < maxCol+2; col++)
                {
                    Console.Write(matrix[row,col]+ " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);

        }
    }
}
