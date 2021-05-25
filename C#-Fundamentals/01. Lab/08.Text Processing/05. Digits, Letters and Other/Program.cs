using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var nums = new StringBuilder();
            var letters = new StringBuilder();
            var other = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var text = input[i];

                if (char.IsDigit(text))
                {
                    nums.Append(text);
                }
                else if (char.IsLetter(text))
                {
                    letters.Append(text);
                }
                else
                {
                    other.Append(text);
                }
            }
            Console.WriteLine(nums);
            Console.WriteLine(letters);
            Console.WriteLine(other);
        }
    }
}
