using System;

namespace _08.Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string nameTown = $"{inputNames[0]} {inputNames[1]}";
            string adress = inputNames[2];
            string town = inputNames[3];

            string[] inputBeerName = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = inputBeerName[0];
            double litters = double.Parse(inputBeerName[1]);
            string drunkOrNot = inputBeerName[2];
            bool isDrunk = false;

            if (drunkOrNot == "drunk")
            {
                isDrunk = true;
            }

            string[] banks = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = banks[0];
            double account = double.Parse(banks[1]);
            string bankName = banks[2];

            MyThreeuple<string, string, string> firstThreeuple = new MyThreeuple<string, string, string>(nameTown, adress, town);
            MyThreeuple<string, double, bool> secondThreeuple = new MyThreeuple<string, double, bool>(name, litters, isDrunk);
            MyThreeuple<string, double, string> thirdThreeuple = new MyThreeuple<string, double, string>(personName, account, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
