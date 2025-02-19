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
            int barLength = 100;
            int completedPercentage = 2;

            DrawHealthBar(completedPercentage, barLength);
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
        }
        static string RepeatCharacter(char symbol, int count)
        {
            return new string(symbol, count);
        }
    }
}
