using System;
using System.Security.Policy;

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
            int score = 0;
            int maxScore = 10;

            char playerIcon = '@';
            char walls = '#';
            char emptyСell = ' ';
            char money = '*';

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                DrawMap(map);
                
                DrowPlayer(startingPositionX, startingPositionY, playerIcon, map);
                
                DrowScore(score);

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                int[] direction = GetDirectionOfMove(pressedKey);

                MovePlayer (direction,ref startingPositionX, ref startingPositionY, map, walls, money, emptyСell);

                score = IncreaseScore(startingPositionX, startingPositionY, money, map, score, emptyСell);

                if (score == maxScore)
                {
                    Console.Clear();

                    Console.WriteLine($"Вы на намбрали максимальное количество очков:{score}");

                    Console.ReadKey();

                    isRunning = false;
                }
            }
        }

        private static void DrowScore(int score)
        {
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Счёт: " + score);
        }

        private static void DrowPlayer(int startingPositionX, int startingPositionY, char playerIcon, char[,] map)
        {
            Console.SetCursorPosition(startingPositionX, startingPositionY);
            Console.WriteLine(playerIcon);

            Console.SetCursorPosition(0, map.GetLength(0) + 1);
        }

        private static void MovePlayer(int[]direction, ref int positionX, ref int positionY, char[,] map, char walls, char money, char emptyСell)
        {

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
                score = CollectMoney(positionX, positionY, map, score, emptyСell);
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
