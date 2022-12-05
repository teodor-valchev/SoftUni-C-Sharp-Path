using System;

namespace _07.Tuple
{
   public class Program
    {
     public   static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string nameTwon = $"{inputNames[0]} {inputNames[1]}";
            string town = inputNames[2];

            string[] inputBeerName = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = inputBeerName[0];
            double litters = double.Parse(inputBeerName[1]);

            string[] numbersSplit = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int firstOne = int.Parse(numbersSplit[0]);
            double secondOne = double.Parse(numbersSplit[1]);

            MyTuple<string, string> townName = new MyTuple<string, string>(nameTwon, town);
            MyTuple<string, double> beerName = new MyTuple<string, double>(name, litters);
            MyTuple<int, double> numbers = new MyTuple<int, double>(firstOne, secondOne);

            Console.WriteLine(townName);
            Console.WriteLine(beerName);
            Console.WriteLine(numbers);
        }
    }
}
