using System;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output = string.Empty;
            //even
            if (input.Length%2==0)
            {
                 output = GetMiddleCharFromEvenStringLenght(input);

            }
            //odd
            else
            {
                output = GetMiidleCharFromOddStringLenght(input);
              
            }
            Console.WriteLine(output);
        }

        private static string GetMiidleCharFromOddStringLenght(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index , 1);
            return chars;
        }

        private static string GetMiddleCharFromEvenStringLenght(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index-1, 2);
                return chars;
        }
    }
}
