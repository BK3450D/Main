using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int nunber = rand.Next(0, 11);
            int sumOfNumbers = 0;

            for (int i = 0; i <= nunber; i++)
            {
                Console.WriteLine(i);

                if (i % 3 == 0 || i % 5 == 0)
                {
                    sumOfNumbers += i;
                }
            }
            Console.WriteLine(sumOfNumbers);

            
          
            

     
        }
    }
    
}
