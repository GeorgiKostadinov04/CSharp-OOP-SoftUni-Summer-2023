using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;
        private string name;
        private double budget;
        private double militaryPower;

        public Planet(string name, double budget) 
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
            
        }
        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget; 
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get => militaryPower; 
            private set
            {
                int enduranceSum = 0;
                int weaponDestructionSum = 0;
                bool haveUnit = false;
                bool haveWeapon = false;

                foreach(var unit in units.Models)
                {
                    if(unit.GetType() == typeof(AnonymousImpactUnit)) 
                    {
                        haveUnit = true;
                    }
                    enduranceSum += unit.EnduranceLevel;
                }
                foreach(var weapon in weapons.Models)
                {
                    if(weapon.GetType() == typeof(NuclearWeapon))
                    {
                        haveWeapon = true;
                    }
                    weaponDestructionSum += weapon.DestructionLevel;
                }

                double totalAmount = enduranceSum + weaponDestructionSum;

                if (haveUnit)
                {
                    totalAmount = totalAmount * 130 / 100;
                }

                if(haveWeapon)
                {
                    totalAmount = totalAmount * 145 / 100;
                }
                militaryPower = Math.Round(totalAmount, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Plante: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            sb.Append("--Forces: ");

            if(units.Models.Count < 1)
            {
                sb.Append("No units");
            }
            else
            {
                foreach(var  unit in units.Models)
                {
                    sb.Append($"{unit.GetType().Name}");
                }
            }

            sb.AppendLine("--Combat equipment: ");

            if(weapons.Models.Count < 1)
            {
                sb.Append("No weapons");
            }
            else
            {
                foreach( var weapon in weapons.Models)
                {
                    sb.Append($"{weapon.GetType().Name}");
                }
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.budget += amount;
        }

        public void Spend(double amount)
        {
            if(this.budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.budget -= amount;
        }

        public void TrainArmy()
        {
            foreach(var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
