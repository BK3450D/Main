using System;
using System.IO;
using System.Threading;

namespace ConsoleApp1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char playerIcon = '@';


            Console.CursorVisible = false;

            char[,] map = ReadMap("map.txt");

            

            bool isDrawMap = true;

            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            int startingPositionX = 1;
            int startingPositionY = 1;

            int scor = 0;

            while (isDrawMap)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Magenta;
                DrawMap(map);

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(startingPositionX, startingPositionY);
                Console.WriteLine(playerIcon);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(44, 0);
                Console.Write($"Scor = {scor}");

                pressedKey = Console.ReadKey();

                HandleInput(pressedKey, ref startingPositionX, ref startingPositionY, map, ref scor);

                Thread.Sleep(200);
            }
        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }

            return maxLength;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write("\n");
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int startingPositionX, ref int startingPositionY, char[,] map, ref int score)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPacmanPositionX = startingPositionX + direction[0];
            int nextPacmanPositionY = startingPositionY + direction[1];

            char emptyCell = ' ';
            char nextCell = map[nextPacmanPositionX, nextPacmanPositionY];

            if (nextCell == emptyCell || nextCell == '*')
            {

                Console.Clear();
                startingPositionX = nextPacmanPositionX;
                startingPositionY = nextPacmanPositionY;

                score++;

                map[nextPacmanPositionX, nextPacmanPositionY] = emptyCell;

            }
        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] directionOfMovement = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow)
                directionOfMovement[1] = -1;
            else if (pressedKey.Key == ConsoleKey.DownArrow)
                directionOfMovement[1] = 1;
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
                directionOfMovement[0] = -1;
            else if (pressedKey.Key == ConsoleKey.RightArrow)
                directionOfMovement[0] = 1;

            return directionOfMovement;
        }
    }
}
