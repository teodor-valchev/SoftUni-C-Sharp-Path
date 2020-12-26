using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Print(n,n);
        }
        static void Print(int start,int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i+" ");
                
            }
            Console.WriteLine();
            
        }

    }
}
