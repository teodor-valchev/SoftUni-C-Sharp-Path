using System;
using System.Collections.Generic;
using System.Linq;

namespace practise
{

    class Program
    {

        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] battleField = new char[sizeOfMatrix, sizeOfMatrix];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < battleField.GetLength(1); col++)
                {
                    battleField[row, col] = input[col];

                    if (battleField[row, col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            bool armyWin = true;
            string comands = Console.ReadLine();
            while (lives > 0)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                string[] tokens = comands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                int rowSpawn = int.Parse(tokens[1]);
                int colSpawn = int.Parse(tokens[2]);
                SpawnOrcs(battleField, rowSpawn, colSpawn);

                if (direction == "D")
                {
                    newPlayerCol++;
                }
                else if (direction == "A")
                {
                    newPlayerCol--;
                }
                else if (direction == "W")
                {
                    newPlayerRow--;
                }
                else if (direction == "S")
                {
                    newPlayerRow++;
                }
                lives--;

                if (IsValid(battleField, newPlayerRow, newPlayerCol) && battleField[newPlayerRow, newPlayerCol] == '-')
                {
                    battleField[playerRow, playerCol] = '-';
                    battleField[newPlayerRow, newPlayerCol] = 'M';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
                else if (IsValid(battleField, newPlayerRow, newPlayerCol) && battleField[newPlayerRow, newPlayerCol] == 'P')
                {
                    battleField[playerRow, playerCol] = '-';
                    battleField[newPlayerRow, newPlayerCol] = '-';
                    armyWin = true;
                    break;
                }
                else if (IsValid(battleField, newPlayerRow, newPlayerCol) && battleField[newPlayerRow, newPlayerCol] == 'B')
                {
                    lives -= 2;

                    if (lives <= 0)
                    {
                        battleField[playerRow, playerCol] = '-';
                        battleField[newPlayerRow, newPlayerCol] = 'X';
                        playerRow = newPlayerRow;
                        playerCol = newPlayerCol;
                        armyWin = false;
                        break;
                    }
                    else
                    {
                        battleField[playerRow, playerCol] = '-';
                        battleField[newPlayerRow, newPlayerCol] = 'M';
                        playerRow = newPlayerRow;
                        playerCol = newPlayerCol;
                    }


                }

                comands = Console.ReadLine();
            }

            if (armyWin == true)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left:  {lives}");
                Print(battleField);
            }
            else
            {
                Console.WriteLine($"Mario died at {playerRow};{playerCol}.");
                Print(battleField);
            }
        }

        private static bool IsValid(char[,] battleField, int row, int col)
        {
            return row >= 0 && row < battleField.GetLength(0) && col >= 0 && col < battleField.GetLength(1);
        }

        private static void SpawnOrcs(char[,] battleField, int row, int col)
        {
            int spawnrow = row;
            int spawnCol = col;
            for (row = 0; row < battleField.GetLength(0); row++)
            {


                for (col = 0; col < battleField.GetLength(1); col++)
                {
                    if (spawnrow == row && spawnCol == col)
                    {
                        battleField[row, col] = 'B';
                    }
                }

            }
        }

        private static void Print(char[,] battleField)
        {
            for (int row = 0; row < battleField.GetLength(0); row++)
            {

                for (int col = 0; col < battleField.GetLength(1); col++)
                {
                    Console.Write(battleField[row, col]);
                }
                Console.WriteLine();


            }
        }
    }
}
