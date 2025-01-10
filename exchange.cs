﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandRUBtoUSD = "1";
            const string CommandRUBtoEUR = "2";
            const string CommandUSDtoRUB = "3";
            const string CommandUSDtoEUR = "4";
            const string CommandEURtoUSD = "5";
            const string CommandEURtoRUB = "6";

            float balanceRUB;
            float balanceUSD;
            float balanceEUR;
            float exchangeCurrencyCount;

            float RUBtoUSD = 0.2897f, RUBtoEUR = 0.277f;
            float USDtoRUB = 3.452f, USDtoEUR = 0.9562f;
            float EURtoRUB = 3.61f, EURtoUSD = 1.0458f;

            string exitCommand = "0";

            Console.WriteLine("Добро пожаловать в обмен валют!");
            Console.Write("Введите баланс RUB: ");
            balanceRUB = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс USD: ");
            balanceUSD = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс EUR: ");
            balanceEUR = Convert.ToSingle(Console.ReadLine());

            while (balanceRUB <= -1 || balanceUSD <= -1 || balanceEUR <= -1)

            {
                Console.WriteLine("Неверый баланс  повторите попытку");
                Console.Write("Введите баланс RUB: ");
                balanceRUB = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите баланс USD: ");
                balanceUSD = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите баланс EUR: ");
                balanceEUR = Convert.ToSingle(Console.ReadLine());
            }

            while (true)
            {
                Console.WriteLine("Ваш баланс:");
                Console.WriteLine($"RUB: {balanceRUB}");
                Console.WriteLine($"USD: {balanceUSD}");
                Console.WriteLine($"EUR: {balanceEUR}");
                Console.WriteLine("Выберите необходимаю операцию.");
                Console.WriteLine($"{CommandRUBtoUSD}. Обмен RUB на USD");//1
                Console.WriteLine($"{CommandRUBtoEUR}. Обмен RUB на EUR");//2
                Console.WriteLine($"{CommandUSDtoRUB}. Обмен USD на RUB");//3
                Console.WriteLine($"{CommandUSDtoEUR}. Обмен USD на EUR");//4
                Console.WriteLine($"{CommandEURtoUSD}. Обмен EUR на USD");//5
                Console.WriteLine($"{CommandEURtoRUB}. Обмен EUR на RUB");//6
                Console.WriteLine($"{exitCommand}. Выход.");
                Console.Write("Ваш выбор: ");

                string desiredOperation = Console.ReadLine();

                if (desiredOperation == exitCommand)
                {
                    break;
                }
                switch (desiredOperation)
                {
                    case CommandRUBtoUSD://1
                        Console.WriteLine("Обмен RUB на USD.");
                        Console.Write("Сумма RUB для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                        if (exchangeCurrencyCount >= 0 && balanceRUB >= exchangeCurrencyCount)
                        {
                            balanceRUB -= exchangeCurrencyCount;
                            balanceUSD += exchangeCurrencyCount / USDtoRUB;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств.");
                        }
                        break;

                    case CommandRUBtoEUR://2
                        Console.WriteLine("Обмен RUB на EUR.");
                        Console.Write("Сумма RUB для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                        if (exchangeCurrencyCount >= 0 && balanceRUB >= exchangeCurrencyCount)
                        {
                            balanceRUB -= exchangeCurrencyCount;
                            balanceEUR += exchangeCurrencyCount / USDtoRUB;//!
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandUSDtoRUB://3
                        Console.WriteLine("Обмен USD на RUB.");
                        Console.Write("Сумма USD для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                        if (exchangeCurrencyCount >= 0 && balanceUSD >= exchangeCurrencyCount)
                        {
                            balanceUSD -= exchangeCurrencyCount;
                            balanceRUB += exchangeCurrencyCount / RUBtoUSD;//!
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandUSDtoEUR://4
                        Console.WriteLine("Обмен USD на EUR.");
                        Console.Write("Сумма USD для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                        if (exchangeCurrencyCount >= 0 && balanceUSD >= exchangeCurrencyCount)
                        {
                            balanceUSD -= exchangeCurrencyCount;
                            balanceEUR += exchangeCurrencyCount / USDtoRUB;//!
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandEURtoUSD://5
                        Console.WriteLine("Обмен EUR на USD.");
                        Console.Write("Сколько вы хотите обменять? ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                        if (exchangeCurrencyCount >= 0 && balanceEUR >= exchangeCurrencyCount)
                        {
                            balanceEUR -= exchangeCurrencyCount;
                            balanceUSD += exchangeCurrencyCount / USDtoEUR;//!
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandEURtoRUB://6
                        Console.WriteLine("Обмен EUR на RUB.");
                        Console.Write("Сколько вы хотите обменять? ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                        if (exchangeCurrencyCount >= 0 && balanceEUR >= exchangeCurrencyCount)
                        {
                            balanceEUR -= exchangeCurrencyCount;
                            balanceRUB += exchangeCurrencyCount * EURtoRUB;//!
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    default:
                        Console.WriteLine($"Неверная операция.");
                        break;
                }
            }

            Console.WriteLine("Обмен валют завершён.");
        }
    }
    
}
