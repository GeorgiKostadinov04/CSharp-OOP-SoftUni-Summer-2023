using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Classes
{
    internal class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            switch(type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
