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
              {'#',' ','*',' ',' ',' ',' ',' ',' ','*','#'},
              {'#',' ','*',' ','*',' ',' ','#','#','*','#'},
              {'#',' ','*',' ',' ',' ',' ','#','#','*','#'},
              {'#',' ',' ','#',' ',' ',' ','*','*','*','#'},
              {'#','#','#','#','#','#','#','#','#','#','#'},
            };

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            int startingPositionX = 1;
            int startingPositionY = 1;
            int nextPositionX;
            int nextPositionY;
            int score = 0;
            int maxScore = 10;

            char playerIcon = '@';
            char wall = '#';
            char emptyCell = ' ';
            char money = '*';

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                DrawMap(map);
                DrawPlayer(startingPositionX, startingPositionY, playerIcon, map);
                DrawScore(score);

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                GetNextPosition(pressedKey, startingPositionX, startingPositionY, out nextPositionX, out nextPositionY);

                if (CanMove(nextPositionX, nextPositionY, map, wall))
                {
                    MovePlayer(nextPositionX, nextPositionY, ref startingPositionX, ref startingPositionY);

                    score = IncreaseScore(startingPositionX, startingPositionY, money, map, score, emptyCell);
                }

                if (score == maxScore)
                {
                    Console.Clear();
                    Console.WriteLine($"Вы набрали максимальное количество очков: {score}");
                    Console.ReadKey();

                    isRunning = false;
                }
            }
        }

        static void GetNextPosition(ConsoleKeyInfo pressedKey, int positionX, int positionY, out int nextPositionX, out int nextPositionY)
        {
            int[] direction = GetDirection(pressedKey);

            nextPositionX = positionX + direction[0];
            nextPositionY = positionY + direction[1];
        }

        private static void DrawScore(int score)
        {
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Счёт: " + score);
        }

        private static void DrawPlayer(int PositionX, int PositionY, char playerIcon, char[,] map)
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write(playerIcon);
            Console.SetCursorPosition(0, map.GetLength(0) + 1);
        }

        static bool CanMove(int nextPositionX, int nextPositionY, char[,] map, char wall)
        {
            if (nextPositionX == wall || nextPositionY == wall)
                return false;

            return map[nextPositionY, nextPositionX] != wall;
        }

        private static void MovePlayer(int nextPositionX, int nextPositionY, ref int positionX, ref int positionY)
        {
            positionX = nextPositionX;
            positionY = nextPositionY;
        }

        private static int IncreaseScore(int x, int y, char money, char[,] map, int score, char emptyCell)
        {
            if (map[y, x] == money)
            {
                score = CollectMoney(x, y, map, score, emptyCell);
            }

            return score;
        }

        private static int CollectMoney(int positionX, int positionY, char[,] map, int score, char emptyСell)
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

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
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
