

namespace Raiding.Classes
{
    public class Warrior : Hero
    {
        private const int PowerPoints = 100;
        public Warrior(string name) 
            : base(name, PowerPoints)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
