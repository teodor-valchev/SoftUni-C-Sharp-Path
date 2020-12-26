using System;
using System.Linq;

namespace _5._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                int currentnumber = n[i];

                if (currentnumber%2==0)
                {
                    sum += currentnumber;
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
