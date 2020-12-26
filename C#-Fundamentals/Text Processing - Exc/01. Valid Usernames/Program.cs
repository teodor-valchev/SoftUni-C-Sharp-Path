using System;
using System.Linq;

namespace Text_Processing___Exc
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");// stana masiv direktno

            for (int i = 0; i < input.Length; i++)
            {
                var cur = input[i];
                if (IsValid(cur))
                {
                    Console.WriteLine(cur);
                }

                
            }
        }

        public static bool IsValid(string curret)
        {



            return curret.Length >= 3 &&
            curret.Length <= 16 &&
            curret.All(c => char.IsLetterOrDigit(c)) ||
            curret.Contains("-") || curret.Contains("_");

        }
    }
}
