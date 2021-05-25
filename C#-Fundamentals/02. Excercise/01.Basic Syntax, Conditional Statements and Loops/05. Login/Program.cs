using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string trypass = string.Empty;
            int count = 0;


            for (int i = userName.Length - 1; i >= 0; i--)
            {
                trypass += userName[i];
            }

            while (true)
            {
                string currentUser = Console.ReadLine();

                if (currentUser != trypass)
                {
                    count++;

                    if (count == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
            }

        }
    }
}
