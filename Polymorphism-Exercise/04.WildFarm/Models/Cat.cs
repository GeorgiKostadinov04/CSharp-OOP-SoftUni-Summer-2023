using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        protected override double WeightMultiplier => CatWeightMultiplier;

        protected override IReadOnlyCollection<Type> PreferredFoodTypes => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }



    }
}
