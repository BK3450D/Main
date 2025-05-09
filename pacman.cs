﻿using System;

namespace movetest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map =
            {
              {'#','#','#','#','#','#','#','#','#','#','#', },
              {'#',' ',' ',' ',' ',' ',' ',' ',' ','*','#', },
              {'#',' ',' ',' ','*',' ',' ','#','#','*','#', },
              {'#',' ',' ',' ',' ',' ',' ','#','#','*','#', },
              {'#',' ',' ','#',' ',' ',' ',' ',' ','*','#', },
              {'#','#','#','#','#','#','#','#','#','#','#', },
            };

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            int startingPositionX = 1;
            int startingPositionY = 1;

            int count = 0;

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
                Console.WriteLine("Счёт: " + count);

                ConsoleKeyInfo pressedKey = Console.ReadKey();


                HandleInput(pressedKey, ref startingPositionX, ref startingPositionY, map, walls, money, ref count, emptyСell);
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int positionX, ref int positionY, char[,] map, char walls, char money,ref int  count, char emptyСell)
        {
            int[] direction = GetDirectionOfMove(pressedKey);

            int nextPositionX = positionX + direction[0];
            int nextPositionY = positionY + direction[1];

            if (map[nextPositionY, nextPositionX] != walls)
            {
                if (map[nextPositionY, nextPositionX] == money)
                {
                    count++;
                    map[nextPositionY, nextPositionX] = emptyСell; 
                }

                positionX = nextPositionX;
                positionY = nextPositionY;
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
