using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintingTriangle(n);
        }

     
        private static void PrintingTriangle(int n)
        {
            for (int line = 1; line <= n; line++)
            {
                Line(1, line);
            }
            for (int line = n - 1; line >= 0; line--)
            {
                Line(1, line);
            }
        }

        private static void Line(int start,int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
