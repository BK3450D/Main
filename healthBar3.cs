using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 99;
            int maxHealth = 100;

            int mana = 55;
            int maxMana = 100;

            DrawHealthBar(health, maxHealth);
            DrawHealthBar(mana, maxMana);
        }
        static void DrawHealthBar(int completedPercentage, int barLength)
        {
            char startOfBoxBars = '[';
            char endOfBoxBars = ']';

            char shadedBarPercentage = '#';
            char missingBarPercentage = '_';

            Console.Write(startOfBoxBars);

            string bar = RepeatCharacter(shadedBarPercentage, completedPercentage);

            int максДлиннаБара = barLength - completedPercentage;

            for (int i = 0; i < максДлиннаБара; i++)
            {
                bar += missingBarPercentage;
            }

            Console.Write(bar + endOfBoxBars);
            Console.WriteLine();
        }
        static string RepeatCharacter(char symbol, int count)
        {
            return new string(symbol, count);
        }
    }
}
