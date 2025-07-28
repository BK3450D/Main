using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace SimpleCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;

            bool isWork = true;

            Dealer dealer = new Dealer();
            Player player = new Player();

            while (isWork)
            {
                if (TryGetNumbers(out input))
                {
                    dealer.DealCards(player, input);

                    player.ShowHand();
                }
            }
        }

        static bool TryGetNumbers(out int number)
        {
            int minCard = 1;
            int maxCard = 52;

            Console.Write($"Введите количество карт для раздачи от {minCard} до {maxCard}: ");
            string input = Console.ReadLine();


            if (int.TryParse(input, out number))
            {
                if (number < minCard || number > maxCard)
                {
                    Console.WriteLine($"Ошибка: Уровень карт должго быть от {minCard} до {maxCard}.");
                    return false;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Введите число");
                return false;
            }
        }
    }
    class Card
    {
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string Suit { get; private set; }
        public string Rank { get; private set; }

        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }
    }

    class Deck
    {
        private List<Card> _cards;

        private static string[] _suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
        private static string[] _ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public Deck()
        {
            Create();
            Shuffle();
        }

        public void Create()
        {
            _cards = new List<Card>();

            foreach (var suit in _suits)
            {
                foreach (var rank in _ranks)
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }

        public Card DealCard()
        {
            if (_cards.Count == 0)
                return null;

            Card card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            Random random = new Random();

            int minRandom = 0;
            int maxRandom = _cards.Count - 1;

            for (int i = 0; i < _cards.Count; i++)
            {
                int randomIndex = random.Next(minRandom, maxRandom + 1);

                Card temp = _cards[i];
                _cards[i] = _cards[randomIndex];
                _cards[randomIndex] = temp;
            }
        }
    }

    class Player
    {
        public Player()
        {
            Hand = new List<Card>();
        }
        private List<Card> Hand { get; set; }

        public void ReceiveCard(Card card)
        {
            Hand.Add(card);
        }

        public void ShowHand()
        {
            Console.WriteLine("Ваши карты: ");

            foreach (var card in Hand)
            {
                Console.WriteLine(card);
            }
        }
    }

    class Dealer
    {

        public Dealer()
        {
            Deck = new Deck();
        }
        private Deck Deck { get; set; }

        public void DealCards(Player player, int numberCards)
        {
            for (int i = 0; i < numberCards; i++)
            {
                Card card = Deck.DealCard();
                player.ReceiveCard(card);
            }
        }
    }
}
