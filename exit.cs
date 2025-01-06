using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string input = "exit";
           
            while (true)
            {
                Console.Write("Введите: [exit]: ");
                userInput = Console.ReadLine();

                if (userInput == input)
                {
                    Console.WriteLine("Выход");
                    break;
                }
            }
        }
    }
}