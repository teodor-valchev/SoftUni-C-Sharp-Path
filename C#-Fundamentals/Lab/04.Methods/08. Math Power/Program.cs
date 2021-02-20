using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double result = PrintPow(a,b);
            Console.WriteLine(result);

        }

        private static double PrintPow(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
