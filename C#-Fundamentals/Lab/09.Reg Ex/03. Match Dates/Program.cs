using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>[0-2][1-9])([-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b";


            var input = Console.ReadLine();
            var dates = Regex.Matches(input, pattern);

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
            Console.WriteLine(string.Join(" ",dates));
        }
    }
}
