using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b";
            Regex regex = new Regex(pattern);

            var input = (Console.ReadLine());

            var matches = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(", ",matches));
        }
    }
}
