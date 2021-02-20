using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());
            string result = RepeatString(text, repeatTimes);
            Console.WriteLine(result);


        }

        private static string RepeatString(string text, int repeatTimes)
        {
            string result = string.Empty;

            for (int i = 0; i < repeatTimes; i++)
            {
                result += text;
            }

            
            return result ;
        }
    }
}
