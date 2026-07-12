using System;
using System.Collections.Generic;

namespace ColiseumGame
{
    public static class UserUtils
    {
        public const int MinimumPercent = 1;
        public const int MaximumPercent = 100;

        private static readonly Random s_random = new Random();

        public static bool RollChance(int chance)
        {
            return GenerateRandomNumber(MinimumPercent, MaximumPercent) <= chance;
        }

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
            coliseum.Run();
        }
    }

    abstract class Fighter : IDamageable
    {
        private const int DamageSpreadPercent = 20;

        protected string Name;
        protected int Damage;
        protected int Defense;
        protected int Health;
        protected int MaxHealth;

        public int BattleNumber { get; private set; }

        public bool IsAlive() => Health > 0;

        public int GetCurrentHealth() => Health;

        public void SetBattleNumber(int number) => BattleNumber = number;

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
                return $"{Name} №{BattleNumber}";

            return Name;
        }  

        public virtual void Attack(IDamageable target)
        {
            if (IsAlive() == false)
                return;

            int damage = CalculateDamage();

            Console.WriteLine($"{GetName()} атакует {target.GetName()} и наносит {damage} урона.");

            target.TakeDamage(damage);
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            int damage = Math.Max(0, incomingDamage - Defense);

            Health -= damage;

            if (Health < 0)
                Health = 0;

            Console.WriteLine($"{GetName()} получает {damage} урона.");
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

        public abstract Fighter Clone();

        protected virtual int CalculateDamage()
        {
            int minimumDamage = Damage * (UserUtils.MaximumPercent - DamageSpreadPercent) / UserUtils.MaximumPercent;
            int maximumDamage = Damage * (UserUtils.MaximumPercent + DamageSpreadPercent) / UserUtils.MaximumPercent;

            return UserUtils.GenerateRandomNumber(minimumDamage, maximumDamage);
        }

        protected abstract string GetAbilityDescription();

    }

    class LuckyWarrior : Fighter
    {
    
        private const int CriticalChance = 25;
        private const int CriticalDamageMultiplier = 2;

        public LuckyWarrior() : base("Везунчик", 15, 3, 100) { }

        private LuckyWarrior(string name, int damage, int defense, int health) : base(name, damage, defense, health) { }

        public override Fighter Clone()
        {
            return new LuckyWarrior(Name, Damage, Defense, MaxHealth);
        }

        protected override int CalculateDamage()
        {
            int damage = base.CalculateDamage();

            if (UserUtils.RollChance(CriticalChance))
            {
                Console.WriteLine($"{GetName()} наносит критический удар!");
                damage *= CriticalDamageMultiplier;
            }

            return damage;
        }

        protected override string GetAbilityDescription()
        {
            return $"{CriticalChance}% шанс нанести урон x{CriticalDamageMultiplier}";
        }
    }

    class DoubleStrikeWarrior : Fighter
    {
        private const int AdditionalAttacks = 2;
        private const int AttackBeforeDoubleStrike = 3;

        private int _attackCounter = 0;

        public DoubleStrikeWarrior()
            : base("Мастер клинков", 13, 4, 110) {}

        private DoubleStrikeWarrior(string name, int damage, int defense, int health) : base(name, damage, defense, health){}

        public override void Attack(IDamageable target)
        {
            _attackCounter++;

            base.Attack(target);

            if (_attackCounter % AttackBeforeDoubleStrike == 0)
            {
                for (int attack = 0; attack < AdditionalAttacks - 1; attack++)
                {
                    Console.WriteLine($"{GetName()} выполняет дополнительную атаку!");
                    base.Attack(target);
                }
            }
        }

        protected override string GetAbilityDescription()
        {
            return $"Каждая {AttackBeforeDoubleStrike} атака наносится {AdditionalAttacks} раза";
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
            int previousHealth = Health;

            base.TakeDamage(incomingDamage);

            int damageTaken = previousHealth - Health;

            _rage += damageTaken;

            if (_rage >= MaxRage && Health > 0)
            {
                _rage = 0;

                Health = Math.Min(Health + HealAmount, MaxHealth);

                Console.WriteLine($"{GetName()} впадает в ярость и восстанавливает здоровье!");
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
        private const int MaxMana = 100;

        private int _mana = MaxMana;

        private const int SpellCost = 25;

        private const int FireballBonusDamage = 20;

        public Mage() : base("Маг", 10, 2, 100) { }

        private Mage(string name, int damage, int defense, int health) : base(name, damage, defense, health) { }

        public override void Attack(IDamageable target)
        {
            if (_mana >= SpellCost)
            {
                _mana -= SpellCost;

                Console.WriteLine($"{GetName()} использует Огненный шар!");

                int damage = CalculateDamage() + FireballBonusDamage;
                target.TakeDamage(damage);
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

        private Dodger(string name, int damage, int defense, int health) : base(name, damage, defense, health){ }

        public override void TakeDamage(int incomingDamage)
        {
            if (UserUtils.RollChance(DodgeChance))
            {
                Console.WriteLine($"{GetName()} уклоняется от атаки!");
                return;
            }

            base.TakeDamage(incomingDamage);
        }

        protected override string GetAbilityDescription()
        {
            return $"{DodgeChance}% шанс полностью избежать урона";

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
            firstFighter.SetBattleNumber(FirstFighterNumber);
            secondFighter.SetBattleNumber(SecondFighterNumber);

            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("          БОЙ НАЧАЛСЯ               ");
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

        private Fighter GetWinner(Fighter first, Fighter second)
        {
            if (first.IsAlive())
                return first;

            if (second.IsAlive())
                return second;

            return null;
        }

        private void ShowBattleResult(Fighter firstFighter, Fighter secondFighter)
        {
            Fighter winner = GetWinner(firstFighter, secondFighter);

            if (winner == null)
                Console.WriteLine("Ничья!");
            else
                Console.WriteLine($"Победил {winner.GetName()}!");
        }
    }

    class Coliseum
    {
        private const ConsoleKey ConfirmKey = ConsoleKey.Enter;
        private const ConsoleKey MoveUpKey = ConsoleKey.UpArrow;
        private const ConsoleKey MoveDownKey = ConsoleKey.DownArrow;
        private const ConsoleKey CancelKey = ConsoleKey.Escape;

        private const int StartBattleCommand = 0;
        private const int ShowFightersCommand = 1;
        private const int ExitCommand = 2;

        private bool _isRunning = true;

        private readonly List<Fighter> _fighters = new List<Fighter>();

        public Coliseum()
        {
            InitializeFighters();
        }

        private int MoveUp(int index, int count)
        {
            return (index - 1 + count) % count;
        }

        private int MoveDown(int index, int count)
        {
            return (index + 1) % count;
        }


        private void ExecuteMenuCommand(int selectedMenuItem)
        {
            switch (selectedMenuItem)
            {
                case StartBattleCommand:
                    StartBattle();
                    break;

                case ShowFightersCommand:
                    ShowAllFighters();
                    break;

                case ExitCommand:
                    _isRunning = false;
                    break;
            }
        }
        public void Run()
        {
            List<string> menuItems = new List<string>() { "Начать бой", "Показать всех бойцов", "Выход" };


            int selectedIndex = 0;

            while (_isRunning)
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
                    case MoveUpKey:
                        selectedIndex = MoveUp(selectedIndex, menuItems.Count);
                        break;

                    case MoveDownKey:
                        selectedIndex = MoveDown(selectedIndex, menuItems.Count);
                        break;

                    case ConfirmKey:
                        ExecuteMenuCommand(selectedIndex);
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

            if (firstFighter == null)
                return;

            Fighter secondFighter = SelectFighter("Выберите второго бойца");

            if (secondFighter == null)
                return;

            Battle battle = new Battle();
            battle.Fight(firstFighter, secondFighter);
        }

        private Fighter SelectFighter(string title)
        {
            int selectedIndex = 0;
            bool isSelecting = true;

            Fighter selectedFighter = null;

            while (isSelecting)
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
                    case MoveUpKey:
                        selectedIndex = MoveUp(selectedIndex, _fighters.Count);
                        break;

                    case MoveDownKey:
                        selectedIndex = MoveDown(selectedIndex, _fighters.Count);
                        break;

                    case ConfirmKey:
                        selectedFighter = SelectCurrentFighter(selectedIndex);

                        if (selectedFighter != null)
                            isSelecting = false;
                        break;

                    case CancelKey:

                        return null;
                }
            }
            return selectedFighter;
        }

        private Fighter SelectCurrentFighter(int selectedIndex)
        {
            Fighter fighter = _fighters[selectedIndex].Clone();

            if (ConfirmSelection(fighter))
                return fighter;

            return null;
        }

        private bool ConfirmSelection(Fighter fighter)
        {
            bool isWaitingConfirmation = true;
            bool isConfirmed = false;

            while (isWaitingConfirmation)
            {
                Console.Clear();

                fighter.ShowStats();

                Console.WriteLine();
                Console.WriteLine("Enter - начать бой этим бойцом");
                Console.WriteLine("Esc - выбрать другого");

                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConfirmKey:
                        isConfirmed = true;
                        isWaitingConfirmation = false;
                        break;

                    case CancelKey:
                        isWaitingConfirmation = false;
                        break;
                }
            }

            return isConfirmed;
        }

        private void DrawMenu(IReadOnlyList<string> menuItems, int selectedIndex)
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
}







