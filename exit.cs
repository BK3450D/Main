using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exit = "exit";
            string programInput;
        
            for (; ; )
            {
                Console.Write("Введите exit: ");
                programInput = Console.ReadLine();
                if (programInput == exit)
                {
                    Console.WriteLine("Конец");
                break;
                }
            } 
        }
    }
}
