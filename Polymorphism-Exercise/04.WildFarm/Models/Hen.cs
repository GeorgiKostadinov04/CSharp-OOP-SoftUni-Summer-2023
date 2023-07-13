using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    
    public class Hen : Bird
    {
       
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            
        }

        protected override IReadOnlyCollection<Type> PreferredFoodTypes => new HashSet<Type>() { typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable)};

        protected override double WeightMultiplier => HenWeightMultiplier;

        public override string ProduceSound()
        {
            return "Cluck";
        }

    }
}
