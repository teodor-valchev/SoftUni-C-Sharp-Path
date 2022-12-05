using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = tokens[0];




                if (cmd != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                }
                else
                {
                    int rowOne = int.Parse(tokens[1]);
                    int colOne = int.Parse(tokens[2]);
                    int rowTwo = int.Parse(tokens[3]);
                    int colTwo = int.Parse(tokens[4]);
                    bool IsNotValid = rowOne > matrix.GetLength(0) && colOne > matrix.GetLength(1) && rowTwo > matrix.GetLength(0) && colOne > matrix.GetLength(1) && rowOne < 0 && rowTwo < 0 && colOne < 0 && colTwo < 0;

                    if (IsNotValid)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {

                        string valueOne = matrix[rowOne, colOne];
                        string valueTwo = matrix[rowTwo, colTwo];

                        matrix[rowOne, colOne] = valueTwo;
                        matrix[rowTwo, colTwo] = valueOne;

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



                command = Console.ReadLine();

            }
        }
    }
}
