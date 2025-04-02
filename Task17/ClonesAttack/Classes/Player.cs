namespace ClonesAttack.Classes
{
    public class Player : Character
    {
        public string ClassName { get; set; }
        public int Experience { get; set; }

        public Player(string name, int level, float health, float mana, string className)
            : base(name, level, health, mana)
        {
            ClassName = className;
        }

        protected Player(Player source) : base(source)
        {
            ClassName = source.ClassName;
            Experience = source.Experience;
        }

        public override object Clone()
        {
            var clone = (Player)base.Clone();
            return clone;
        }

        protected override Character CloneCharacter()
        {
            return new Player(this);
        }

        public override GameObject MyClone()
        {
            return CloneCharacter();
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($">{GetType().Name}:");
            Console.WriteLine($"Класс: {ClassName}");
            Console.WriteLine($"Опыт: {Experience}");
        }
    }
}