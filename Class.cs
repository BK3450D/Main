using System;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(55, 110, 119);

            player.ShowPlayerInfo();
        }
    }

    class Player
    {  
        public int Healt { get; private set; }
        public int Arrmor { get; private set; }
        public int Damage { get; private set; }

        public Player(int healt, int arrmor, int damage)
        {
            if (healt > 100)
                Healt = 100;
            else
                Healt = healt;

            if (arrmor > 10)
                Arrmor = 10;
            else

                Arrmor = arrmor;
            if (damage > 20)
                Damage = 20;
            else
                Damage = damage;
        }

        public Player()
        {
            Healt = 100;
            Arrmor = 5;
            Damage = 10;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine($"Здоровье: {Healt}\nБроня: {Arrmor}\nУрон: {Damage} ");
        }
    }
}


