using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int flowers = 0;

            string comand = Console.ReadLine();
            while (comand != "End")
            {
                int newBeeRow = beeRow;
                int newBeeCol = beeCol;

                if (comand == "up")
                {
                    newBeeRow--;
                }
                else if (comand == "down")
                {
                    newBeeRow++;
                }
                else if (comand == "left")
                {
                    newBeeCol--;
                }
                else if (comand == "right")
                {
                    newBeeCol++;
                }

                if (!isValid(field, newBeeRow, newBeeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    field[beeRow, beeCol] = '.';

                    break;
                }
                else
                {
                    if (field[newBeeRow, newBeeCol] == '.')
                    {
                        field[beeRow, beeCol] = '.';
                        field[newBeeRow, newBeeCol] = 'B';
                        beeRow = newBeeRow;
                        beeCol = newBeeCol;
                    }
                    else if (field[newBeeRow, newBeeCol] == 'f')
                    {
                        field[beeRow, beeCol] = '.';
                        field[newBeeRow, newBeeCol] = 'B';
                        beeRow = newBeeRow;
                        beeCol = newBeeCol;
                        flowers++;
                    }
                    else if (field[newBeeRow, newBeeCol] == 'O')
                    {
                        if (comand == "up" && isValid(field ,newBeeRow - 1, newBeeCol))
                        {
                            if (field[newBeeRow-1, newBeeCol] == 'f')
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow-1, newBeeCol] = 'B';
                                beeRow = newBeeRow-1;
                                beeCol = newBeeCol;
                                flowers++;
                            }
                            else
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow - 1, newBeeCol] = 'B';
                                beeRow = newBeeRow - 1;
                                beeCol = newBeeCol;
                            }
                         

                        }
                        else if (comand == "down" && isValid(field, newBeeRow +1, newBeeCol))
                        {

                            if (field[newBeeRow+1, newBeeCol] == 'f')
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow + 1, newBeeCol] = 'B';
                                beeRow = newBeeRow+1;
                                beeCol = newBeeCol;
                                flowers++;
                               
                            }
                            else
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow + 1, newBeeCol] = 'B';
                                beeRow = newBeeRow + 1;
                                beeCol = newBeeCol;
                            }
                          
                        
                           
                        }
                        else if (comand == "right" && isValid(field, newBeeRow , newBeeCol+1))
                        {
                            if (field[newBeeRow, newBeeCol+1] == 'f')
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow , newBeeCol+1] = 'B';
                                beeRow = newBeeRow;
                                beeCol = newBeeCol+1;
                                flowers++;
                            }
                            else
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow , newBeeCol+1] = 'B';
                                beeRow = newBeeRow ;
                                beeCol = newBeeCol+1;
                            }
                        }
                        else if (comand == "left" && isValid(field, newBeeRow, newBeeCol - 1))
                        {
                            if (field[newBeeRow, newBeeCol-1] == 'f')
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow, newBeeCol - 1] = 'B';
                                beeRow = newBeeRow;
                                beeCol = newBeeCol - 1;
                                flowers++;
                            }
                            else
                            {
                                field[beeRow, beeCol] = '.';
                                field[newBeeRow, newBeeCol] = '.';
                                field[newBeeRow , newBeeCol-1] = 'B';
                                beeRow = newBeeRow ;
                                beeCol = newBeeCol-1;
                            }
                        }
                        else 
                        {
                            Console.WriteLine("The bee got lost!");
                            field[beeRow, beeCol] = '.';
                            break;
                        }
                    }

                }
                comand = Console.ReadLine();
            }

            if (flowers>=5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            Print(field);

        }

        private static bool isValid(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }

        public static void Print(char[,] field)
        {

            for (int row = 0; row < field.GetLength(0); row++)
            {

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
