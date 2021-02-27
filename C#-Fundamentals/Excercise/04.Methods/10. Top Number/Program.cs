using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTopNumber(number);
        }

        private static void PrintTopNumber(int number)
        {
            for (int i = 0; i <= number; i++)
            {
                string currentNumber = i.ToString();
                bool isOddDigit = false;
                int sumOfDigit = 0;

                foreach (var current in currentNumber)
                {
                    int parseNumber = (int)current;

                    if (parseNumber % 2 == 1)
                    {
                        isOddDigit = true;
                    }

                    sumOfDigit += parseNumber;
                }
                if (sumOfDigit % 8 == 0 && isOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
