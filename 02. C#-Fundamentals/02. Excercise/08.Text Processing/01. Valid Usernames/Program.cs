using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var cur = input[i];
                if (IsValid(cur))
                {
                    Console.WriteLine(cur);
                }
            }
        }

        public static bool IsValid(string current)
        {


            return current.Length >= 3 &&
                current.Length <= 16 &&
            current.All(x => char.IsLetterOrDigit(x)) ||
            current.Contains("-") || current.Contains("_");
        }
    }
}
