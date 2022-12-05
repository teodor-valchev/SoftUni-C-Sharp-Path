using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = new int[arr1.Length - 1];

            if (arr1.Length == 1)
            {
                Console.WriteLine(arr1[0]);
                return;
            }

            for (int first = 0; first < arr1.Length; first++)

            {

                for (int second = 0; second < arr2.Length - first; second++)
                {
                    arr2[second] = arr1[second] + arr1[second + 1];

                }

                arr1 = arr2;
            }
            Console.WriteLine(arr1[0]);

        }
    }
}
