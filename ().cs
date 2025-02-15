using System;

class Program
{
    static void Main()
    {
        char leftBracket = '(';
        char rightBracket = ')';

        int depth = 0;
        int maxDepth = 0;

        bool isValid = true;

        Console.Write($"Введите {leftBracket}  {rightBracket} для пороверки: ");

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            char currentSymbol = input[i];

            if (currentSymbol == leftBracket)
            {
                depth++;

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }
            else if (currentSymbol == rightBracket)
            {
                depth--;

                if (depth < 0)
                {
                    isValid = false;
                    break;
                }
            }
        }

        if (depth != 0)
        {
            isValid = false;
        }

        if (isValid)
        {
            Console.WriteLine("Строка является корректным скобочным выражением.");
            Console.WriteLine($"Максимальная глубина: {maxDepth}");
        }
        else
        {
            Console.WriteLine("Не является корректным скобочным выражением.");
        }
    }
}
