using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, bool> selector = text => char.IsUpper(text[0]);
            string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            words = words.Where(selector).ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
