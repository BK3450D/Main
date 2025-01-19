using System;

namespace ConsoleApp25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxRandom = 26;
            int minRandom = 10;
            int minValue = 50;
            int maxValue = 150;

            Random rand = new Random();
            int randomNunber = rand.Next(minRandom, maxRandom);

            Console.WriteLine($"Сгенерированное число: {randomNunber}");

            int count = 0;

            for (int i = minValue; i <= maxValue; i++)
            {
                int sum = 0;

                for (int j = 0; sum < i; j++)
                {
                    sum += randomNunber;
                }

                if (sum == i)
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество чисел от {minValue} до {maxValue}, кратных {randomNunber}: {count}");
        }
    }
}
