using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(builder.ToString());


            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int number = int.Parse(commands[0]);

                if (number == 1)
                {

                }
                else if (number == 2 )
                {

                }
                else if (number == 3)
                {

                }
                else if (number == 4)
                {

                }
            }
        }
    }
}
