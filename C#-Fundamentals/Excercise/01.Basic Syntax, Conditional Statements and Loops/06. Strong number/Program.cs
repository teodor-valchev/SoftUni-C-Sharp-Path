using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;
            int currentNumber = 0;
            int factorielSum = 0;
            while (number!=0)
            {
                currentNumber = number % 10;
                number /= 10;

                int factoriel = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    factoriel *= i;
                }
                factorielSum += factoriel;
            }
            string result = string.Empty;

            if (input==factorielSum)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }
            Console.WriteLine(result);
        }
    }
}
