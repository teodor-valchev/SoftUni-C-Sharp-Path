using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listofInegers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command!="end")
            {
                string[] cmdArg = command.Split();
                string firstCommand = cmdArg[0];
                int element = int.Parse(cmdArg[1]);

                if (firstCommand=="Delete")
                {
                    listofInegers.RemoveAll(x=> x== element);//predikat
                }
                else if (firstCommand=="Insert")
                {
                    int index = int.Parse(cmdArg[2]);
                    listofInegers.Insert(index, element);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",listofInegers));
        }
    }
}
