using System;

class Program
{
    static void Main(string[] args)
    {
        int number = GetNumber();
        Console.WriteLine($"Вы ввели число: {number}");
    }
    static void WriteError()
    {
        ConsoleColor defautColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ошибка: Введите число");
        Console.ForegroundColor = defautColor;
    }
    static int GetNumber()
    {
        int result;

        while (true)
        {
            Console.Write("Пожалуйста, введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                WriteError();
            }
        }
    }
}

