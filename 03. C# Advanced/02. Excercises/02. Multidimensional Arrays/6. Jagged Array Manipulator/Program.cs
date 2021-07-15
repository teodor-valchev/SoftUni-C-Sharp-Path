using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];

            for (int row = 0; row < n; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(double.Parse)
                  .ToArray();

            }

            for (int i = 0; i < n - 1; i++)
            {

                double[] firstArray = jaggedArray[i];
                double[] secondArray = jaggedArray[i + 1];
                if (firstArray.Length == secondArray.Length)
                {
                    jaggedArray[i] = firstArray.Select(e => e * 2).ToArray();
                    jaggedArray[i + 1] = secondArray.Select(e => e * 2).ToArray();
                }
                else
                {
                    jaggedArray[i] = firstArray.Select(e => e / 2).ToArray();
                    jaggedArray[i + 1] = secondArray.Select(e => e / 2).ToArray();
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int row = int.Parse(tokens[1]);
                int collum = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                bool isValidCell = row >= 0 && row < n && collum >= 0 && collum < jaggedArray[row].Length;

                if (name == "Add")
                {
                    if (!isValidCell)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        jaggedArray[row][collum] += value;
                    }
                }

                else if (name == "Subtract")
                {
                    if (!isValidCell)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        jaggedArray[row][collum] -= value;
                    }
                }



                command = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }

        }


    }
}
