using System;
using System.Linq;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();

            var firstWord = tokens[0];
            var secondWord = tokens[1];

            var longestWord = firstWord;
            var shortestWord = secondWord;

            if (firstWord.Length < secondWord.Length)
            {
                longestWord = secondWord;
                secondWord = firstWord;

            }
            var total = CharavteManipulator(longestWord, secondWord);
            Console.WriteLine(total);
        }

        public static int CharavteManipulator(string longestWord, string shortesWord)
        {
            var sum = 0;
            for (int i = 0; i < shortesWord.Length; i++)
            {
                var multiply = longestWord[i] * shortesWord[i];
                sum += multiply;
            }

            for (int i = shortesWord.Length; i < longestWord.Length; i++)
            {
                sum += longestWord[i];
            }

            return sum;
        }
    }
}
