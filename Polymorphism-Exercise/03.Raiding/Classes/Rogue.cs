

namespace Raiding.Classes
{
    public class Rogue : Hero
    {
        private const int PowerPoints = 80;
        public Rogue(string name) 
            : base(name, PowerPoints)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
