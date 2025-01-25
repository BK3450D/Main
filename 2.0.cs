using System;

namespace ConsoleApp27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandBasicAttack = "1";
            const string CommandNFireBall = "2";
            const string CommandFieryExplosion = "3";
            const string CommandRestorationPotion = "4";

            int maxRandomDamagePlayer = 25;
            int minRandomDamagePlayer = 15;

            int maxFireballDamagePlayer = 50;
            int minFireballDamagePlayer = 30;

            int maxDamegeExplosionDamage = 70;
            int minDamgeExplosionDamage = 50;

            int maxRandomDamageBoss = 20;
            int minRandomDamageBoss = 15;

            int healingAmount = 50;
            int healingManaAmount = 25;

            int manaCostFierExeplosion = 25;
            int manaCostFierBall = 25;

            int playerHealth = 100;
            int bossHealth = 300;
            int playerMana = 50;
            int maxPlayerHealth = 100;
            int maxPlayerMana = 50;
            int healingUses = 5;

            bool isFireballUsed = false;

            Random random = new Random();

            Console.WriteLine("Бой с Боссом начался!");

            while (playerHealth > 0 && bossHealth > 0)
            {
                int bossAttack = random.Next(minRandomDamageBoss, maxRandomDamageBoss + 1);
                playerHealth -= bossAttack;

                Console.WriteLine($"Аттака босса. Вы получили {bossAttack} урона. У вас осталось: {playerHealth} здоровья и {playerMana} маны");

                Console.WriteLine($"Выберите действие:");
                Console.WriteLine($"{CommandBasicAttack} - Обычная атака от {minRandomDamagePlayer} до {maxRandomDamagePlayer} урона.");
                Console.WriteLine($"{CommandNFireBall}  - Огненный шар от {minFireballDamagePlayer} до {maxFireballDamagePlayer} урона. ");
                Console.WriteLine($"{CommandFieryExplosion} - Огненный взрыв от {minDamgeExplosionDamage} до {maxDamegeExplosionDamage} (Сначала используйте Огненный шар) ");
                Console.WriteLine($"{CommandRestorationPotion} - Лечение. {healingUses} Зарядов. востанавливает {healingAmount} здоровье и {healingManaAmount} маны ");

                string playerСoice = Console.ReadLine();

                switch (playerСoice)
                {
                    case CommandBasicAttack:

                        int normalAttackDamage = random.Next(minRandomDamagePlayer, maxRandomDamagePlayer + 1);

                        bossHealth -= normalAttackDamage;

                        Console.WriteLine($"Игрок атакует! Босс получает {normalAttackDamage} урона. У босса осталось здоровья: {bossHealth}");
                        break;

                    case CommandNFireBall:
                        if (playerMana >= manaCostFierBall)
                        {
                            playerMana -= manaCostFierBall;

                            int fireballDamage = random.Next(minFireballDamagePlayer, maxFireballDamagePlayer + 1);

                            bossHealth -= fireballDamage;

                            isFireballUsed = true;

                            Console.WriteLine($"Игрок использует Огненный шар! Босс получает {fireballDamage} урона. У босса осталось здоровья: {bossHealth}");
                            Console.WriteLine("Вы можите использовать Огненный взрыв.");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно маны для использования Огненного шара!");
                        }
                        break;

                    case CommandFieryExplosion:
                        if (isFireballUsed && playerMana >= manaCostFierExeplosion)
                        {
                            playerMana -= manaCostFierExeplosion;

                            int explosionDamage = random.Next(minDamgeExplosionDamage, maxDamegeExplosionDamage + 1);
                            bossHealth -= explosionDamage;
                            isFireballUsed = false;
                            Console.WriteLine($"Игрок использует Взрыв! Босс получает {explosionDamage} урона. У босса осталось здоровья: {bossHealth}");
                        }
                        else if (playerMana <= manaCostFierExeplosion)
                        { 
                            Console.WriteLine("Недостаточно маны!"); 
                        }
                        else
                        {
                            Console.WriteLine("Сначала используйте Огненный шар, чтобы вызвать Огненный взрыв!");
                        }
                        break;

                    case CommandRestorationPotion:
                        if (healingUses > 0)
                        {
                            playerHealth = playerHealth + healingAmount;
                            playerMana = playerMana + healingManaAmount;

                            healingUses--;

                            if (playerHealth >= maxPlayerHealth && playerMana >= maxPlayerMana)
                            {
                                playerHealth = maxPlayerHealth;
                                playerMana = maxPlayerMana;
                            }
                            Console.WriteLine($"Игрок использует Лечение. Восстановлено {healingAmount} здоровья и {healingManaAmount} маны. У игрока осталось здоровья: {playerHealth} и маны: {playerMana}. Зарядов: {healingUses}");
                        }
                        else
                        {
                            Console.WriteLine("Вы исчерпали все заряды лечения!");
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный ввод. Пропуск хода.");
                        break;
                }
     
            }

            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Ничья! Оба были повержены!");
            }

            if (bossHealth <= 0)
             {
                 Console.WriteLine("Босс повержен! Вы победили!");    
             }
 
             if (playerHealth <= 0)
             {
                    Console.WriteLine("Вы проиграли.");
             }
        }
    }
}
