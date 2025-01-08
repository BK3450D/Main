﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandWhatyear = "1";
            const string CommandlifeOnMars = "2";
            const string CommandRandomNumber = "3";
            const string CommandСlearСonsole = "4";

            string userInput;
            string exitCommand = "5";

            int maxRandom = 666;
            int year = 2025;
            int menuiItemOne = 1;
            int menuItemFive = 5;

            Console.WriteLine($"Введите цифру от {menuiItemOne} до {menuItemFive} для выбора комманды");
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
                    case CommandWhatyear:
                        Console.WriteLine(year);
                        userInput = Console.ReadLine();
                        break;

                    case CommandlifeOnMars:
                        Console.WriteLine("Вроде есть, а может и нет");
                        userInput = Console.ReadLine();
                        break;

                    case CommandRandomNumber:
                        Random random = new Random();
                        int nunber = random.Next(maxRandom);
                        Console.WriteLine(nunber);
                        userInput = Console.ReadLine();
                        break;

                    case CommandСlearСonsole:
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
