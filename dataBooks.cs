using ConsoleApp8;
using System;
using System.Collections.Generic;


namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Database dataBase = new Database();
            DatabaseView menu = new DatabaseView();
            menu.Work();
        }
    }

    class Book
    {
        private int _releaseDate;
        private string _name;
        private string _author;

        public Book(int releaseDate, string name, string author)
        {
            _releaseDate = releaseDate;
            _name = name;
            _author = author;
        }

        public string GetInfo()
        {
            return $"Название : {_name} | Автор: {_author} | Дата выхода: {_releaseDate} |  ";
        }

        public bool SearchName(string name)
        {
            return _name.Contains(name);
        }

        public bool SearchAuthor(string author)
        {
            return _author.Contains(author);
        }

        public bool SearchReleaseDate(int releaseDate)
        {
            return _releaseDate == releaseDate;
        }
    }

    class Database
    {
        public Dictionary<int, Book> books = new Dictionary<int, Book>();

        public bool IsEmpty => books.Count == 0;

        public void AddBook(int releseDate, string name, string author)
        {
            Book book = new Book(releseDate, name, author);
            books.Add(releseDate, book);
            Console.WriteLine($"Книга добавлена: {name} {author} {releseDate}");

        }

        public int RemoveByName(string name)
        {
            List<int> keysToRemove = new List<int>();

            foreach (var pair in books)
            {
                if (pair.Value.SearchName(name))
                    keysToRemove.Add(pair.Key);
            }

            foreach (int key in keysToRemove)
                books.Remove(key);

            return keysToRemove.Count;
        }

        public void ShowAllBooks()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Книг нет.");
                return;
            }

            foreach (var books in books.Values)
            {
                Console.Write(books.GetInfo());
            }
        }
    }

    class DatabaseView
    {
        private Database _database = new Database();

        public void Work()
        {
            const int CommandAddBook = 0;
            const int CommandShowBooks = 1;
            const int CommandFindBook = 2;
            const int CommandDeleteBook = 3;
            const int CommandExit = 4;

            ConsoleKey reghtMoveCommand = ConsoleKey.RightArrow;
            ConsoleKey EnterCommand = ConsoleKey.Enter;

            List<string> menuItems = new List<string>()
        {
            "Добавить книгу",
            "Показать все книги",
            "Поиск книг",
            "Убрать книги",
            "Выход"
        };

            bool isRun = true;
            int selectedIndex = 0;

            while (isRun)
            {
                Console.Clear();
                DrawLine(menuItems, selectedIndex);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                GetPressKey(pressedKey, ref selectedIndex, menuItems);

                if (pressedKey.Key == reghtMoveCommand || pressedKey.Key == EnterCommand)
                {
                    Console.Clear();

                    switch (selectedIndex)
                    {
                        case CommandAddBook:
                            RequestData();
                            break;
                        case CommandShowBooks:
                            _database.ShowAllBooks();
                            break;
                        case CommandFindBook:
                            FindBook();
                            break;
                        case CommandDeleteBook:

                            break;
                        case CommandExit:
                            isRun = false;
                            break;
                    }

                    Pause();
                }
            }
        }


        private void FindBook()
        {
            const int CommandFindForName = 0;
            const int CommandFindForDataRelease = 1;
            const int CommandFindforAuthor = 3;
            const int CommandExit = 4;

            int selectedIndex = 0;
            bool isRun = true;

            ConsoleKey reghtMoveCommand = ConsoleKey.RightArrow;
            ConsoleKey EnterCommand = ConsoleKey.Enter;

            List<string> menuItems = new List<string>()
        {
            "Поиск по названию",
            "Поиск по дате выхода",
            "Поиск по автору",
            };

            while (isRun)
            {
                Console.Clear();
                DrawLine(menuItems, selectedIndex);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                GetPressKey(pressedKey, ref selectedIndex, menuItems);

                if (pressedKey.Key == reghtMoveCommand || pressedKey.Key == EnterCommand)
                {
                    switch (selectedIndex)
                    {
                        case CommandFindForName:

                            break;
                        case CommandFindForDataRelease:

                            break;
                        case CommandFindforAuthor:

                            break;
                        case CommandExit:
                            isRun = false;
                            break;
                    }

                    Pause();
                }
            }
        }

        private static void GetPressKey(ConsoleKeyInfo pressedKey, ref int selectedIndex, List<string> menuItems)
        {
            ConsoleKey upMoveCommand = ConsoleKey.UpArrow;
            ConsoleKey downMoveCommand = ConsoleKey.DownArrow;

            if (pressedKey.Key == upMoveCommand)
            {
                selectedIndex = (selectedIndex - 1 + menuItems.Count) % menuItems.Count;
            }
            else if (pressedKey.Key == downMoveCommand)
            {
                selectedIndex = (selectedIndex + 1) % menuItems.Count;
            }
        }

        private static void DrawLine(List<string> menuItems, int selectedIndex)
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedIndex)
                    Console.WriteLine($"=> {menuItems[i]}");
                else
                    Console.WriteLine($" {menuItems[i]}");
            }
        }

        private void RequestData()
        {
            const int minReleaseDate = 1;
            const int maxReleaseDate = 2099;

            Console.Write("Введите название  книги: ");
            string bookName = Console.ReadLine();

            Console.Write("Введите автора книги: ");
            string bookAuthor = Console.ReadLine();

            Console.Write("Введите дату выхода: ");
            string releaseDate = Console.ReadLine();



            if (int.TryParse(releaseDate, out int date))
            {
                if (date < minReleaseDate || date > maxReleaseDate)
                {
                    Console.WriteLine($"Ошибка: дата должна быть от {minReleaseDate} до {maxReleaseDate}.");
                    return;
                }

                _database.AddBook(date, bookName, bookAuthor);
            }
        }

        private void RemoveBook()
        {
            if (_database.IsEmpty)
            {
                Console.WriteLine("Хранилище пусто.");
                return;
            }

            const int RemoveByDate = 0;
            const int RemoveByName = 1;
            const int Exit = 2;

            List<string> removeOptions = new List<string>()
    {
        "Удалить по дате выхода",
        "Удалить по названию",
        "Назад"
    };

            int selectedIndex = 0;
            bool isRun = true;

            while (isRun)
            {
                Console.Clear();
                DrawLine(removeOptions, selectedIndex);
                ConsoleKeyInfo key = Console.ReadKey();
                GetPressKey(key, ref selectedIndex, removeOptions);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    switch (selectedIndex)
                    {

                        case RemoveByName:
                            Console.Write("Введите часть названия книги: ");
                            string name = Console.ReadLine();
                            int removedCount = _database.RemoveByName(name);

                            if (removedCount > 0)
                                Console.WriteLine($"Удалено книг: {removedCount}");
                            else
                                Console.WriteLine("Книги с таким названием не найдены.");
                            break;

                        case Exit:
                            isRun = false;
                            break;
                    }

                    Pause();
                }
            }
        }

        private void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
    }
}




