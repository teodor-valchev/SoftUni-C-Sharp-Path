using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Add(action,a,b);
            Multiply(action, a, b);
            Subtract(action, a, b);
            Divide(action, a, b);
        }

        static void Add (string add, int a ,int b) 
        {
            int result;
            if (add=="add")
            {
                result = a + b;
                Console.WriteLine(result);
            }
        }
        static void Multiply (string multiply, int a, int b)
        {
            int result;
            if (multiply == "multiply")
            {
                result = a * b;
                Console.WriteLine(result);
            }
        }
        static void Subtract(string subtract, int a, int b)
        {
            int result;
            if (subtract == "subtract")
            {
                result = a - b;
                Console.WriteLine(result);
            }
        }
        static void Divide(string divide, int a, int b)
        {
            int result;
            if (divide == "divide")
            {
                result = a / b;
                Console.WriteLine(result);
            }
        }

    }
}
