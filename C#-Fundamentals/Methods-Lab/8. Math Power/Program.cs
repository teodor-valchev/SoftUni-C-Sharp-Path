using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            double print = MathPower(n1, n2);
            Console.WriteLine(print);

        }
        static double  MathPower(double num, double power)
        {
            
           return Math.Pow(num, power);

            
        }
    }
}
