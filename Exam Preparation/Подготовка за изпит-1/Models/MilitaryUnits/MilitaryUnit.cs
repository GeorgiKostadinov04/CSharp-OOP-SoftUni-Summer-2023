using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        protected MilitaryUnit(double cost) 
        {
            Cost = cost;
            this.enduranceLevel = 0;
        }
        public double Cost { get => cost; private set => cost = value; }

        public int EnduranceLevel { get => enduranceLevel; }

        public void IncreaseEndurance()
        {
            this.enduranceLevel++;

            if(this.enduranceLevel > 20)
            {
                this.enduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }

        }
    }
}
