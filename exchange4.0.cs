using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandRubToUsd = "1";
            const string CommandRubToEur = "2";
            const string CommandUsdToRub = "3";
            const string CommandUsdToEur = "4";
            const string CommandEurToUsd = "5";
            const string CommandEurToRub = "6";
            const string CommandExit = "0";

            float balanceRub;
            float balanceUsd;
            float balanceEur;

            float exchangeCurrencyCount;

            float rubToUsd = 0.013f, rubToEur = 0.011f;
            float usdToRub = 75f, usdToEur = 0.85f;
            float eurtoRub = 88f, eurToUsd = 1.18f;

            Console.WriteLine("Добро пожаловать в обмен валют!");

            Console.Write("Введите баланс RUB: ");
            balanceRub = Convert.ToSingle(Console.ReadLine());

            Console.Write("Введите баланс USD: ");
            balanceUsd = Convert.ToSingle(Console.ReadLine());

            Console.Write("Введите баланс EUR: ");
            balanceEur = Convert.ToSingle(Console.ReadLine());

            while (balanceRub <= -1 || balanceUsd <= -1 || balanceEur <= -1)
            {
                Console.WriteLine("Неверый баланс  повторите попытку");
                Console.Write("Введите баланс RUB: ");
                balanceRub = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите баланс USD: ");
                balanceUsd = Convert.ToSingle(Console.ReadLine());
                Console.Write("Введите баланс EUR: ");
                balanceEur = Convert.ToSingle(Console.ReadLine());
            }

            bool canExit = false;

            while (canExit == false)
            {
                Console.WriteLine("Ваш баланс:");
                Console.WriteLine($"RUB: {balanceRub}");
                Console.WriteLine($"USD: {balanceUsd}");
                Console.WriteLine($"EUR: {balanceEur}");
                Console.WriteLine("Выберите необходимаю операцию.");
                Console.WriteLine($"{CommandRubToUsd}. Обмен RUB на USD");
                Console.WriteLine($"{CommandRubToEur}. Обмен RUB на EUR");
                Console.WriteLine($"{CommandUsdToRub}. Обмен USD на RUB");
                Console.WriteLine($"{CommandUsdToEur}. Обмен USD на EUR");
                Console.WriteLine($"{CommandEurToUsd}. Обмен EUR на USD");
                Console.WriteLine($"{CommandEurToRub}. Обмен EUR на RUB");
                Console.WriteLine($"{CommandExit}. Выход.");

                Console.Write("Ваш выбор: ");
                string desiredOperation = Console.ReadLine();

                switch (desiredOperation)
                {
                    case CommandRubToUsd:
                        Console.WriteLine("Обмен RUB на USD.");

                        Console.Write("Сумма RUB для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (exchangeCurrencyCount >= 0 && balanceRub >= exchangeCurrencyCount)
                        {
                            balanceRub -= exchangeCurrencyCount;
                            balanceUsd += exchangeCurrencyCount * rubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств.");
                        }
                        break;

                    case CommandRubToEur:
                        Console.WriteLine("Обмен RUB на EUR.");

                        Console.Write("Сумма RUB для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (exchangeCurrencyCount >= 0 && balanceRub >= exchangeCurrencyCount)
                        {
                            balanceRub -= exchangeCurrencyCount;
                            balanceEur += exchangeCurrencyCount * rubToEur;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandUsdToRub:
                        Console.WriteLine("Обмен USD на RUB.");

                        Console.Write("Сумма USD для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (exchangeCurrencyCount >= 0 && balanceUsd >= exchangeCurrencyCount)
                        {
                            balanceUsd -= exchangeCurrencyCount;
                            balanceRub += exchangeCurrencyCount * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandUsdToEur:
                        Console.WriteLine("Обмен USD на EUR.");

                        Console.Write("Сумма USD для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (exchangeCurrencyCount >= 0 && balanceUsd >= exchangeCurrencyCount)
                        {
                            balanceUsd -= exchangeCurrencyCount;
                            balanceEur += exchangeCurrencyCount * usdToEur;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandEurToUsd:
                        Console.WriteLine("Обмен EUR на USD.");

                        Console.Write("Сумма EUR для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (exchangeCurrencyCount >= 0 && balanceEur >= exchangeCurrencyCount)
                        {
                            balanceEur -= exchangeCurrencyCount;
                            balanceUsd += exchangeCurrencyCount * eurToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandEurToRub:
                        Console.WriteLine("Обмен EUR на RUB.");

                        Console.Write("Сумма EUR для обмена: ");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (exchangeCurrencyCount >= 0 && balanceEur >= exchangeCurrencyCount)
                        {
                            balanceEur -= exchangeCurrencyCount;
                            balanceRub += exchangeCurrencyCount * eurtoRub;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                        break;

                    case CommandExit:
                        canExit = true;
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
