using System;
using System.Collections.Generic;

namespace _1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {


            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!occurences.ContainsKey(letter))
                    {
                        occurences.Add(letter, 0);
                    }
                    occurences[letter]++;
                }

            }

            foreach (var c in occurences)
            {
                char currentkey = c.Key;
                int currentvalue = c.Value;
                Console.WriteLine($"{currentkey} -> {currentvalue}");



            }
        }
    }
}
