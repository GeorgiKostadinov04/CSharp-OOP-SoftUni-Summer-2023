using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Classes
{
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            :base(fuelQuantity, fuelConsumption, ConsumptionIncrease)
        {
           
        }

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity*0.95);
        }
    }
}
