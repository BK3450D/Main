using System;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(88,3,5);
            player.ShowInfo();

            Player player2 = new Player();
            player2.ShowInfo();           
        }
    }

    class Player
    {
        private const int MaxHealth = 100;
        private const int MinHealth = 0;
        private const int MaxArmor = 5;
        private const int MinArmor = 0;
        private const int MaxDamage = 10;
        private const int MinDamage = 0;

        private int Health;
        private int Armor;
        private int Damage;

        public Player()
        {
            Health = MaxHealth;
            Armor = MaxArmor;
            Damage = MaxDamage;
        }

        public Player(int healt, int armor, int damage)
        {
            Health = GetBasicParameters(healt, MinHealth, MaxHealth);
            Armor = GetBasicParameters(armor, MinArmor, MaxArmor);
            Damage = GetBasicParameters(damage, MinDamage, MaxDamage);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Здоровье: {Health}\nБроня: {Armor}\nУрон: {Damage} ");
        }

        private int GetBasicParameters(int value, int minValue, int maxValue)
        {
            if (value > MaxHealth)
                return maxValue;
            if (value < minValue)
                return minValue;
            return value;
        }
    }
}
