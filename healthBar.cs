using System;

namespace healsbar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 4, maxHealth = 10;
            int mana = 9, maxMana = 10;
            
            DrawBars(health, maxHealth, 0, '#');
            DrawBars(mana, maxMana, 1, '&');
            
        }
        static void DrawBars(int value, int maxValue, int position, char symbol = '|')
        {
            char startOfHealthBox = '[', endOfHealthBox = ']';

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(0, position);
            Console.Write(startOfHealthBox);
            Console.Write(bar);

            bar = "";

            for (int i = value;i < maxValue; i++)
            {
                bar += "_";
            }

            Console.Write(bar + endOfHealthBox);
        }
    }
}
