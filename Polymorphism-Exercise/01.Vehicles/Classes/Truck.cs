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
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            :base(fuelQuantity, fuelConsumption,tankCapacity, ConsumptionIncrease)
        {
           
        }

        public override void Refuel(double quantity)
        {
            if(quantity + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }
            base.Refuel(quantity*0.95);
        }
    }
}
