using System;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string input = string.Empty;
            int counter = 0;
            int bestCount = 0;
            int bestBeginIndex = 0;
            int bestSum = 0;
            string bestSequance = "";
            while ((input = Console.ReadLine())!= "Clone them!")
            {
                string sequance = input.Replace("!", "");
                string[] dnaParts = sequance
                    .Split("0", StringSplitOptions.RemoveEmptyEntries);
                int count = 0;
                int sum = 0;
                string bestSubSequance = "";
                counter++;

                foreach (var dnaPart in dnaParts)
                {
                    if (dnaPart.Length>count)
                    {
                        count = dnaPart.Length;
                        bestSubSequance = dnaPart;
                    }
                    sum += dnaPart.Length;
                }

                int beginIndex = sequance.IndexOf(bestSubSequance);

                if (count>bestCount || (count==bestCount&&beginIndex<bestBeginIndex)|| (count==bestCount&&beginIndex==bestBeginIndex&&sum>bestSum))

                {
                    bestCount = count;
                    bestSequance = sequance;
                    bestBeginIndex = beginIndex;
                    bestSum = sum;
                    bestCount = counter;
                }

            }
            char[] result = bestSequance.ToCharArray();
            Console.WriteLine($"Best DNA sample {bestCount} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ",result)}");
        }
    }
}
