using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Print(n);


        }

        private static void Print(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                string currentn = i.ToString();
                bool isodddigit = false;
                int sumofdigit = 0;

                foreach (var curr in currentn)
                {
                    int Parsen = (int)curr;
                    if (Parsen%2==1)
                    {
                        isodddigit = true;
                    }
                    sumofdigit += Parsen;
                }

                if (sumofdigit% 8 ==0&& isodddigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
