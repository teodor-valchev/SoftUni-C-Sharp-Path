using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();


            int totalCarsPassed = 0;
            while (true)
            {
                string cmd = Console.ReadLine();

                int greenLight = greenLightDuration;
                int freeWindow = freeWindowDuration;

                if (cmd == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
                    return;

                }
                if (cmd == "green")
                {
                    while (greenLight > 0 && cars.Count != 0)
                    {
                        string firstInQue = cars.Dequeue();//взимаме първата кола
                        greenLight -= firstInQue.Length;

                        if (greenLight > 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            freeWindow += greenLight;
                            if (freeWindow < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstInQue} was hit at {firstInQue[firstInQue.Length+freeWindow]}.");
                                return;
                            }
                            totalCarsPassed++;
                        }
                    }


                }
                else
                {
                    cars.Enqueue(cmd);
                }

            }

        }
    }
}
