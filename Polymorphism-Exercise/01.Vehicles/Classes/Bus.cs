using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Classes
{
    public class Bus : Vehicle
    {
        private const double ConsumptionIncrease = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : 
            base(fuelQuantity, fuelConsumption, tankCapacity, ConsumptionIncrease)
        {
        }
    }
}
