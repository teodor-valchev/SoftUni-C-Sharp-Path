using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int minNum = int.MaxValue;

            while (command != "Stop")
            {
                int number = int.Parse(command);

                if (number < minNum)
                {
                    minNum = number;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
