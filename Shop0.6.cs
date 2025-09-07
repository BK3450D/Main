using System;
using System.Collections.Generic;
using System.Linq;

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

    class User
    {
        private List<Product> _products;

        protected User(int money)
        {
            Money = money;
            _products = new List<Product>();
        }

        public int Money { get; protected set; }

        public int GetProductCount => _products.Count;

        public List<Product> GetProducts()
        {
            return new List<Product>(_products);
        }

        public bool Pay(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }

            return false;
        }

        protected void AddProduct(Product product)
        {
            _products.Add(product);
        }

        protected bool RemoveProduct(Product product)
        {
            return _products.Remove(product);
        }

        protected void ClearProducts()
        {
            _products.Clear();
        }

    }

    class Seller : User
    {
        public Seller(int money) : base(money) { }

        public void CreateProducts()
        {
            ClearProducts();

            List<string> names = new List<string>() { "Книга", "Ручка", "Карандаш", "Тетрадь", "Линейка", "Маркер", "Циркуль" };
            List<int> prices = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random random = new Random();

            foreach (var name in names)
            {
                int randomPrice = prices[random.Next(prices.Count)];
                AddProduct(new Product(name, randomPrice));
            }
        }

        public void ReceiveMoney(int amount)
        {
            Money += amount;
        }

        public bool TryRemoveProduct(Product product)
        {
            return RemoveProduct(product);
        }
    }

    class Buyer : User
    {
        private List<Product> _productBasket = new List<Product>();

        public Buyer(int money) : base(money) { }

        public bool CanPay(int amount)
        {
            return Money >= amount;
        }

        public void ReceiveProduct(Product product)
        {
            _productBasket.Add(product);
        }

        public void ShowProductBasket()
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
        protected const ConsoleKey CommandUpArrow = ConsoleKey.UpArrow;
        protected const ConsoleKey CommandDownArrow = ConsoleKey.DownArrow;
        protected const ConsoleKey CommandEnter = ConsoleKey.Enter;
        protected const ConsoleKey CommandEscape = ConsoleKey.Escape;

        public void Start()
        {
            Seller seller = new Seller(1000);
            seller.CreateProducts();

            Buyer buyer = new Buyer(100);

            Shop shop = new Shop(seller, buyer);

            shop.StartTrading();

        }
        protected void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey(true);
        }

        protected void UpdateSelectedIndex(ConsoleKeyInfo key, ref int selectedIndex, int count)
        {
            if (key.Key == ConsoleKey.UpArrow)
                selectedIndex = (selectedIndex - 1 + count) % count;
            else if (key.Key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex + 1) % count;
        }

        protected void DrawProducts(IReadOnlyList<Product> products, int selectedIndex)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (i == selectedIndex)
                    Console.WriteLine($"=> {products[i]}");
                else
                    Console.WriteLine($"   {products[i]}");
            }
        }
    }

    class Shop : Menu
    {
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

            List<Product> products = _seller.GetProducts();

            while (isWork)
            {
                if (_seller.GetProductCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Товары закончились");
                    Pause();
                    _seller.CreateProducts();
                    selectedIndex = 0;
                    products = _seller.GetProducts();
                }

                Console.Clear();
                Console.WriteLine($"Деньги покупателя: {_buyer.Money}");
                Console.WriteLine($"Деньги продавца: {_seller.Money}");
                Console.WriteLine("Товары:");


                DrawProducts(products, selectedIndex);

                _buyer.ShowProductBasket();

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == CommandEscape)
                {
                    isWork = false;
                }
                else if (key.Key == CommandUpArrow || key.Key == CommandDownArrow)
                {
                    UpdateSelectedIndex(key, ref selectedIndex, products.Count);
                }
                else if (key.Key == CommandEnter)
                {
                    Product productToBuy = products[selectedIndex];
                    bool canBuy = TryBuyProduct(productToBuy);

                    if (canBuy == false)
                    {
                        Pause();
                    }
                    else
                    {

                        products = _seller.GetProducts();
                        if (selectedIndex >= products.Count)
                        {
                            selectedIndex = 0;
                        }
                    }
                }
            }
        }

        public bool TryBuyProduct(Product product)
        {
            if (_seller.GetProducts().Contains(product) == false)
            {
                Console.WriteLine("Товар не найден.");
                return false;
            }

            if (_buyer.CanPay(product.Price) == false)
            {
                Console.WriteLine("Недостаточно средств.");
                return false;
            }

            _buyer.Pay(product.Price);
            _seller.ReceiveMoney(product.Price);

            _seller.TryRemoveProduct(product);
            _buyer.ReceiveProduct(product);

            Console.WriteLine($"Покупка завершена: {product}");
            return true;
        }

    }
}
