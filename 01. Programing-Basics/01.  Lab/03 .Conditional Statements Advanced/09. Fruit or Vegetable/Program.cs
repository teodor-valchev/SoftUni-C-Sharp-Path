using System;

namespace _09._Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            switch (product)
            {
                case "banana": Console.WriteLine("fruit");
                    break;
                case "apple":
                    Console.WriteLine("fruit");
                    break;
                case "kiwi":
                    Console.WriteLine("fruit");
                    break;
                case "cherry":
                    Console.WriteLine("fruit");
                    break;
                case "lemon":
                    Console.WriteLine("fruit");
                    break;
                case "grapes":
                    Console.WriteLine("fruit");
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot": Console.WriteLine("vegetable");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
