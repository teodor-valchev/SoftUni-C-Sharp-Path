using System;

namespace _3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = Char.Parse(Console.ReadLine());
            char secondChar = Char.Parse(Console.ReadLine());

            PrintInBetween(firstChar, secondChar);
        }

        private static void PrintInBetween(char firstChar, char secondChar)
        {
            if (firstChar>secondChar)
            {
                char first = firstChar;
                firstChar = secondChar;
                secondChar = first;
            }

            for (int i = firstChar + 1; i < secondChar; i++)
            {
                Console.Write((char)i +" ");
            }
        }
    }
}
