using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];

            int maxRandom = 10;
            int minRandom = 1;

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandom, maxRandom + 1);

                Console.Write(numbers[i] + " ");
            }

            if (numbers[0] > numbers[1])
            {
                Console.WriteLine();
                Console.WriteLine(numbers[0]);
            }

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                bool isLocalMax = numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1];

                if (isLocalMax == true)
                {
                    Console.Write(numbers[i]);
                    Console.WriteLine();
                }
            }

            int lastIndex = numbers.Length - 1;

            if (numbers[lastIndex] > numbers[lastIndex - 1])
            {
                Console.WriteLine(numbers[lastIndex]);
            }
        }
    }
}
