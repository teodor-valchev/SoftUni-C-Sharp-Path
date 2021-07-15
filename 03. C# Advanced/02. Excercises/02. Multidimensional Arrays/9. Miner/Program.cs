using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            string[] directions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int playerRow = -1;
            int playerCol = -1;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                    

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 's')// finding the player
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }

            }
            bool isOver = false;
            foreach (var direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (direction == "up")
                {
                    newPlayerRow--;
                }

                else if (direction == "down")
                {
                    newPlayerRow++;
                }

                else if (direction == "left")
                {
                    newPlayerCol--;
                }

                else if (direction == "right")
                {
                    newPlayerCol++;
                }

                if (!isValidCell(newPlayerRow,newPlayerCol,n))
                {
                    continue;
                }
                else
                {
                    if (matrix[newPlayerRow,newPlayerRow] == '*')
                    {
                        matrix[playerRow, playerCol] = '*';
                        matrix[newPlayerRow, newPlayerCol] = 's';
                        playerRow = newPlayerRow;
                        playerCol = newPlayerCol;
                    }
                }
            }



        }

        private static bool isValidCell(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
