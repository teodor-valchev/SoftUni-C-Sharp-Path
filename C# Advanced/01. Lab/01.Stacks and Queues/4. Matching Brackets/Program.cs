using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
          string  input = Console.ReadLine();
               

            Stack<int> brackets = new Stack<int>();


            for (int i = 0; i < input.Length; i++)
            {
                

                if (input[i]=='(')
                {
                    brackets.Push(i);
                }
                else if (input[i]==')')
                {
                    int index = brackets.Pop();
                    Console.WriteLine(input.Substring(index,i-index+1));
                }
            }

            
        }
    }
}
