using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;
        public Car(int horsePower, double fule)
            :base(horsePower, fule)
        {
            HorsePower = horsePower;
            Fuel = fule;
        }

        public override double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
        }

        public override void Drive(double killometers)
        {
            Fuel -= killometers * DefaultFuelConsumption;
        }

    }
}
