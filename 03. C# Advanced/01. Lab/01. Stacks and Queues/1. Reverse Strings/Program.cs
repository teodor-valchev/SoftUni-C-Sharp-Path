using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            Stack<char> chStack = new Stack<char>(input);

        

            while (chStack.Count > 0)
            {
                Console.Write(chStack.Pop());
            }

            Console.WriteLine();

        }
    }
}
