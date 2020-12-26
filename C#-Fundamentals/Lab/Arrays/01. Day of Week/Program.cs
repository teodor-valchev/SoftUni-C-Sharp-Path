using System;

namespace _1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = new string[]
             {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday,",
                "Saturday",
                "Sunday",
             };
            int DayNum = int.Parse(Console.ReadLine());

            if (DayNum < 1 || DayNum > days.Length)
            {
                Console.WriteLine("Invalid day");
            }
            else
            {
                Console.WriteLine(days[DayNum - 1]);
            }

        }
    }
}
