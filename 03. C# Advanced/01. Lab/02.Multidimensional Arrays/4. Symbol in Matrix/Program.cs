using System;
using System.Linq;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            char[,] matrix = new char[input, input];



            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string ascii = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char[] letters = ascii.ToCharArray();
                    matrix[row, col] = letters[col];
                }
            }
            char symbolToFind = char.Parse(Console.ReadLine());

            int count = 0;
            int rows = 0;
            int cols = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {



                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbolToFind == matrix[row, col])
                    {

                        count++;
                        rows = row;
                        cols = col;
                    }
                }

            }
            if (count == 0)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
            else
            {
                Console.WriteLine($"({rows}, {cols})");

            }




        }
    }
}
