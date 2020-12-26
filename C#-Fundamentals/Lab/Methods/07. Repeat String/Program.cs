using System;
using System.Linq;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string output = RepeatString( input, n);
            Console.WriteLine(output);
        }
        static string RepeatString(string str,int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result+=str;
            }
            return result;
        }
    }
}
