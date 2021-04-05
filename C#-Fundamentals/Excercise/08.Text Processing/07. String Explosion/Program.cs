using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = Console.ReadLine();
            int bomb = 0;
            for (int i = 0; i < field.Length; i++)
            {
                var currentChar = field[i];

                if (currentChar == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString());
                    continue;
                }

                if (bomb > 0)
                {
                    field = field.Remove(i, 1);
                    i--;// za da ne se burkat index
                    bomb--;
                }
            }

            Console.WriteLine(field);
        }
    }
}
