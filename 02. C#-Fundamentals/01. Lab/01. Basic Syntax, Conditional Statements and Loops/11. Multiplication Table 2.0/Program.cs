using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
           

            for (int i = 1; i <= 1; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (secondNumber > 10)
                    {
                        Console.WriteLine($"{n} X {secondNumber} = {n * secondNumber}");
                        break;
                    }
                    
                    else
                    {
                        Console.WriteLine($"{n} X {j} = {n * j}");
                    }
                   
                }
            }
        }
    }
}
