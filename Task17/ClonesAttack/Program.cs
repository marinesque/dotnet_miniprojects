namespace ClonesAttack
{
    public abstract class GameObject : ICloneable
    {
        public string Name { get; set; }
        public Dictionary<string, int> Stats { get; set; } = new();

        protected GameObject(string name)
        {
            Name = name;
        }

        public virtual object Clone()
        {
            var clone = (GameObject)MemberwiseClone();
            clone.Stats = new Dictionary<string, int>(Stats);
            return clone;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Статы: " + string.Join(", ", Stats));
        }
    }

    public abstract class Character : GameObject
    {
        public float Health { get; set; }
        public float Mana { get; set; }
        public int Level { get; set; }
        public List<string> Skills { get; set; } = new();

        protected Character(string name, int level, float health, float mana)
            : base(name)
        {
            Health = health;
            Mana = mana;
            Level = level;
        }

        public override object Clone()
        {
            var clone = (Character)base.Clone();
            clone.Skills = new List<string>(Skills);
            return clone;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($">{GetType().Name}: {Name}");
            Console.WriteLine($"Lvl: {Level}");
            Console.WriteLine($"Здоровье: {Health}");
            Console.WriteLine($"Мана: {Mana}");
            Console.WriteLine("Скиллы: " + string.Join(", ", Skills));
        }
    }

    public class Player : Character
    {
        public string ClassName { get; set; }
        public int Experience { get; set; }

        public Player(string name, int level, float health, float mana, string className)
            : base(name, level, health, mana)
        {
            ClassName = className;
        }

        public override object Clone()
        {
            var clone = (Player)base.Clone();
            return clone;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($">{GetType().Name}:");
            Console.WriteLine($"Класс: {ClassName}");
            Console.WriteLine($"Опыт: {Experience}");
        }
    }

    public class NPC : Character
    {
        public bool IsAggressive { get; set; }
        public List<string> LootList { get; set; } = new();

        public NPC(string name, int level, float health, float mana, bool isAggressive)
            : base(name, level, health, mana)
        {
            IsAggressive = isAggressive;
        }

        public override object Clone()
        {
            var clone = (NPC)base.Clone();
            clone.LootList = new List<string>(LootList);
            return clone;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($">{GetType().Name}:");
            Console.WriteLine($"Агр: {IsAggressive}");
            Console.WriteLine($"Лут: " + string.Join(", ", LootList));
        }
    }

    public class Item : GameObject
    {
        public string Rarity { get; set; }
        public bool IsStackable { get; set; }

        public Item(string name, string rarity, bool isStackable)
            : base(name)
        {
            Rarity = rarity;
            IsStackable = isStackable;
        }

        public override object Clone()
        {
            var clone = (Item)base.Clone();
            return clone;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($">{GetType().Name}:");
            Console.WriteLine($"Редкость: {Rarity}");
            Console.WriteLine($"Стакающийся: {IsStackable}");
        }
    }

    class Program
    {
        static void Main()
        {
            var warriorPrototype = new Player("Рандом", 1, 100, 50, "Паладин")
            {
                Stats = { ["Сила"] = 10, ["Ловкость"] = 5, ["Интеллект"] = 3 },
                Skills = { "Молот правосудия", "Освящение", "Божественный щит" },
                Experience = 0
            };

            var paladin = (Player)warriorPrototype.Clone();
            paladin.Name = "УбиванКиноби";
            paladin.Level = 10;
            paladin.Health = 120;
            paladin.Skills.Add("Искупление");
            paladin.Stats["Интеллект"] = 8;


            var wolfPrototype = new NPC("Карома", 13, 45, 0, true)
            {
                Stats = { ["Сила"] = 7, ["Ловкость"] = 9, ["Интеллект"] = 1 },
                LootList = { "Кристальная слеза верности" }
            };

            var alphaWolf = (NPC)wolfPrototype.Clone();
            alphaWolf.Name = "Дух древнего волка";
            alphaWolf.Level = 5;
            alphaWolf.Health = 70;
            alphaWolf.LootList.Add("Тотем духа древнего волка");
            alphaWolf.Stats["Сила"] = 10;


            var healthPotionPrototype = new Item("Зелье здоровья", "Общее", true)
            {
                Stats = { ["Уровень восстановления здоровья"] = 30 }
            };

            var greaterHealthPotion = (Item)healthPotionPrototype.Clone();
            greaterHealthPotion.Name = "Супер крутецкая хилка";
            greaterHealthPotion.Rarity = "Особое";
            greaterHealthPotion.Stats["Уровень восстановления здоровья"] = 100;


            Console.WriteLine(">> Прототипы");
            warriorPrototype.ShowInfo();
            Console.WriteLine();
            wolfPrototype.ShowInfo();
            Console.WriteLine();
            healthPotionPrototype.ShowInfo();

            Console.WriteLine("\n>> Клоны");
            paladin.ShowInfo();
            Console.WriteLine();
            alphaWolf.ShowInfo();
            Console.WriteLine();
            greaterHealthPotion.ShowInfo();
        }
    }
}
