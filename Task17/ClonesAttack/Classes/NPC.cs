namespace ClonesAttack.Classes
{
    public class NPC : Character
    {
        public bool IsAggressive { get; set; }
        public List<string> LootList { get; set; } = new();

        public NPC(string name, int level, float health, float mana, bool isAggressive)
            : base(name, level, health, mana)
        {
            IsAggressive = isAggressive;
        }

        protected NPC(NPC source) : base(source)
        {
            IsAggressive = source.IsAggressive;
            LootList = new List<string>(source.LootList);
        }

        public override object Clone()
        {
            var clone = (NPC)base.Clone();
            clone.LootList = new List<string>(LootList);
            return clone;
        }


        protected override Character CloneCharacter()
        {
            return new NPC(this);
        }

        public override GameObject MyClone()
        {
            return CloneCharacter();
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($">{GetType().Name}:");
            Console.WriteLine($"Агр: {IsAggressive}");
            Console.WriteLine($"Лут: " + string.Join(", ", LootList));
        }
    }
}