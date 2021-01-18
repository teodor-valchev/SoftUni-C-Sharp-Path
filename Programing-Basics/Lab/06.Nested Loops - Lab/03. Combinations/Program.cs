using System;

namespace _03._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int validCombination = 0;
            for (int i = 0; i <= num; i++)
            {
                for (int j = 0; i <=num ; j++)
                {
                    for (int k = 0; i <= num; k++)
                    {
                        
                        if (i+j+k==num)
                        {
                            validCombination++;
                        }
                    }
                }
            }
            Console.WriteLine(validCombination);
        }
    }
}
