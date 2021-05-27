using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(:{2}|\*{2})(?<name>[A-Z][a-z]{2,})\1";
            string numbers = @"\d";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            Regex nums = new Regex(numbers);

            var nameMatch = regex.Matches(input);
            var numMatch = nums.Matches(input);

            int TresHold = 1;

            foreach (Match num in numMatch)
            {
                int current = int.Parse(num.Value);
                TresHold *= current;
            }

            Console.WriteLine($"Cool threshold: {TresHold}");
            List<string> names = new List<string>();

            foreach (Match match in nameMatch)
            {
                string name = match.Groups["name"].Value;

                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    char letter = name[i];
                    sum += letter;



                }

                if (sum > TresHold)
                {
                    names.Add(match.ToString());
                }


            }
            Console.WriteLine($"{nameMatch.Count} emojis found in the text. The cool ones are:");

            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }



        }
    }
}
