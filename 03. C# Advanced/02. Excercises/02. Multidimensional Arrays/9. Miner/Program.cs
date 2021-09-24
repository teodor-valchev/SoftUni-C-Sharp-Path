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
            int playerRow = 0;
            int playerCol = 0;

            int totalCoal = 0;
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
                    if (matrix[row, col] == 'c')
                    {
                        totalCoal++;
                    }
                }

            }
            bool commandsLeft = true;

            foreach (var direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (direction == "left")
                {
                    newPlayerCol--;
                }
                else if (direction == "right")
                {
                    newPlayerCol++;
                }
                else if (direction == "up")
                {
                    newPlayerRow--;
                }
                else if (direction == "down")
                {
                    newPlayerRow++;
                }

                if (isValid(matrix, newPlayerRow, newPlayerCol) && matrix[newPlayerRow, newPlayerCol] == '*')
                {
                    matrix[playerRow, playerCol] = '*';
                    matrix[newPlayerRow, newPlayerCol] = 's';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
                if (isValid(matrix, newPlayerRow, newPlayerCol) && matrix[newPlayerRow, newPlayerCol] == 'c')
                {
                    matrix[playerRow, playerCol] = '*';
                    matrix[newPlayerRow, newPlayerCol] = 's';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    totalCoal--;

                    if (totalCoal == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({newPlayerRow}, {newPlayerCol})");
                        commandsLeft = false;
                        break;
                    }


                }
                if (isValid(matrix, newPlayerRow, newPlayerCol) && matrix[newPlayerRow, newPlayerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({newPlayerRow}, {newPlayerCol})");
                    commandsLeft = false;
                    break;
                }
               

            }
            if (commandsLeft)
            {
                Console.WriteLine($"{totalCoal} coals left. ({playerRow}, {playerCol})");
            }

        }

        private static bool isValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void Print(char[,] matrix, int row, int col)
        {

            for (row = 0; row < matrix.GetLength(0); row++)
            {

                for (col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");

                }
                Console.WriteLine();


            }
        }
    }
}
