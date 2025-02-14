using System;

namespace numberSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumbers = new int[10];

            int maxRandomNumber = 10;
            int minRandomNumber = 1;

            Random random = new Random();

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                arrayNumbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);

                Console.Write(arrayNumbers[i] + " | ");

            }

            Console.WriteLine("Изначальный масcив");

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                for (int j = 0; j < arrayNumbers.Length - 1; j++)
                {
                    if (arrayNumbers[j] > arrayNumbers[j + 1])
                    {
                        int temp = arrayNumbers[j];
                        arrayNumbers[j] = arrayNumbers[j + 1];
                        arrayNumbers[j + 1] = temp;
                    }
                }
            }

            foreach (var item in arrayNumbers)
            {
                Console.Write(item + " | ");
            }
            
            Console.WriteLine("Отсортированный массив");
        }
    }
}
