using System;

namespace shafl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            int minRandomNumbers = 0, maxRandomNumbers = 9;

            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumbers, maxRandomNumbers);
            }

            Console.Write("Исходный массив:");
            PrintArray(numbers);

            Shuffle(numbers);
            Console.WriteLine();

            Console.Write("Перемешанный массив:");
            PrintArray(numbers);
        }
        static void Shuffle(int[] array)
        {
            Random randomShuffle = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = randomShuffle.Next(0, i + 1); 
                                             
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        static void PrintArray(int[] array)
        {
            foreach (var sub in array)
            {
                Console.Write(sub);
            }
        }
    }
}

