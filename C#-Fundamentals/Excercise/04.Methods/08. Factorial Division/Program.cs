using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double factorielFurtsNum = GetFactoriel(firstNumber);
            double factorielsecondNum = GetFactoriel(secondNumber);

            double result = factorielFurtsNum / factorielsecondNum;
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
