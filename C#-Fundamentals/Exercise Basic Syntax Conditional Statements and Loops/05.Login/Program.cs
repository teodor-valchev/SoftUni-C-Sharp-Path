using System;

namespace _5.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;

            for (int i = userName.Length-1; i >= 0; i--)
            {
                password += userName[i];
            }

            int count = 0; 
            while (true)
            {
                string currentUserr = Console.ReadLine();

                if (currentUserr!=password)
                {
                    count++;
                    if (count==4)
                    {
                        Console.WriteLine($"User { userName} blocked!");
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
