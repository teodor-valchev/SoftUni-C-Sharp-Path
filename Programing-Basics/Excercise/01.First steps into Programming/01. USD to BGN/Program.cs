using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double Usd = double.Parse(Console.ReadLine());
            double result = Usd * 1.79549;
            Console.WriteLine(result);
        }
    }
}
