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
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity,  double incresedConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.incresedConsumption = incresedConsumption;
        }
        public double FuelQuantity 
        {
            get => fuelQuantity;

            private set
            {
                if(TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity  { get; private set; }

        public string Drive(double distance, bool isIncreasedConsumption = true)
        {
            double consumption = isIncreasedConsumption
                ? FuelConsumption + incresedConsumption
                : FuelConsumption;

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (quantity + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }
            FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
