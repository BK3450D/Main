using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxRandom = 25;
            int minRandom = 10;
            int minValue = 50;
            int maxValue = 150;

            Random random = new Random();
            int randomNunber = random.Next(minRandom, maxRandom + 1);

            Console.WriteLine($"Сгенерированное число: {randomNunber}");

            int count = 0;

            for (int i = 0; i >= maxValue; i++)
            {
                i += randomNunber;

                if (i >= minValue)
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество чисел от {minValue} до {maxValue}, кратных {randomNunber}: {count}");
        }
    }
}
