using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество картинок? ");
            int imagesAmount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Количество картинок в строке? ");
            int picturesInRow = Convert.ToInt32(Console.ReadLine());

            int fullRows;
            int imagesInLastRow;

            fullRows = imagesAmount / picturesInRow;
            imagesInLastRow = fullRows % picturesInRow;

            Console.WriteLine("Строк картинок: " + fullRows);
            Console.WriteLine("Картинок не вместилось: " + imagesInLastRow);

        }
    }
}