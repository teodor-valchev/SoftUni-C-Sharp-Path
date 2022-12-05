using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            SmalestNumber(a, b, c);

        }

        private static void SmalestNumber(int a, int b, int c)
        {
            if (b>c&&c>a)
            {
                Console.WriteLine(a);
            }
            else if (a>b&&b>c)
            {
                Console.WriteLine(c);
            }
            else if (c > b && a > b)
            {
                Console.WriteLine(b);
            }
            else if (b > a && a > c)
            {
                Console.WriteLine(c);
            }


        }
    }
}
