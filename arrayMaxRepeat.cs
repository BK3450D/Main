using System;

namespace arrayRepitsNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[30];

            int maxNumber = 5;
            int minNumber = 1;

            int repeatCount = 0;

            int maxRepeat = 0;
            int maxRepeatNumber = 0;

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minNumber, maxNumber + 1);

                Console.Write(numbers[i] + ",");
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[0])
                {
                    repeatCount++;

                    if (repeatCount > maxRepeat)
                    {
                        maxRepeat = repeatCount;
                        maxRepeatNumber = numbers[0];
                    }
                }
                else
                {
                    numbers[0] = numbers[i];
                    repeatCount = 1;
                }
            }

            Console.Write($" - число {maxRepeatNumber} повторяется {maxRepeat} раза подряд.");
        }
    }
}
