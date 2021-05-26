using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();

            var matches = regex.Matches(input);
            int points = 0;
            List<string> destinations = new List<string>();

            foreach (Match place in matches)
            {
                string destination = place.Groups[2].Value;
                destinations.Add(destination);

                points += destination.Length;
            }
            Console.Write($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine();
            Console.WriteLine($"Travel Points: {points}");


        }
    }
}
