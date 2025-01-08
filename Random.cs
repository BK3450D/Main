using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dividerOne = 3;
            int dividerTwo = 5;
            int maxRandom = 100;
            int sumOfNumbers = 0;

            Random random = new Random();
            int nunber = random.Next(0, maxRandom);

            for (int i = 0; i <= nunber; i++)
            {
                Console.WriteLine(i);

                if (i % dividerOne == 0 || i % dividerTwo == 0)
                {
                    sumOfNumbers += i;
                }
            }

            Console.WriteLine(sumOfNumbers);
        }
    }
}
