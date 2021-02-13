using System;

namespace _2._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int currentDigit = (int)Char.GetNumericValue(input[i]);
                sum += currentDigit;
            }
            Console.WriteLine(sum);
        }
    }
}
