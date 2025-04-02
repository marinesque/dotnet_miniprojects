namespace ClonesAttack.Classes
{
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

        protected Item(Item source) : base(source)
        {
            Rarity = source.Rarity;
            IsStackable = source.IsStackable;
        }

        public override object Clone()
        {
            var clone = (Item)base.Clone();
            return clone;
        }

        public override GameObject MyClone()
        {
            return new Item(this);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($">{GetType().Name}:");
            Console.WriteLine($"Редкость: {Rarity}");
            Console.WriteLine($"Стакающийся: {IsStackable}");
        }
    }
}