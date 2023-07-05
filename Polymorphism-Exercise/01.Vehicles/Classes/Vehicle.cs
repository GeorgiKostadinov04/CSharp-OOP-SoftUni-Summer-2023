using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Classes
{
    public abstract class Vehicle : IVehicle
    {
        private double incresedConsumption;
        public Vehicle(double fuelQuantity, double fuelConsumption, double incresedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.incresedConsumption = incresedConsumption;
        }
        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get;private set; }

        public string Drive(double distance)
        {
            double totalConsumption = FuelConsumption + incresedConsumption;
            if(FuelQuantity < totalConsumption*distance)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= distance * totalConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double quantity)
        {
            FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
