
using Raiding.Interfaces;

namespace Raiding.Factories.Interfaces
{
    public interface IFactory
    {
        IHero Create(string type, string name);
    }
}
