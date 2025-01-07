using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string exitCommand = "EXIT";

            Console.Write($"Введите {exitCommand} для завершения программы: ");
            userInput = Console.ReadLine();
         
            while (userInput != exitCommand)
            {
                Console.Write("Повторите попытку: ");
                userInput = Console.ReadLine();
            }
            
            if (userInput == exitCommand)
            {
                Console.WriteLine("Программа завершина");
            }
        }
    }
}
