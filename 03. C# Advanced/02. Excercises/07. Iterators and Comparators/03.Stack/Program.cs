using System;
using System.Linq;

namespace _03.Stack
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

       

            while (true)
            {
                var tokens = Console.ReadLine().Split(" ");
                if (tokens[0]=="END")
                {
                    break;
                }

               else if (tokens[0] == "Push")
                {
                    stack.Push(tokens.Skip(1).Select(e => e.Split(",").First().ToArray());

                }
                else if (tokens[0] == "Move")
                {



                }
            }
        }
    }
}
