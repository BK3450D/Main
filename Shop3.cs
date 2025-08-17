using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
        }
    }

    class User
    {
        protected User(int money)
        {
            Money = money;
        }
        public int Money { get; protected set; }

        public bool Pay(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }

            return false;
        }
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public override string ToString()
        {
            return $"{Name} - {Price}$";
        }
    }

    class Seller : User
    {
        private List<Product> _products = new List<Product>();

        public Seller(int money) : base(money) { }

        public List<Product> GetProducts => _products;

        public int GetCountProducts => _products.Count;

        public void CreateProducts()
        {
            _products.Clear();

            List<string> names = new List<string>() { "Книга", "Ручка", "Карандаш", "Тетрадь", "Линейка", "Маркер", "Циркуль" };
            List<int> prices = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random random = new Random();

            foreach (var name in names)
            {
                int randomPrice = prices[random.Next(prices.Count)];
                _products.Add(new Product(name, randomPrice));
            }
        }

        public bool SellProduct(Product product, Buyer buyer)
        {
            if (_products.Contains(product) && buyer.Pay(product.Price))
            {
                _products.Remove(product);

                buyer.ReceiveProduct(product);

                Money += product.Price;

                return true;
            }

            return false;
        }
    }

    class Buyer : User
    {
        private List<Product> _productBasket = new List<Product>();

        public Buyer(int money) : base(money) { }

        public void ReceiveProduct(Product product)
        {
            _productBasket.Add(product);
        }

        public bool BuyProduct(Product product, Seller seller)
        {
            return seller.SellProduct(product, this);
        }

        public void ShowProducBasket()
        {
            Console.WriteLine("Корзина:");
            foreach (var product in _productBasket)
            {
                Console.WriteLine(product);
            }
        }
    }

    class Menu
    {
        public void Start()
        {
            Seller seller = new Seller(1000);
            seller.CreateProducts();

            Buyer buyer = new Buyer(100);

            Shop shop = new Shop(seller, buyer);

            shop.StartTrading();
        }
    }

    class Shop
    {
        private const ConsoleKey CommandUpArrow = ConsoleKey.UpArrow;
        private const ConsoleKey CommandDownArrow = ConsoleKey.DownArrow;
        private const ConsoleKey CommandEnter = ConsoleKey.Enter;
        private const ConsoleKey CommandEscape = ConsoleKey.Escape;

        private Seller _seller;
        private Buyer _buyer;

        public Shop(Seller seller, Buyer buyer)
        {
            _seller = seller;
            _buyer = buyer;
        }

        public void StartTrading()
        {
            int selectedIndex = 0;

            bool isWork = true;

            while (isWork)
            {
                if (_seller.GetCountProducts == 0)
                {
                    Console.Clear();
                    Pause();
                    _seller.CreateProducts();
                    selectedIndex = 0;
                }

                Console.Clear();
                Console.WriteLine($"Деньги покупателя: {_buyer.Money}");
                Console.WriteLine($"Деньги продовца: {_seller.Money}");
                Console.WriteLine("Товары:");

                var products = _seller.GetProducts;

                var productToBuy = products[selectedIndex];

                DrawProducts(products, selectedIndex);

                _buyer.ShowProducBasket();

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == CommandEscape)
                {
                    isWork = false;
                }


                if (key.Key == CommandUpArrow || key.Key == CommandDownArrow)
                {
                    UpdateSelectedIndex(key, ref selectedIndex, products.Count);
                }
                else if (key.Key == CommandEnter)
                {
                    if (_buyer.BuyProduct(productToBuy, _seller))
                    {
                        Console.WriteLine($"Вы купили: {productToBuy}");

                        products = _seller.GetProducts;
                        selectedIndex = 0;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно денег.");
                        Pause();
                    }
                }
                _buyer.ShowProducBasket();
            }
        }

        private void Pause()
        {
            Console.ReadKey(true);
        }

        private void UpdateSelectedIndex(ConsoleKeyInfo key, ref int selectedIndex, int count)
        {
            if (key.Key == ConsoleKey.UpArrow)
                selectedIndex = (selectedIndex - 1 + count) % count;
            else if (key.Key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex + 1) % count;
        }

        private void DrawProducts(List<Product> products, int selectedIndex)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (i == selectedIndex)
                    Console.WriteLine($"=>{products[i]}");
                else
                    Console.WriteLine($" {products[i]}");
            }
        }
    }
}
