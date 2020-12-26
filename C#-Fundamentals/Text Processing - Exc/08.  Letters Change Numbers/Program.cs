using System;

namespace _8.__Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];//tekushtiq simvol
                char firsLetter = current[0];//vzimame purviq simvol
                char lastLetter = current[current.Length - 1];//vzimame posledniq simvol

                double number = double.Parse(current.Substring(1, current.Length - 2));

                int firstElementIndex = alphabet.IndexOf(char.ToUpper(firsLetter));
                int secondElementIndex = alphabet.IndexOf(char.ToUpper(lastLetter));

                if ((int)firsLetter>=65&&(int)firsLetter<=90)
                {
                    number = number / (firstElementIndex+1);//za da ne delim na 0

                }
                else
                {
                    number = number * (firstElementIndex + 1);
                }

                if ((int)lastLetter >= 65 && (int)lastLetter <= 90)
                {
                    number = number - ( secondElementIndex + 1);//za da ne delim na 0

                }
                else
                {
                    number = number + (secondElementIndex + 1);
                }

                result += number;

            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
