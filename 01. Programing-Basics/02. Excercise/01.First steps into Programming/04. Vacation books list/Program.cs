using System;

namespace _04._Vacation_books_list
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());
            double timeForBook = pages / pagesPerHour;
            double perDay = timeForBook / days;
            Console.WriteLine(perDay);
        }
    }
}
