using System;
using System.Linq;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> listy = null;


            while (command!="END")
            {
                string[] tokens = command.Split();

                if (tokens[0]=="Create")
                {
                    listy = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (tokens[0] == "Print")
                {
                    listy.Print();
                }
                command = Console.ReadLine();
            }
        }
    }
}
