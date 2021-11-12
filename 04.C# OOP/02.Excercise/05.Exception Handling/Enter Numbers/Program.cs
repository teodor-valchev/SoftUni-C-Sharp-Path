using System;

namespace Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int start = int.Parse(Console.ReadLine());
                int end = int.Parse(Console.ReadLine());

                if (start <= 0 || end <= 0)
                {
                    throw new ArgumentException("Invalid Number");
                }
                ReadNumber(start, end);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void ReadNumber(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
