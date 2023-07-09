

namespace Raiding.Classes
{
    public class Paladin : Hero
    {
        private const int PowerPoints = 100;
        public Paladin(string name) :
            base(name, PowerPoints)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
