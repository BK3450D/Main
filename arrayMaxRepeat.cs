using System;

namespace arrayRepitsNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = new int[30];

            int maxRandom = 5;
            int minRandom = 1;

            int count = number[0];
            int repeatCount = 0;

            int maxRepeat = 0;
            int maxRepeatNumber = 0;

            Random random = new Random();

            for (int i = 0; i < number.Length; i++)
            {
                number[i] = random.Next(minRandom, maxRandom + 1);

                Console.Write(number[i] + ",");
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == count)
                {
                    repeatCount++;

                    if (repeatCount > maxRepeat)
                    {
                        maxRepeat = repeatCount;
                        maxRepeatNumber = count;
                    }
                }
                else
                {
                    count = number[i];
                    repeatCount = 1;
                }
            }

            Console.Write($" - число {maxRepeatNumber} повторяется {maxRepeat} раза подряд.");
        }
    }
}
