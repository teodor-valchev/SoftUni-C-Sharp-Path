using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            string longNum = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());

            foreach (var ch in longNum.Reverse())
            {
                int digit = int.Parse(ch.ToString());
                int result = digit * num;

                sb.Insert(0, result);
            }
            Console.WriteLine(sb.ToString());

            
        }
    }
}
