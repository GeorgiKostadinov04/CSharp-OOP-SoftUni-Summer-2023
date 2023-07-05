using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        private int horsePowers;
        private double fuel;

        public Vehicle(int horsePowers, double fuel)
        {
            HorsePower = horsePowers;
            Fuel = fuel;
        }
        public virtual double FuelConsumption { get { return DefaultFuelConsumption; }}

        public double Fuel { get {  return fuel; } set {  fuel = value; } }


        public int HorsePower { get { return horsePowers; } set { horsePowers = value; } }


        public virtual void Drive(double killometers)
        {
            Fuel -= killometers * FuelConsumption;
        }
    }
}
