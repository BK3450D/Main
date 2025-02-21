using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barLength = 50;

            int healthProcent = 75;

            int manaProcent = 90;

            int maxPercent = 100;

            int percent = barLength * maxPercent / healthProcent;

            DrawBars(healthProcent, barLength);
            DrawBars(manaProcent, barLength);
        }
        
        static void DrawBars(int percent, int barLength)
        {
            int symbolCount = barLength * percent / 100;

            char startOfBoxBars = '[';
            char endOfBoxBars = ']';

            char fillingBarPercentage = '#';
            char missingBarPercentage = '_';

            Console.Write(startOfBoxBars);

            string bar = new string(fillingBarPercentage, symbolCount);

            int missingPercentage = barLength - bar.Length;

            string bart =  new string(missingBarPercentage, missingPercentage);

            Console.Write(bar + bart + endOfBoxBars);
            Console.WriteLine();
        }
    }
}
