using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] arr1 = new string[n];
            string[] arr2 = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentArray = Console.ReadLine()
                                                  .Split()
                                                  .ToArray();
                string IndexZeroElement = currentArray[0];
                string IndexOneElement = currentArray[1];

                if (i%2==0)// even iteration
                {
                    arr1[i] = IndexZeroElement;
                    arr2[i] = IndexOneElement;
                }
                else if (i%2==1) //odd
                {
                    arr1[i] = IndexOneElement;
                    arr2[i] = IndexZeroElement;
                }

            }
            Console.WriteLine(string.Join((" "),arr1));
            Console.WriteLine(string.Join((" "), arr2));
        }
    }
}
