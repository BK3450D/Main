using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];

            int maxRandom = 100;
            int minRandom = 1;
            int step = 1;

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandom, maxRandom + 1);

                Console.Write(array[i] + " ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                bool isLocalMax = false;

                if (i == 0)
                {
                    if (array[i] > array[i + step])
                    {
                        isLocalMax = true;
                    }
                }
                else if (i == array.Length - 1)
                {
                    if (array[i] > array[i - step])
                    {
                        isLocalMax = true;
                    }
                }
                else
                {
                    if (array[i] > array[i - step] && array[i] > array[i + step])
                    {
                        isLocalMax = true;
                    }
                }

                if (isLocalMax == true)
                {
                    Console.WriteLine();
                    Console.Write(array[i]);
                }
            }
        }
    }
}
