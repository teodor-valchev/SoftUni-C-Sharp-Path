using System;

namespace _08.Factoriel_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            double factorieln1 = GetFactoriel(n1);
            double factorieln2 = GetFactoriel(n2);

            double result = factorieln1 / factorieln2;

            Console.WriteLine($"{result:f2}");
        }



        public static double GetFactoriel(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}
