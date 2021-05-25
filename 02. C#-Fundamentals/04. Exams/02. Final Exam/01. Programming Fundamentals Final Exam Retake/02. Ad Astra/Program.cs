using System;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#|])(?<item>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            var matches = regex.Matches(input);

            int totalCalories = 0;


            foreach (Match item in matches)
            {
                int calories = int.Parse(item.Groups[4].Value);
                totalCalories += calories;

            }

            double days = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                string name = item.Groups[2].Value;
                string date = item.Groups[3].Value;
                int calories = int.Parse(item.Groups[4].Value);

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {calories}");
            }



        }
    }
}
