using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintInBetween(firstChar, secondChar);
        }

        private static void PrintInBetween(char firstChar, char secondChar)
        {
            if (firstChar>secondChar)
            {
                char first = firstChar;
                firstChar = secondChar;
                secondChar = first;// за да не правим for за наобратно 
            }
            for (int i = firstChar+1; i < secondChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
