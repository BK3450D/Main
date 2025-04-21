using System;

namespace movetest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map =
            {
              {'#','#','#','#','#','#','#','#','#','#','#'},
              {'#',' ',' ',' ',' ',' ',' ',' ',' ','*','#'},
              {'#',' ',' ',' ','*',' ',' ','#','#','*','#'},
              {'#',' ',' ',' ',' ',' ',' ','#','#','*','#'},
              {'#',' ',' ','#',' ',' ',' ',' ',' ','*','#'},
              {'#','#','#','#','#','#','#','#','#','#','#'},
            };

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            int startingPositionX = 1;
            int startingPositionY = 1;
            int score = 0;

            char playerIcon = '@';
            char walls = '#';
            char emptyСell = ' ';
            char money = '*';

            while (true)
            {
                Console.Clear();

                DrawMap(map);
                Console.SetCursorPosition(startingPositionX, startingPositionY);
                Console.WriteLine(playerIcon);

                Console.SetCursorPosition(0, map.GetLength(0) + 1);
                Console.WriteLine("Счёт: " + score);

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                HandleInput(pressedKey, ref startingPositionX, ref startingPositionY, map, walls, money, emptyСell);

                score = IncreaseScore(startingPositionX, startingPositionY, money, map, score, emptyСell);
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int positionX, ref int positionY, char[,] map, char walls, char money, char emptyСell)
        {
            int[] direction = GetDirectionOfMove(pressedKey);

            int nextPositionX = positionX + direction[0];
            int nextPositionY = positionY + direction[1];

            char nextCell = map[nextPositionY, nextPositionX];

            if (nextCell == emptyСell || nextCell == money)
            {
                positionY = nextPositionY;
                positionX = nextPositionX;
            }
        }

        private static int IncreaseScore(int positionX, int positionY, char money, char[,] map, int score, char emptyСell)
        {
            if (map[positionY, positionX] == money)
            {
                score = CollectingMoney(positionX, positionY, map, score, emptyСell);
            }

            return score;
        }

        private static int CollectingMoney(int positionX, int positionY, char[,] map, int score, char emptyСell)
        {
            score++;
            map[positionY, positionX] = emptyСell;

            return score;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                
                Console.WriteLine();
            }
        }

        private static int[] GetDirectionOfMove(ConsoleKeyInfo pressedKey)
        {
            ConsoleKey moveUpCommand = ConsoleKey.UpArrow;
            ConsoleKey moveDown = ConsoleKey.DownArrow;
            ConsoleKey moveLeft = ConsoleKey.LeftArrow;
            ConsoleKey moveReght = ConsoleKey.RightArrow;

            int[] directionOfMovement = { 0, 0 };

            if (pressedKey.Key == moveUpCommand)
            {
                directionOfMovement[1] = -1;
            }
            if (pressedKey.Key == moveDown)
            {
                directionOfMovement[1] = 1;
            }
            if (pressedKey.Key == moveLeft)
            {
                directionOfMovement[0] = -1;
            }
            if (pressedKey.Key == moveReght)
            {
                directionOfMovement[0] = 1;
            }

            return directionOfMovement;
        }
    }
}
