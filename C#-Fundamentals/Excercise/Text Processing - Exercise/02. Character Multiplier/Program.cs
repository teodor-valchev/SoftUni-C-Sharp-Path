using System;

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

            if (firstWord.Length<secondWord.Length)
            {
                longestWord = secondWord;
                shortestWord = firstWord;

            }
            var total = CharManipulator(longestWord, shortestWord);
            Console.WriteLine(total);
        }
        public static int CharManipulator(string longestWord,string shortesWord)
        {
            var sum = 0;
            for (int i = 0; i < shortesWord.Length; i++)
            {
                var multiply = longestWord[i] * shortesWord[i];
                sum += multiply;
            }

            for (int i = shortesWord.Length; i < longestWord.Length; i++)// Tam dokudeto sme stignali
            {
                sum += longestWord[i];
            }

            return sum;
        }
    }
}
