using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = size[0];
            int m = size[1];

            char[,] matrix = new char[n, m];

            int playerRow = -1;
            int playerCol = -1;
            bool isWon = false;
            bool isDead = false;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'P')// finding the player
                    {
                        playerRow = row;
                        playerCol = col;
                    }


                }

            }

            char[] directions = Console.ReadLine().ToCharArray();

            foreach (var direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;


                if (direction == 'U')
                {
                    newPlayerRow--;
                }
                else if (direction == 'D')
                {
                    newPlayerRow++;
                }
                else if (direction == 'L')
                {
                    newPlayerCol--;
                }
                else if (direction == 'R')
                {
                    newPlayerCol++;
                }

                if (!IsValidCell(newPlayerRow, newPlayerCol, n, m))
                {
                    isWon = true;
                    matrix[playerRow, playerCol] = '.';
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(matrix);
                    SpreadBunnies(bunniesCoordinates, matrix);
                }
                else if (matrix[newPlayerRow, newPlayerCol] == '.')
                {
                    matrix[playerRow, playerCol] = '.';
                    matrix[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(matrix);
                    SpreadBunnies(bunniesCoordinates, matrix);

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isDead = true;
                    }

                }
                else if (matrix[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    matrix[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(matrix);
                    SpreadBunnies(bunniesCoordinates, matrix);
                }



                if (isDead || isWon)
                {
                    break;
                }

            }
            PrintMatrix(matrix);
            string res = "";
            if (isWon)
            {
                res += "won";
            }
            else
            {
                res += "dead";
            }

            res += $": {playerRow} {playerCol}";
            Console.WriteLine(res);

        }

        private static void PrintMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    Console.Write(matrix[row, col]);

                }
                Console.WriteLine();

            }
        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] matrix)
        {

            foreach (int[] bunniesCoordinate in bunniesCoordinates)
            {
                int row = bunniesCoordinate[0];
                int col = bunniesCoordinate[1];
                SpreadBunnie(row - 1, col, matrix);
                SpreadBunnie(row + 1, col, matrix);
                SpreadBunnie(row, col - 1, matrix);
                SpreadBunnie(row, col + 1, matrix);



            }
        }

        private static void SpreadBunnie(int row, int col, char[,] matrix)
        {
            int rowLenght = matrix.GetLength(0);
            int colLenght = matrix.GetLength(1);

            if (IsValidCell(row, col, rowLenght, colLenght))// е нагоре
            {
                matrix[row, col] = 'B';
            }


        }

        private static List<int[]> GetBunniesCoordinates(char[,] matrix)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { row, col });
                    }
                }

            }
            return bunniesCoordinates;
        }

        private static bool IsValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
