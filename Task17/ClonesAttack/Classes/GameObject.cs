using ClonesAttack.Interfaces;

namespace ClonesAttack.Classes
{
    public abstract class GameObject : ICloneable, IMyCloneable<GameObject>
    {
        public string Name { get; set; }
        public Dictionary<string, int> Stats { get; set; } = new();

        protected GameObject(string name)
        {
            Name = name;
        }

        protected GameObject(GameObject source)
        {
            Name = source.Name;
            Stats = new Dictionary<string, int>(source.Stats);
        }

        public virtual object Clone()
        {
            var clone = (GameObject)MemberwiseClone();
            clone.Stats = new Dictionary<string, int>(Stats);
            return clone;
        }

        public abstract GameObject MyClone();

        public virtual void ShowInfo()
        {
            Console.WriteLine("Статы: " + string.Join(", ", Stats));
        }
    }
}