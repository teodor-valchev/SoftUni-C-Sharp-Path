using System;

namespace _02._English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int convert = n % 10;

            if (convert==1)
            {
                Console.WriteLine("one");
            }
            else if (convert==2)
            {
                Console.WriteLine("two");
            }
            else if (convert == 3)
            {
                Console.WriteLine("three");
            }
            else if (convert == 4)
            {
                Console.WriteLine("four");
            }
            else if (convert == 5)
            {
                Console.WriteLine("five");
            }
            else if (convert == 6)
            {
                Console.WriteLine("six");
            }
            else if (convert == 7)
            {
                Console.WriteLine("seven");
            }
            else if (convert == 8)
            {
                Console.WriteLine("eight");
            }
            else if (convert == 9)
            {
                Console.WriteLine("nine");
            }

        }
    }
}
