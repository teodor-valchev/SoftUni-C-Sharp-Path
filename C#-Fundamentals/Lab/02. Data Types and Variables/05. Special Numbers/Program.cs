using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int summOfDigits = 0;
                int digits = i;

                while (digits>0)
                {
                    summOfDigits += digits % 10;
                    digits = digits / 10;
                }
                bool isSpecial = summOfDigits == 5 || summOfDigits == 7 || summOfDigits == 11;

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
