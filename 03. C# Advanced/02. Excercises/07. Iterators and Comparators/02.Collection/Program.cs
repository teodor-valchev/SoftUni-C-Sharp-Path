using System;
using System.Linq;

namespace _02.Collection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> listy = null;


            while (command != "END")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Create")
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
                else if (tokens[0] =="PrintAll")
                {
                    listy.PrintAll();
                }
                command = Console.ReadLine();
            }
        }
    }
}
