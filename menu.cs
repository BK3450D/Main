using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandNunberOne = "1";
            const string CommandNunberTwo = "2";
            const string CommandNunberThree = "3";
            const string CommandNunberFour = "4";
            string userInput;
            string exitCommand = "5";

            Console.WriteLine("Введите цифру от 1 до 5 для выбора комманды");
            Console.WriteLine("1. Какой сейчас год.");
            Console.WriteLine("2. Есть ли жизнь на марсе.");
            Console.WriteLine("3. Показать случайное число. ");
            Console.WriteLine("4. Очистить консоль.");
            Console.WriteLine("5. Выход.");
            
            userInput = Console.ReadLine();

            while (userInput != exitCommand)
            {
                switch (userInput)
                {
                    case CommandNunberOne:
                        Console.WriteLine("2025 ");
                        userInput = Console.ReadLine();
                        break;

                    case CommandNunberTwo:
                        Console.WriteLine("Вроде есть, а может и нет");                      
                        userInput = Console.ReadLine();
                        break;

                    case CommandNunberThree:
                        Random random = new Random();
                        int nunber = random.Next(0, 666);
                        Console.WriteLine(nunber);
                        userInput = Console.ReadLine();
                        break;

                    case CommandNunberFour:
                        Console.Clear();
                        Console.Write(" ");
                        userInput = Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        userInput = Console.ReadLine();
                        break;
                }
            }
            if (userInput == exitCommand)
            {
                Console.WriteLine("Программа завершина");
            }
        }
    }
}
