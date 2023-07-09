

namespace Raiding.Classes
{
    public class Druid : Hero
    {
        private const int PowerPoints = 80;

        public Druid(string name) : 
            base(name, PowerPoints)
        {

        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
