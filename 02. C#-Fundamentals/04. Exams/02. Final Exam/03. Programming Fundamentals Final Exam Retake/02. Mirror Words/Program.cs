using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([[#]|[@])(?<partOne>[A-zA-z]{2,})\1(@|#)(?<parttTwo>\w+)\1";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            var matches = regex.Matches(input);
           
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
            List<string> Pairs = new List<string>();

            foreach (Match item in matches)
            {
                string firstWord = item.Groups["partOne"].Value;
                string secondWord = item.Groups["parttTwo"].Value;

                if (IsMatch(firstWord,secondWord))
                {
                    mirrorWords.Add(firstWord, secondWord);
                }
                else
                {
                    Pairs.Add(firstWord);
                }

            }
            if (Pairs.Count >0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                if (mirrorWords.Count == 0)
                {

                    Console.WriteLine("No mirror words!");

                }
                
                
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }
          
           
            if (mirrorWords.Count>0)
            {

                Console.WriteLine($"{matches.Count} word pairs found!");
                Console.WriteLine($"The mirror words are:");

                foreach (var item in mirrorWords)
                {
                    string firstWord = item.Key;
                    string secondWord = item.Value;


                    Console.Write($"{firstWord} <=> {secondWord}, ");


                }
            }
          
          
                     
        }

        private static bool IsMatch(string firstWord,string secondWord)
        {
            string matchWord = "";
            for (int i = firstWord.Length - 1; i >= 0; i--)
            {
                matchWord += firstWord[i];
            }

            if (matchWord==secondWord)
            {
                return true;
            }

            return false;
        }
    }
}
