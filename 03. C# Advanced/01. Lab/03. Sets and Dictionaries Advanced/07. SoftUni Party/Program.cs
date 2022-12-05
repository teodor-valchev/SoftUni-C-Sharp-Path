using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            string command = Console.ReadLine();

            while (command != "END")
            {


                if (command == "PARTY")
                {
                    while (true)
                    {
                        string names = Console.ReadLine();
                        if (guests.Contains(names))
                        {
                            guests.Remove(names);
                        }
                        if (names == "END")
                        {
                            break;
                        }

                    }

                }
                if (command == "PARTY")
                {
                    break;
                }
                guests.Add(command);

                command = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);



            foreach (var guest in guests)
            {
                bool isVip = false;
                for (int i = 0; i < guest.Length; i++)
                {
                    char letter = guest[i];
                    if (char.IsDigit(letter))
                    {

                        isVip = true;
                        break;
                    }
                    break;
                }
                if (isVip)
                {
                    Console.WriteLine(guest);
                }
                else
                {
                    Console.WriteLine(guest);
                }
            }

        }
    }
}
