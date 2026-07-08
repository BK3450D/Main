using ColiseumGame;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ColiseumGame
{
    public static class UserUtils
    {
        private static readonly Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max + 1);
        }
    }
    public interface IDamageable
    {
        void TakeDamage(int damage);
        int GetCurrentHealth();
        string GetName();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Coliseum coliseum = new Coliseum();
            coliseum.ShowMenu();
        }
    }

    abstract class Fighter : IDamageable
    {
        protected string Name;
        protected int Damage;
        protected int Defense;
        protected int Health;
        protected int MaxHealth;

        public int BattleNumber { get; set; }

        protected Fighter(string name, int damage, int defense, int health)
        {
            Name = name;
            Damage = damage;
            Defense = defense;
            Health = health;
            MaxHealth = health;
        }

        public string GetName()
        {
            if (BattleNumber > 0)
                return $"{Name} #{BattleNumber}";

            return Name;
        }

        public int GetCurrentHealth()
        {
            return Health;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public virtual void Attack(IDamageable target)
        {
            if (IsAlive() == false)
                return;

            int damage = CalculateDamage();

            Console.WriteLine($"{Name} атакует {target.GetName()} и наносит {damage} урона.");

            target.TakeDamage(damage);
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            int damage = Math.Max(0, incomingDamage - Defense);

            Health -= damage;

            if (Health < 0)
                Health = 0;

            Console.WriteLine($"{Name} получает {damage} урона.");
        }

        protected virtual int CalculateDamage()
        {
            return Damage;
        }

        public virtual void ShowStats()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Боец: {GetName()}");
            Console.WriteLine($"Здоровье: {Health}/{MaxHealth}");
            Console.WriteLine($"Урон: {Damage}");
            Console.WriteLine($"Защита: {Defense}");
            Console.WriteLine($"Особенность: {GetAbilityDescription()}");
            Console.WriteLine("--------------------------------");
        }

        protected abstract string GetAbilityDescription();

        public abstract Fighter Clone();
    }

    class LuckyWarrior : Fighter
    {
        private const int CriticalChance = 25;

        public LuckyWarrior() : base("Везунчик", 15, 3, 100) { }

        private LuckyWarrior(string name, int damage, int defense, int health) : base(name, damage, defense, health) { }

        protected override int CalculateDamage()
        {
            int damage = Damage;

            if (UserUtils.GenerateRandomNumber(1, 100) <= CriticalChance)
            {
                Console.WriteLine($"{Name} наносит критический удар!");
                damage *= 2;
            }

            return damage;
        }

        protected override string GetAbilityDescription()
        {
            return "25% шанс на двойной урон";
        }

        public override Fighter Clone()
        {
            return new LuckyWarrior(Name, Damage, Defense, MaxHealth);
        }
    }

    class DoubleStrikeWarrior : Fighter
    {
        private int _attackCounter;

        public DoubleStrikeWarrior()
            : base("Мастер клинков", 13, 4, 110)
        {
        }

        private DoubleStrikeWarrior(string name, int damage, int defense, int health)
            : base(name, damage, defense, health)
        {
        }

        public override void Attack(IDamageable target)
        {
            _attackCounter++;

            base.Attack(target);

            if (_attackCounter % 3 == 0 && target.GetCurrentHealth() > 0)
            {
                Console.WriteLine($"{Name} выполняет вторую атаку!");
                base.Attack(target);
            }
        }

        protected override string GetAbilityDescription()
        {
            return "Каждая третья атака наносится дважды";
        }

        public override Fighter Clone()
        {
            return new DoubleStrikeWarrior(Name, Damage, Defense, MaxHealth);
        }
    }

    class Berserker : Fighter
    {
        private int _rage;

        private const int MaxRage = 50;
        private const int HealAmount = 30;

        public Berserker()
            : base("Берсерк", 14, 2, 120) { }

        private Berserker(string name, int damage, int defense, int health) : base(name, damage, defense, health) { }

        public override void TakeDamage(int incomingDamage)
        {
            int damage = Math.Max(0, incomingDamage - Defense);

            Health -= damage;

            if (Health < 0)
                Health = 0;

            _rage += damage;

            Console.WriteLine($"{Name} получает {damage} урона.");

            if (_rage >= MaxRage && Health > 0)
            {
                _rage = 0;

                Health += HealAmount;

                if (Health > MaxHealth)
                    Health = MaxHealth;

                Console.WriteLine($"{Name} впадает в ярость и восстанавливает здоровье!");
            }
        }

        protected override string GetAbilityDescription()
        {
            return "После накопления ярости восстанавливает здоровье";
        }

        public override Fighter Clone()
        {
            return new Berserker(Name, Damage, Defense, MaxHealth);
        }
    }

    class Mage : Fighter
    {
        private int _mana = 100;

        private const int SpellCost = 25;
        private const int FireballDamage = 30;

        public Mage() : base("Маг", 10, 2, 100) { }

        private Mage(string name, int damage, int defense, int health) : base(name, damage, defense, health) { }

        public override void Attack(IDamageable target)
        {
            if (_mana >= SpellCost)
            {
                _mana -= SpellCost;

                Console.WriteLine($"{Name} использует Огненный шар!");

                target.TakeDamage(FireballDamage);
            }
            else
            {
                base.Attack(target);
            }
        }

        protected override string GetAbilityDescription()
        {
            return "Использует Огненный шар пока есть мана";
        }

        public override Fighter Clone()
        {
            return new Mage(Name, Damage, Defense, MaxHealth);
        }
    }

    class Dodger : Fighter
    {
        private const int DodgeChance = 30;

        public Dodger()
            : base("Ассасин", 12, 2, 95)
        {
        }

        private Dodger(string name, int damage, int defense, int health)
            : base(name, damage, defense, health)
        {
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (UserUtils.GenerateRandomNumber(1, 100) <= DodgeChance)
            {
                Console.WriteLine($"{Name} уклоняется от атаки!");
                return;
            }

            base.TakeDamage(incomingDamage);
        }

        protected override string GetAbilityDescription()
        {
            return "30% шанс полностью избежать урона";
        }

        public override Fighter Clone()
        {
            return new Dodger(Name, Damage, Defense, MaxHealth);
        }
    }

    class Battle
    {
        private const int FirstFighterNumber = 1;
        private const int SecondFighterNumber = 2;

        public void Fight(Fighter firstFighter, Fighter secondFighter)
        {

            firstFighter.BattleNumber = FirstFighterNumber;
            secondFighter.BattleNumber = SecondFighterNumber;

            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("          БОЙ НАЧАЛСЯ             \n");
            Console.WriteLine("====================================");
            Console.WriteLine();

            firstFighter.ShowStats();
            secondFighter.ShowStats();

            Console.WriteLine();
            Console.WriteLine("\nНажмите любую клавишу для начала боя...");
            Console.ReadKey(true);

            int round = 1;

            while (firstFighter.IsAlive() && secondFighter.IsAlive())
            {
                Console.WriteLine();
                Console.WriteLine($"========== Раунд {round} ==========");

                firstFighter.Attack(secondFighter);

                if (secondFighter.IsAlive())
                {
                    secondFighter.Attack(firstFighter);
                }

                Console.WriteLine();

                ShowCurrentHealth(firstFighter, secondFighter);

                if (firstFighter.IsAlive() && secondFighter.IsAlive())
                {
                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу для следующего раунда...");
                    Console.ReadKey(true);
                }

                round++;
            }

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("               КОНЕЦ БОЯ");
            Console.WriteLine("========================================");

            ShowBattleResult(firstFighter, secondFighter);

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey(true);
        }

        private void ShowCurrentHealth(Fighter firstFighter, Fighter secondFighter)
        {
            Console.WriteLine("Текущее состояние бойцов:");

            Console.WriteLine(
                $"{firstFighter.GetName()} - {firstFighter.GetCurrentHealth()} HP");

            Console.WriteLine(
                $"{secondFighter.GetName()} - {secondFighter.GetCurrentHealth()} HP");
        }

        private void ShowBattleResult(Fighter firstFighter, Fighter secondFighter)
        {
            if (firstFighter.IsAlive())
            {
                Console.WriteLine($"🏆 Победил {firstFighter.GetName()}!");
            }
            else if (secondFighter.IsAlive())
            {
                Console.WriteLine($"🏆 Победил {secondFighter.GetName()}!");
            }
            else
            {
                Console.WriteLine("Ничья!");
            }
        }
    }
}

class Coliseum
{
    private readonly List<Fighter> _fighters = new List<Fighter>();

    private const int StartBattleCommand = 0;
    private const int ShowFightersCommand = 1;
    private const int ExitCommand = 2;

    public Coliseum()
    {
        InitializeFighters();
    }

    public void ShowMenu()
    {
        List<string> menuItems = new List<string>()
            {
                "Начать бой",
                "Показать всех бойцов",
                "Выход"
            };

        int selectedIndex = 0;
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("           АРЕНА КОЛИЗЕЯ");
            Console.WriteLine("========================================");
            Console.WriteLine();

            DrawMenu(menuItems, selectedIndex);

            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex--;

                    if (selectedIndex < 0)
                        selectedIndex = menuItems.Count - 1;

                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex++;

                    if (selectedIndex >= menuItems.Count)
                        selectedIndex = 0;

                    break;

                case ConsoleKey.Enter:

                    switch (selectedIndex)
                    {
                        case StartBattleCommand:
                            StartBattle();
                            break;

                        case ShowFightersCommand:
                            ShowAllFighters();
                            break;

                        case ExitCommand:
                            isRunning = false;
                            break;
                    }

                    break;
            }
        }
    }

    private void InitializeFighters()
    {
        _fighters.Add(new LuckyWarrior());
        _fighters.Add(new DoubleStrikeWarrior());
        _fighters.Add(new Berserker());
        _fighters.Add(new Mage());
        _fighters.Add(new Dodger());
    }

    private void StartBattle()
    {
        Fighter firstFighter = SelectFighter("Выберите первого бойца");
        Fighter secondFighter = SelectFighter("Выберите второго бойца");

        Battle battle = new Battle();
        battle.Fight(firstFighter, secondFighter);
    }

    private Fighter SelectFighter(string title)
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine(title);
            Console.WriteLine();

            DrawFighterList(selectedIndex);

            Console.WriteLine();       
            Console.WriteLine("Enter - подтвердить");
            Console.WriteLine("Esc - назад");

            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:

                    selectedIndex--;

                    if (selectedIndex < 0)
                        selectedIndex = _fighters.Count - 1;

                    break;

                case ConsoleKey.DownArrow:

                    selectedIndex++;

                    if (selectedIndex >= _fighters.Count)
                        selectedIndex = 0;

                    break;

                case ConsoleKey.Enter:

                    Fighter fighter = _fighters[selectedIndex].Clone();

                    if (ConfirmSelection(fighter))
                        return fighter;

                    break;

                case ConsoleKey.Escape:

                    return null;
            }
        }
    }

    private bool ConfirmSelection(Fighter fighter)
    {
        while (true)
        {
            Console.Clear();

            fighter.ShowStats();

            Console.WriteLine();
            Console.WriteLine("Enter - начать бой этим бойцом");
            Console.WriteLine("Esc - выбрать другого");

            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            if (pressedKey == ConsoleKey.Enter)
                return true;

            if (pressedKey == ConsoleKey.Escape)
                return false;
        }
    }

    private void DrawMenu(List<string> menuItems, int selectedIndex)
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            if (i == selectedIndex)
                Console.WriteLine($">> {menuItems[i]}");
            else
                Console.WriteLine($"  {menuItems[i]}");
        }
    }

    private void DrawFighterList(int selectedIndex)
    {
        for (int i = 0; i < _fighters.Count; i++)
        {
            if (i == selectedIndex)
                Console.Write(">> ");
            else
                Console.Write("  ");

            Console.WriteLine(_fighters[i].GetName());
        }
    }

    private void ShowAllFighters()
    {
        Console.Clear();

        Console.WriteLine("=========== БОЙЦЫ ===========");
        Console.WriteLine();

        foreach (Fighter fighter in _fighters)
        {
            fighter.ShowStats();
        }

        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу...");
        Console.ReadKey(true);
    }
}
           
    





