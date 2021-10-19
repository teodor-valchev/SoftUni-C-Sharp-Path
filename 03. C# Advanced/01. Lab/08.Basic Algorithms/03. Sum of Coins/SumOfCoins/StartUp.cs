namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine()
              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();
            int targetSum = int.Parse(Console.ReadLine());
            var collection = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {collection.Values.Sum()}");
            foreach (var coin in collection)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            int count = 1;
            while (coins.Any())
            {
                int curentCoin = coins.OrderByDescending(x => x).FirstOrDefault();
                if (curentCoin * count <= targetSum && !result.ContainsKey(curentCoin))
                {
                    result.Add(curentCoin, 0);
                    targetSum -= curentCoin * count;
                    result[curentCoin]++;
                }
                else if (result.ContainsKey(curentCoin) && curentCoin * count <= targetSum)
                {
                    targetSum -= curentCoin * count;
                    result[curentCoin]++;
                }
                if (curentCoin * count > targetSum)
                {
                    coins.Remove(curentCoin);
                }
                if (targetSum <= 0)
                {
                    break;
                }
            }
            if (targetSum == 0)
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}