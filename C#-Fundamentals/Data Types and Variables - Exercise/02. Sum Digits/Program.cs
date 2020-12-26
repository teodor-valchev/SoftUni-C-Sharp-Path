using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
               // int currentNum = (int)Char.GetNumericValue(input[i]);
               int currentNum = int.Parse(input[i].ToString());
                sum += currentNum;
            }
            Console.WriteLine(sum);
        }
    }
}
