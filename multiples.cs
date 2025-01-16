using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxRandom = 25;
            int minRandom = 10;

            int minValue = 50;
            int maxValue = 150;

            int countDuration = 0;

            Random random = new Random();
            int nunber = random.Next(minRandom, maxRandom);

            Console.WriteLine($"Генерация случайного числа = {nunber}");

            while (minValue <= maxValue)
            {
                int count = minValue;

                while (count > 0)
                {
                    count -= nunber;
                }

                if (count == 0)
                {
                    countDuration++;
                }

                minValue++;
            }
            Console.WriteLine($"Количество чисел от {minValue} до {maxValue}, кратных {nunber}: {countDuration}");
        }
    }
}
