﻿using System;
using System.Collections.Generic;

namespace SimpleCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;

            Dealer dealer = new Dealer();
            Player player = new Player();

            int maxCard = dealer.GetCountCards();

            if (TryGetNumbers(maxCard, out input))
            {
                dealer.DealCards(player, input);
                player.ShowHand();
            }
        }

        static private bool TryGetNumbers(int maxCard, out int number)
        {
            int minCard = 1;

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
        private List<string> _suits;
        private List<string> _ranks;

        public Deck()
        {
            _suits = new List<string>() { "Hearts", "Diamonds", "Spades", "Clubs" };
            _ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            Create();
            Shuffle();
        }

        private void Create()
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

        public int GetCountCards()
        {
            return _cards.Count;
        }

        public Card GiveCard()
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
        private List<Card> _hand;
        public Player()
        {
            _hand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _hand.Add(card);
        }

        public void ShowHand()
        {
            Console.WriteLine("Ваши карты: ");

            foreach (var card in _hand)
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
                Card card = Deck.GiveCard();
                player.AddCard(card);
            }
        }

        public int GetCountCards()
        {
            return Deck.GetCountCards();
        }
    }
}
