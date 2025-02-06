using System;

namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 30;
            int[] numbers = new int[size];

            int maxRandom = 100;
            int minRandom = 1;

            int step = 1;

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandom, maxRandom + 1);

                Console.Write(numbers[i] + " ");
            }

            int lastNunber = numbers[numbers.Length - 1];
            int penultimateNumber = numbers[numbers.Length - 2];

            if (numbers[0] > numbers[1])
            {
                Console.WriteLine();
                Console.WriteLine(numbers[0]);
            }
            if (lastNunber > penultimateNumber)
            {
                Console.WriteLine();
                Console.WriteLine(lastNunber);
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                bool isLocalMax = false;

                if (numbers[i] > numbers[i - step] && numbers[i] > numbers[i + step])
                {
                    isLocalMax = true;
                }

                if (isLocalMax == true)
                {
                    Console.Write(numbers[i]);
                    Console.WriteLine();
                }
            }
        }
    }
}

