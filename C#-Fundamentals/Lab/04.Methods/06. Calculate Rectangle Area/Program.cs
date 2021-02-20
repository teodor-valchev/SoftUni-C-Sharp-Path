using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            PrintArea(width, height);
        }

        private static void PrintArea(int width, int height)
        {
            int result = width * height;

            Console.WriteLine(result);
            
            
        }
    }
}
