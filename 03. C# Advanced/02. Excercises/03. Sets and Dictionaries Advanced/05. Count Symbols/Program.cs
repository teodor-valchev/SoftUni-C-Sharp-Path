using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
            string input = Console.ReadLine();

            foreach (char ch in input)
            {
                if (!counts.ContainsKey(ch))
                {
                    counts.Add(ch, 0);
                }
                counts[ch]++;
            }

            foreach (var ch in counts.OrderBy(x => x.Key).ThenBy(v => v.Value))
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
