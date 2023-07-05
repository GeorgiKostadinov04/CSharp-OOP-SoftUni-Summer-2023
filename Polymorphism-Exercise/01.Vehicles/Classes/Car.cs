﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Classes
{
    public class Car : Vehicle
    {
        private const double ConsumptionIncrease = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption, ConsumptionIncrease)
        {
            
        }
    }
}