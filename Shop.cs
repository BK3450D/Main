using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Work();
        }


        class Product
        {
            public string Name { get; set; }
            public string Price { get; set; }

            public Product(string name, string price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Name} - {Price}$";
            }
        }
        class Shop
        {
            private List<Product> _products = new List<Product>();

            public void Create()
            {
                _products.Clear();

                List<string> names = new List<string>() { "Книга", "Ручка", "Карандаш", "Тетрадь", "Линейка", "Маркер", "Циркуль" };
                List<string> prices = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                Random random = new Random();

                foreach (var name in names)
                {
                    string randomPrice = prices[random.Next(prices.Count)];
                    _products.Add(new Product(name, randomPrice));
                }
            }

            public List<Product> GetProducts()
            {
                return new List<Product>(_products);
            }

            public void RemoveProduct(Product product)
            {
                _products.Remove(product);
            }
        }

        abstract class User
        {
            public int Money { get; protected set; }

            public User(int money)
            {
                Money = money;
            }
            public virtual bool CanBay(int price)
            {
                return Money >= price;
            }
            public virtual bool Bay(int amount)
            {
                if (Money >= amount)
                {
                    Money -= amount;
                    return true;
                }
                return false;
            }
        }
        class Buyer : User
        {
            public List<Product> ProductBasket { get; private set; } = new List<Product>();

            public Buyer(int wallet) : base(wallet) { }

            public bool CanBuyProduct(Product product)
            {
                if (int.TryParse(product.Price, out int price))
                    return CanBay(price);

                return false;
            }

            public bool Pay(Product product)
            {
                if (int.TryParse(product.Price, out int price))
                {
                    if (Bay(price))
                    {
                        ProductBasket.Add(product);
                        return true;
                    }
                }

                return false;
            }

            public void ShowProductBasket()
            {
                Console.WriteLine("\nВаш товар: ");
                if (ProductBasket.Count == 0)
                    Console.WriteLine("Корзина пуста.");
                else
                {
                    int total = 0;
                    for (int i = 0; i < ProductBasket.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ProductBasket[i]}");
                        if (int.TryParse(ProductBasket[i].Price, out int price))
                            total += price;
                    }
                    Console.Write($"Общая стоимость : {total}$");
                }
            }
            public void ShowProductBasketWithPause()
            {
                ShowProductBasket();
                Console.WriteLine();
            }
        }

        class Seller : User
        {
            private Shop _shop;

            public Seller(Shop shop) : base(300)
            {
                _shop = shop;
            }
         
            public bool SellProduct(Product product, Buyer buyer)
            {
                if (!buyer.CanBuyProduct(product))
                {
                    Console.WriteLine("Недостаточно денег.");
                    return false;
                }

                if (buyer.Pay(product))
                {
                    if (int.TryParse(product.Price, out int price))
                    {
                        Money += price;
                        _shop.RemoveProduct(product);
                        Console.WriteLine($"Куплен товар {product.Name} за {price}$");
                        return true;
                    }
                }
                return false;
            }

            public List<Product> GetAvailableProducts()
            {
                return _shop.GetProducts();
            }

            public void RestockProducts()
            {
                _shop.Create();
            }
        }
     
        class Menu
        {
            private void Pause()
            {
                Console.ReadKey(true);
            }

            private static void DrawProducts(List<Product> products, int selectedIndex)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (i == selectedIndex)
                        Console.WriteLine($"=> {products[i]}");
                    else
                        Console.WriteLine($" {products[i]}");
                }
            }

            private static void UpdateSelectedIndex(ConsoleKeyInfo key, ref int selectedIndex, int count)
            {
                if (key.Key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex - 1 + count) % count;
                else if (key.Key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % count;
            }

            public void Work()
            {
                Shop shop = new Shop();
                shop.Create();

                Seller seller = new Seller(shop);
                Buyer buyer = new Buyer(100);

                int selectedIndex = 0;

                bool isWork = true;

                while (isWork)
                {
                    if (seller.GetAvailableProducts().Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Загрузка новых товаров...");
                        Pause();
                        seller.RestockProducts();
                        selectedIndex = 0;
                    }

                    Console.Clear();
                    Console.WriteLine($"Деньги покупателя: {buyer.Money}$");
                    Console.WriteLine($"Деньги в кассе: {seller.Money}$\n");

                    var products = seller.GetAvailableProducts();
                    DrawProducts(products, selectedIndex);

                    buyer.ShowProductBasketWithPause();

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                        isWork = false;

                    if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                        UpdateSelectedIndex(key, ref selectedIndex, products.Count);
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        var selectedProduct = products[selectedIndex];

                        if (seller.SellProduct(selectedProduct, buyer))
                            Pause();
                        else
                            Pause();
                    }
                }
                buyer.ShowProductBasketWithPause();
            }
        }
    }
}
