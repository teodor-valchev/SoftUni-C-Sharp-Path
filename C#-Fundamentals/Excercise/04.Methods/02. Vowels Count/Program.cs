using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower;

           int result =  VolewCount(input);
            Console.WriteLine(result);
            
        }

        private static int VolewCount(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar=='a')
                {
                    count++;
                }
                else if (currentChar =='e')
                {
                    count++;
                }
                else if (currentChar == 'i')
                {
                    count++;
                }
                else if (currentChar == 'o')
                {
                    count++;
                }
                else if (currentChar == 'u')
                {
                    count++;
                }
                else if (currentChar == 'y')
                {
                    count++;
                }


            }
            return count;

        }
    }
}
