using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guest = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string guestName = cmdArgs[0];

                if (cmdArgs.Length>3)//дължината на командата от усл
                {
                    if (guest.Contains(guestName))
                    {
                        guest.Remove(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                }
                else  
                {
                    if (!guest.Contains(guestName))
                    {
                        guest.Add(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,guest));// ще печата всяко име на нов ред
        }
    }
}
