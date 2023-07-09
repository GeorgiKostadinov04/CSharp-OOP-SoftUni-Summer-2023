using System;
using Raiding.Classes;
using Raiding.Factories.Interfaces;
using Raiding.Interfaces;

namespace Raiding.Factories
{
    public class Factory :IFactory
    {
        public IHero Create(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }

    }
}
