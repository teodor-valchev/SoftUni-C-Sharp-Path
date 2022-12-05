using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> calc = new Stack<string>(input);

            while (calc.Count > 1)
            {
                int firstNum = int.Parse(calc.Pop());
                string sign = calc.Pop();
                int secondNum = int.Parse(calc.Pop());

                if (sign == "+")
                {
                    int result = firstNum + secondNum;
                    calc.Push(result.ToString());
                }
                else if (sign == "-")
                {
                    int result = firstNum - secondNum;
                    calc.Push(result.ToString());
                }
            }

            Console.WriteLine(calc.Pop());
        }
    }
}
