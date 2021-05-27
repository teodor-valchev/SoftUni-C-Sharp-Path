using System;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = Console.ReadLine();
            

            while (command != "Done")
            {
                string[] tokens = command.Split();
                string name = tokens[0];


                if (name == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < password.Length; i++)
                    {

                        char curr = password[i];

                        if (i % 2 == 1)
                        {
                            sb.Append(curr);

                        }
                    }
                    password = sb.ToString();
                    Console.WriteLine(password);
                    

                }

                else if (name == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int lenght = int.Parse(tokens[2]);

                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (name == "Substitute")
                {
                    string contains = tokens[1];
                    string replace = tokens[2];

                    if (password.Contains(contains))
                    {
                        password = password.Replace(contains, replace);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    
                }



                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
