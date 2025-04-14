using System;


namespace movetest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map =
            {
              {'#','#','#','#','#','#','#','#','#','#','#', },
              {'#',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
              {'#',' ',' ','#',' ',' ',' ','#','#',' ','#', },
              {'#',' ','*','*',' ',' ',' ','#','#',' ','#', },
              {'#',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
              {'#','#','#','#','#','#','#','#','#','#','#', },
            };

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            int startingPositionX = 1;
            int startingPositionY = 1;

            int count = 0;

            bool canMove = false;

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

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                HandleInput(pressedKey, ref startingPositionX, ref startingPositionY, map, walls, money, count, ref canMove);
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int positionX, ref int positionY, char[,] map, char walls, char money, int count, ref bool canMove)
        {
            int[] direction = GetDirectionOfMove(pressedKey);


            int positionXIndex = 1;
            int positionYIndex = 0;

            int nextPositionX = positionX + direction[0];
            int nextPositionY = positionY + direction[1];

            if (map[nextPositionX, nextPositionY] == ' ')
            {
                positionX = nextPositionX;
                positionY = nextPositionY;

                canMove = true;
            }

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
            int[] directionOfMovement = { 0, 0 };

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveUp(ref directionOfMovement);
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown(ref directionOfMovement);
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeft(ref directionOfMovement);
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight(ref directionOfMovement);
                    break;

            }

            return directionOfMovement;
        }

        private static void MoveUp(ref int[] directionOfMovement)
        {
            directionOfMovement[1] = -1;
        }

        private static void MoveDown(ref int[] directionOfMovement)
        {
            directionOfMovement[1] = 1;
        }

        private static void MoveLeft(ref int[] directionOfMovement)
        {
            directionOfMovement[0] = -1;
        }

        private static void MoveRight(ref int[] directionOfMovement)
        {
            directionOfMovement[0] = 1;
        }
    }
}
