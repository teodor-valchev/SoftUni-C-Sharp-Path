using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                }
            }
            bool win = false;
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                int currentPlayerRow = playerRow;
                int currentPlayerCol = playerCol;

                if (command == "right")
                {
                    currentPlayerCol++;
                }
                if (command == "left")
                {
                    currentPlayerCol--;
                }
                if (command == "up")
                {
                    currentPlayerRow--;
                }
                if (command == "down")
                {
                    currentPlayerRow++;
                }

                if (!isValid(field, currentPlayerRow, currentPlayerCol) && command == "left")
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow, field.GetLength(1) - 1] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = field.GetLength(1) - 1;

                }
                else if (!isValid(field, currentPlayerRow, currentPlayerCol) && command == "right")
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow, 0] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = 0;
                }
                else if (!isValid(field, currentPlayerRow, currentPlayerCol) && command == "up")
                {
                    field[playerRow, playerCol] = '-';
                    field[field.GetLength(0) - 1, playerCol] = 'f';
                    playerRow = field.GetLength(0) - 1;
                    playerCol = currentPlayerCol;

                }
                else if (!isValid(field, currentPlayerRow, currentPlayerCol) && command == "down")
                {
                    field[playerRow, playerCol] = '-';
                    field[0, playerCol] = 'f';
                    playerRow = 0;
                    playerCol = currentPlayerCol;
                }
                if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == '-')
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow, currentPlayerCol] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = currentPlayerCol;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "down")
                {
                    field[playerRow, playerCol] = '-';              
                    field[currentPlayerRow + 1, playerCol] = 'f';
                    playerRow = currentPlayerRow+1;
                    playerCol = currentPlayerCol;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "right")
                {
                    field[playerRow, playerCol] = '-';                
                    field[currentPlayerRow , playerCol+1] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = currentPlayerCol+1;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "up")
                {
                    field[playerRow, playerCol] = '-';                  
                    field[currentPlayerRow -1, playerCol] = 'f';
                    playerRow = currentPlayerRow-1;
                    playerCol = currentPlayerCol;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "left")
                {
                    field[playerRow, playerCol] = '-';             
                    field[currentPlayerRow , playerCol-1] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = currentPlayerCol-1;
                }
                else if (!isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "left")
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow, playerCol - 1] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = currentPlayerCol - 1;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "down")
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow + 1, playerCol] = 'f';
                    playerRow = currentPlayerRow + 1;
                    playerCol = currentPlayerCol;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "right")
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow, playerCol + 1] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = currentPlayerCol + 1;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "up")
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow - 1, playerCol] = 'f';
                    playerRow = currentPlayerRow - 1;
                    playerCol = currentPlayerCol;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'B' && command == "left")
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow, playerCol - 1] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = currentPlayerCol - 1;
                }
                else if (isValid(field, currentPlayerRow, currentPlayerCol) && field[currentPlayerRow, currentPlayerCol] == 'F')
                {
                    field[playerRow, playerCol] = '-';
                    field[currentPlayerRow,currentPlayerCol] = 'f';
                    playerRow = currentPlayerRow;
                    playerCol = currentPlayerCol;
                    win = true;
                    break;
                }
               
            }
            if (win==true)
            {
                Console.WriteLine("Player won!");
                Print(field);
            }
            else
            {
                Console.WriteLine("Player lost!");
                Print(field);
            }
          


        }

        private static bool isValid(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }

        private static void Print(char[,] field)
        {

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
