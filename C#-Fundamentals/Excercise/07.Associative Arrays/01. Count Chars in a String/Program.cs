using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> ocurencess = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!ocurencess.ContainsKey(letter))
                    {
                        ocurencess.Add(letter, 0);
                    }
                    ocurencess[letter]++;
                }
            }
            foreach (var c in ocurencess)
            {
                char currentKey = c.Key;
                int currentValue = c.Value;

                Console.WriteLine($"{ currentKey} -> { currentValue}");
            }
        }
    }
}
