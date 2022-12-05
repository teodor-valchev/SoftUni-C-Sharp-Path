using System;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[][] beach = new string[n][];

            beach = GetInput(beach, n);
            int colectedTokens = 0;
            int opponetsTokens = 0;

            string commands = Console.ReadLine();

            while (true)
            {
                string[] tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Gong")
                {
                    break;
                }

                if (command == "Find")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    if (isValid(beach, row, col, n))
                    {
                        for (int rows = 0; rows <= row; rows++)
                        {
                            for (int cols = 0; cols <= beach[rows].Length; cols++)
                            {
                                if (beach[row][col] == "T")
                                {
                                    beach[row][col] = "-";
                                    colectedTokens++;
                                }
                            }

                        }
                    }

                }
                else if (command == "Opponent")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];

                    if (isValid(beach, row, col, n))
                    {
                        for (int rows = 0; rows <= row; rows++)
                        {
                            for (int cols = 0; cols <= beach[rows].Length; cols++)
                            {
                                if (beach[row][col] == "T")
                                {
                                    beach[row][col] = "-";
                                    opponetsTokens++;
                                }
                            }
                        }

                        if (direction == "right")
                        {
                            if (isValid(beach, row, col + 1, n))
                            {
                                if (beach[row][col + 1] == "T")
                                {
                                    beach[row][col + 1] = "-";
                                    opponetsTokens++;
                                }

                            }
                            if (isValid(beach, row, col + 2, n) && beach[row][col + 2] == "T")
                            {
                                beach[row][col + 2] = "-";
                                opponetsTokens++;
                            }
                            if (isValid(beach, row, col + 3, n) && beach[row][col + 3] == "T")
                            {
                                beach[row][col + 3] = "-";
                                opponetsTokens++;
                            }

                        }
                        else if (direction == "left")
                        {
                            if (isValid(beach, row, col - 1, n) && beach[row][col - 1] == "T")
                            {
                                beach[row][col - 1] = "-";
                                opponetsTokens++;
                            }
                            if (isValid(beach, row, col - 2, n) && beach[row][col - 2] == "T")
                            {
                                beach[row][col - 2] = "-";
                                opponetsTokens++;
                            }
                            if (isValid(beach, row, col - 3, n) && beach[row][col - 3] == "T")
                            {
                                beach[row][col - 3] = "-";
                                opponetsTokens++;
                            }
                        }
                        else if (direction == "up")
                        {
                            if (isValid(beach, row - 1, col, n) && beach[row - 1][col] == "T")
                            {
                                beach[row - 1][col] = "-";
                                opponetsTokens++;
                            }
                            if (isValid(beach, row - 2, col, n) && beach[row - 2][col] == "T")
                            {
                                beach[row - 2][col] = "-";
                                opponetsTokens++;
                            }
                            if (isValid(beach, row - 3, col, n) && beach[row - 3][col] == "T")
                            {
                                beach[row - 3][col] = "-";
                                opponetsTokens++;

                            }
                        }
                        else if (direction == "down")
                        {
                            if (isValid(beach, row + 1, col, n) && beach[row + 1][col] == "T")
                            {
                                beach[row + 1][col] = "-";
                                opponetsTokens++;

                            }
                            if (isValid(beach, row + 2, col, n) && beach[row + 2][col] == "T")
                            {
                                beach[row + 2][col] = "-";
                                opponetsTokens++;

                            }
                            if (isValid(beach, row + 3, col, n) && beach[row + 3][col] == "T")
                            {
                                beach[row + 3][col] = "-";
                                opponetsTokens++;

                            }

                        }
                    }
                }



                commands = Console.ReadLine();
            }
            Print(beach, n);
            Console.WriteLine($"Collected tokens: {colectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponetsTokens}");



        }

        private static bool isValid(string[][] beach, int row, int col, int n)
        {
            return row >= 0 && row <= n && col >= 0 && col < beach[row].Length;
        }

        private static string[][] GetInput(string[][] beach, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                beach[row] = input;
            }

            return beach;


        }

        private static void Print(string[][] beach, int row)
        {
            for (int rows = 0; rows < row; rows++)
            {
                for (int col = 0; col < beach[rows].Length; col++)
                {
                    Console.Write(beach[rows][col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
