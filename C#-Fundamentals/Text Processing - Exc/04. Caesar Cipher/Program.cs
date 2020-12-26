using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();


            foreach (char ch in input)
            {
                var currentchar = (char)(ch + 3);// s skobi za da stane char
                Console.Write(currentchar);

            }
        }
    }
}
