using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Interfaces;
using WildFarm.Models;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood Create(string type, int quantity)
        {
            switch(type)
            {
                case "Fruit":
                    return new Fruit(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Meat":
                    return new Meat(quantity);
                default:
                    return new Seeds(quantity);
            }
        }
    }
}
