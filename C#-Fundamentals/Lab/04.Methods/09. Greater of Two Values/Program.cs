using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    int result = GetMax(num1, num2);
                    Console.WriteLine(result);
                    break;
                case "char":
                    char a = char.Parse(Console.ReadLine());
                    char b = char.Parse(Console.ReadLine());
                    char result2 = (char)GetMax(a, b);
                    Console.WriteLine(result2);
                    break;
                case "string":
                    string c = Console.ReadLine();
                    string d = Console.ReadLine();

                    if (c.CompareTo(d) >= 0)
                        Console.WriteLine(c);
                    else
                        Console.WriteLine(d); ;
                    break;

            }
        }

        private static int GetMax(int num1, int num2)
        {
            int greaterNum = 0;
            if (num1 > num2)
            {
                greaterNum = num1;
            }
            else
            {
                greaterNum = num2;
            }
            return greaterNum;
        }
    }
}
