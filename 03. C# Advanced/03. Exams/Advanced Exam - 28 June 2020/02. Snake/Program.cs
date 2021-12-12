using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            char[,] field = new char[fieldSize, fieldSize];
            int snakeRow = 0;
            int snakeCol = 0;


            for (int row = 0; row < field.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
            int foodQuanity = 0;
            bool gameLost = false;

            while (foodQuanity != 10)
            {
                int newSnakeRowPosition = snakeRow;
                int newSnakeColPosition = snakeCol;
                string command = Console.ReadLine();

                if (command == "left")
                {
                    newSnakeColPosition--;
                }
                else if (command == "right")
                {
                    newSnakeColPosition++;
                }
                else if (command == "up")
                {
                    newSnakeRowPosition--;
                }
                else if (command == "down")
                {
                    newSnakeRowPosition++;
                }
                if (!isValid(field, newSnakeRowPosition, newSnakeColPosition))
                {
                    field[snakeRow, snakeCol] = '.';
                    gameLost = true;
                    break;
                }
                if (isValid(field, newSnakeRowPosition, newSnakeColPosition) && field[newSnakeRowPosition, newSnakeColPosition] == '-')
                {
                    field[snakeRow, snakeCol] = '.';
                    field[newSnakeRowPosition, newSnakeColPosition] = 'S';
                    snakeRow = newSnakeRowPosition;
                    snakeCol = newSnakeColPosition;


                }
                else if (isValid(field, newSnakeRowPosition, newSnakeColPosition) && field[newSnakeRowPosition, newSnakeColPosition] == 'B')
                {
                    field[snakeRow, snakeCol] = '.';
                    for (int row = 0; row < field.GetLength(0); row++)
                    {
                        for (int col = 0; col < field.GetLength(1); col++)
                        {
                            if (field[row, col] == 'B')
                            {
                                field[newSnakeRowPosition, newSnakeColPosition] = '.';
                                field[row, col] = 'S';
                                snakeRow = row;
                                snakeCol = col;

                            }
                        }
                    }


                }
                else if (isValid(field, newSnakeRowPosition, newSnakeColPosition) && field[newSnakeRowPosition, newSnakeColPosition] == '*')
                {
                    field[snakeRow, snakeCol] = '.';
                    field[newSnakeRowPosition, newSnakeColPosition] = 'S';
                    snakeRow = newSnakeRowPosition;
                    snakeCol = newSnakeColPosition;
                    foodQuanity++;

                }



            }
            if (gameLost == true)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodQuanity}");
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
