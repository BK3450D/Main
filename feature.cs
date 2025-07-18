using System;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(3, 3, '#');
            Renderer renderer = new Renderer();
      
            renderer.DrawPlayer(player);
        }
    }

    class Player
    {
        public char PlayerIcon { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public Player(int positionX, int positionY, char playerIcon)
        {
            PositionX = positionX;
            PositionY = positionY;
            PlayerIcon = playerIcon;
        }
    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.WriteLine(player.PlayerIcon);
            Console.ReadKey(true);
        }
    }
}