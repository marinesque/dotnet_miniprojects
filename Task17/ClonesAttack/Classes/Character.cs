namespace ClonesAttack.Classes
{
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

        protected Character(Character source) : base(source)
        {
            Health = source.Health;
            Mana = source.Mana;
            Level = source.Level;
            Skills = new List<string>(source.Skills);
        }

        public override object Clone()
        {
            var clone = (Character)base.Clone();
            clone.Skills = new List<string>(Skills);
            return clone;
        }

        public override GameObject MyClone()
        {
            return CloneCharacter();
        }

        protected abstract Character CloneCharacter();

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
}