using System;

namespace _08._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int cols = 1; cols <= n; cols++)
            {
               
                for (int rows = 0; rows <cols; rows++)
                {
                   
                    Console.Write(cols +" ");
                    
                }
                Console.WriteLine();
            }
           
        }
    }
}
