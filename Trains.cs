using System;
using System.Collections.Generic;

namespace TrainDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();

                dispatcher.ShowShortInfo();

                Console.WriteLine();
                Console.WriteLine("1 - Создать поезд");
                Console.WriteLine("2 - Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        dispatcher.CreateTrain();
                        break;

                    case "2":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Dispatcher
    {
        private List<Train> _trains = new List<Train>();
        private List<string> _cities = new List<string>()
        {
            "Бийск",
            "Барнаул",
            "Новосибирск",
            "Омск",
            "Томск",
            "Красноярск",
            "Кемерово",
            "Москва",
            "Казань",
            "Санкт-Петербург"
        };

        private Random _random = new Random();

        public void CreateTrain()
        {
            Console.Clear();

            Direction direction = CreateDirection();

            int passengers = SellTickets();

            Train train = FormTrain(direction, passengers);

            _trains.Add(train);

            Console.WriteLine();
            train.ShowFullInfo();

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        private Direction CreateDirection()
        {
            List<Direction> directions = new List<Direction>();


            while (directions.Count < 5)
            {
                int departureIndex = _random.Next(_cities.Count);

                int destinationIndex = _random.Next(_cities.Count);

                while (departureIndex == destinationIndex)
                {
                    destinationIndex = _random.Next(_cities.Count);
                }

                Direction newDirection = new Direction(
                    _cities[departureIndex],
                    _cities[destinationIndex]);

                bool directionExists = false;

                foreach (Direction direction in directions)
                {
                    if (direction.Departure == newDirection.Departure &&
                        direction.Destination == newDirection.Destination)
                    {
                        directionExists = true;
                        break;
                    }
                }

                if (directionExists == false)
                {
                    directions.Add(newDirection);
                }
            }

            Console.WriteLine("Доступные направления:\n");

            for (int i = 0; i < directions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {directions[i].Departure} - {directions[i].Destination}");
            }

            int choice;

            Console.Write("\nВыберите направление: ");

            while (int.TryParse(Console.ReadLine(), out choice) == false ||
                   choice < 1 ||
                   choice > directions.Count)
            {
                Console.Write("Ошибка! Повторите ввод: ");
            }

            int selectedIndex = choice - 1;
            return directions[selectedIndex];
        }

        private int SellTickets()
        {
            int minRandomPassengers = 30;
            int maxRandomPassengers = 300;

            int passengers = _random.Next(minRandomPassengers, maxRandomPassengers);

            Console.WriteLine($"\nПродано билетов: {passengers}");

            return passengers;
        }

        private Train FormTrain(Direction direction, int passengers)
        {
            const int capacity = 50;

            Train train = new Train(direction, passengers);

            int carriageCount = (int)Math.Ceiling((double)passengers / capacity);

            for (int i = 0; i < carriageCount; i++)
            {
                train.AddCarriage(new Carriage(capacity));
            }

            return train;
        }

        public void ShowShortInfo()
        {
            Console.WriteLine("Созданные поезда:\n");

            if (_trains.Count == 0)
            {
                Console.WriteLine("Поездов пока нет.");
                return;
            }

            for (int i = 0; i < _trains.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _trains[i].ShowShortInfo();
            }
        }
    }

    class Direction
    {
        public string Departure { get; }
        public string Destination { get; }

        public Direction(string departure, string destination)
        {
            Departure = departure;
            Destination = destination;
        }
    }

    class Train
    {
        private List<Carriage> _carriages = new List<Carriage>();

        public Direction Direction { get; }
        public int Passengers { get; }

        public Train(Direction direction, int passengers)
        {
            Direction = direction;
            Passengers = passengers;
        }

        public void AddCarriage(Carriage carriage)
        {
            _carriages.Add(carriage);
        }

        public void ShowShortInfo()
        {
            Console.WriteLine($"{Direction.Departure} - {Direction.Destination} | Пассажиров: {Passengers} | Вагонов: {_carriages.Count}");
        }

        public void ShowFullInfo()
        {
            Console.WriteLine("Информация о поезде");
            Console.WriteLine($"Маршрут: {Direction.Departure} - {Direction.Destination}");
            Console.WriteLine($"Пассажиров: {Passengers}");
            Console.WriteLine($"Количество вагонов: {_carriages.Count}");

            for (int i = 0; i < _carriages.Count; i++)
            {
                Console.WriteLine($"Вагон {i + 1}. Вместимость {_carriages[i].Capacity}");
            }
        }
    }

    class Carriage
    {
        public int Capacity { get; }

        public Carriage(int capacity)
        {
            Capacity = capacity;
        }
    }
}