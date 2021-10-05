using System;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public static int  Differance(string dateOne, string dateTwo)
        {
            DateTime firstDate = DateTime.Parse(dateOne);
            DateTime secondtDate = DateTime.Parse(dateTwo);
            TimeSpan diff = Math.Abs(firstDate - secondtDate);
            return diff.Days;

        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();
            DateModifier date = new DateModifier();
            int res = date.Differance(dateOne, dateTwo);
            Console.WriteLine(res);
        }
    }
}
