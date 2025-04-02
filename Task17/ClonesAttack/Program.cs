using ClonesAttack.Classes;

namespace ClonesAttack
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Тестирование клонирования ===");

            // Создаем прототипы
            var warriorPrototype = new Player("Рандом", 1, 100, 50, "Паладин")
            {
                Stats = { ["Сила"] = 10, ["Ловкость"] = 5, ["Интеллект"] = 3 },
                Skills = { "Молот правосудия", "Освящение", "Божественный щит" },
                Experience = 0
            };

            var wolfPrototype = new NPC("Карома", 13, 45, 0, true)
            {
                Stats = { ["Сила"] = 7, ["Ловкость"] = 9, ["Интеллект"] = 1 },
                LootList = { "Кристальная слеза верности" }
            };

            var healthPotionPrototype = new Item("Зелье здоровья", "Общее", true)
            {
                Stats = { ["Уровень восстановления здоровья"] = 30 }
            };


            // IMyCloneable
            var paladin = warriorPrototype.MyClone() as Player;
            paladin.Name = "УбиванКиноби";
            paladin.Level = 10;
            paladin.Health = 120;
            paladin.Skills.Add("Искупление");
            paladin.Stats["Интеллект"] = 8;

            // ICloneable
            var alphaWolf = wolfPrototype.Clone() as NPC;
            alphaWolf.Name = "Дух древнего волка";
            alphaWolf.Level = 5;
            alphaWolf.Health = 70;
            alphaWolf.LootList.Add("Тотем духа древнего волка");
            alphaWolf.Stats["Сила"] = 10;

            // IMyCloneable
            var greaterHealthPotion = healthPotionPrototype.MyClone() as Item;
            greaterHealthPotion.Name = "Супер крутецкая хилка";
            greaterHealthPotion.Rarity = "Особое";
            greaterHealthPotion.Stats["Уровень восстановления здоровья"] = 100;


            Console.WriteLine("\n>> Прототипы");
            warriorPrototype.ShowInfo();
            Console.WriteLine();
            wolfPrototype.ShowInfo();
            Console.WriteLine();
            healthPotionPrototype.ShowInfo();

            Console.WriteLine("\n>> Клоны (IMyCloneable)");
            paladin.ShowInfo();
            Console.WriteLine();
            greaterHealthPotion.ShowInfo();

            Console.WriteLine("\n>> Клон (ICloneable)");
            alphaWolf.ShowInfo();

            Console.WriteLine("\n!!! TEST !!!");
            Console.WriteLine($"Оригинал интеллект (ожидается 3): {warriorPrototype.Stats["Интеллект"]}");
            Console.WriteLine($"Клон     интеллект (ожидается 8): {paladin.Stats["Интеллект"]}");
            Console.WriteLine($"Оригинал ловкость (ожидается 5): {warriorPrototype.Stats["Ловкость"]}");
            Console.WriteLine($"Клон     ловкость (ожидается 5): {paladin.Stats["Ловкость"]}");
            Console.WriteLine($"Оригинал количество скиллов (ожидается 3): {warriorPrototype.Skills.Count}");
            Console.WriteLine($"Клон     количество скиллов (ожидается 4): {paladin.Skills.Count}");

            Console.WriteLine($"Оригинал количество скиллов (ожидается 1): {wolfPrototype.LootList.Count}");
            Console.WriteLine($"Клон     количество скиллов (ожидается 2): {alphaWolf.LootList.Count}");
            Console.WriteLine($"Оригинал ловкость (ожидается 9): {wolfPrototype.Stats["Ловкость"]}");
            Console.WriteLine($"Клон     ловкость (ожидается 9): {alphaWolf.Stats["Ловкость"]}");

            Console.WriteLine($"Оригинал ловкость (ожидается 30): {healthPotionPrototype.Stats["Уровень восстановления здоровья"]}");
            Console.WriteLine($"Оригинал ловкость (ожидается 100): {greaterHealthPotion.Stats["Уровень восстановления здоровья"]}");
            Console.WriteLine($"Оригинал стак (ожидается true): {healthPotionPrototype.IsStackable}");
            Console.WriteLine($"Оригинал стак (ожидается true): {greaterHealthPotion.IsStackable}");
        }
    }
}


/*
ICloneable
+:
Встроен в .Net. 
Всем известен и широко используем. 
Для поддержки достаточно реализовать только один метод Clone().
-:
Возвращает непонятный object.
Неочевиден механизм копирования данных.

IMyCloneable
+:
Наглядно видно, что и как копируется.
Можно гибко менять, детально кастомизировать.
Сразу возвращает нужный тип.
-:
Надо самому писать.
Нужно добавить поддержку интерфейса в каждый класс руками.
 */