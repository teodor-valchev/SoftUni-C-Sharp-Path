using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPatern = @"\d";
            string emojiPattern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
            Regex numReg = new Regex(numberPatern);
            Regex emojiReg = new Regex(emojiPattern);

            string text = Console.ReadLine();
            long coolTresHold = 1;
            numReg
                .Matches(text)
                .Select(m => m.Value)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => coolTresHold *= x);

            var matches = emojiReg.Matches(text);
            int totalEmojis = matches.Count;
            List<string> coolEmogis = new List<string>();

            foreach (Match match in matches)
            {
              long coolIndex =   match
                    .Value.Substring(2, match.Value.Length - 4)
                    .ToCharArray().Sum(x=> (int)x);

                if (coolIndex>coolTresHold)
                {
                    coolEmogis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolTresHold}");
            Console.WriteLine($"{totalEmojis} emojis found in the text. The cool ones are:");

            foreach (var item in coolEmogis)
            {
                Console.WriteLine(item);
            }

        }
    }
}
