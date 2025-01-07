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
            int start = 5;
            int step = 7;
            int maxValue = 107;

            for (int order = start; order <= maxValue; order += step)
            {
                Console.WriteLine(order);
            }
        }
    }
}
