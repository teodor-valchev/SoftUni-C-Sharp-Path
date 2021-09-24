using System;
using System.Linq;

namespace Pracise
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int removeKnight = 0;

            while (true)
            {
                int maxAtacks = 0;
                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < board.GetLength(0); row++)
                {

                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttack = 0;
                        if (board[row, col] != 'K')
                        {
                            continue;
                        }

                        if (isInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currentAttack++;
                        }
                        if (isInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                        {
                            currentAttack++;
                        }
                        if (isInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                        {
                            currentAttack++;
                        }
                        if (isInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currentAttack++;
                        }
                        if (isInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currentAttack++;
                        }
                        if (isInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currentAttack++;
                        }
                        if (isInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                        {
                            currentAttack++;
                        }

                        if (currentAttack > maxAtacks)
                        {
                            knightRow = row;
                            knightCol = col;
                            maxAtacks = currentAttack;
                        }
                    }

                }
                if (maxAtacks == 0)
                {
                    Console.WriteLine(removeKnight);
                    break;
                }
                else
                {
                    board[knightRow, knightCol] = '0';
                    removeKnight++;
                }
            }




        }

        private static bool isInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
