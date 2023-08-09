using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);

            if(planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if(unitTypeName != nameof(StormTroopers) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(AnonymousImpactUnit))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            bool doesContain = false;

            foreach(var unit in planet.Army)
            {
                if (unit.GetType() == unitTypeName.GetType())
                {
                    doesContain = true;
                }
            }
            if(doesContain)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            IMilitaryUnit unitToAdd;

            if(unitTypeName == nameof(StormTroopers))
            {
                unitToAdd = new StormTroopers();
            }
            else if(unitTypeName == nameof(SpaceForces))
            {
                unitToAdd = new SpaceForces();

            }
            else
            {
                unitToAdd = new AnonymousImpactUnit();
            }
            planet.Spend(unitToAdd.Cost);
            planet.AddUnit(unitToAdd);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);


        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            bool doesContain = false;

            foreach (var weapon in planet.Weapons)
            {
                if (weapon.GetType() == weaponTypeName.GetType())
                {
                    doesContain = true;
                }
            }
            if (doesContain)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if(weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(SpaceMissiles) && weaponTypeName != nameof(NuclearWeapon))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            IWeapon weaponToAdd;

            if(weaponTypeName == nameof(BioChemicalWeapon))
            {
                weaponToAdd = new BioChemicalWeapon(destructionLevel);
            }
            else if(weaponTypeName == nameof(SpaceMissiles))
            {
                weaponToAdd = new SpaceMissiles(destructionLevel);
            }
            else
            {
                weaponToAdd =  new NuclearWeapon(destructionLevel);
            }
            planet.Spend(weaponToAdd.Price);
            planet.AddWeapon(weaponToAdd);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);

            if (this.planets.FindByName(name) != default)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            else
            {
                this.planets.AddItem(planet);
                return string.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var planet in planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.ToString());
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);

            double sumOfUnits = 0;
            double sumOfWeapons = 0;
            if (firstPlanet.MilitaryPower ==secondPlanet.MilitaryPower && firstPlanet.Weapons.Any(w =>w.GetType() == typeof(NuclearWeapon)) && !secondPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)))
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);

                foreach(var unit in secondPlanet.Army)
                {
                    sumOfUnits += unit.Cost;
                }

                foreach(var weapon in secondPlanet.Weapons)
                {
                    sumOfWeapons += weapon.Price;
                }
                firstPlanet.Profit(sumOfUnits + sumOfWeapons);
                planets.RemoveItem(planetTwo);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if(firstPlanet.MilitaryPower == secondPlanet.MilitaryPower && !firstPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)) && secondPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)))
            {
                secondPlanet.Spend(secondPlanet.Budget/2);
                secondPlanet.Profit(firstPlanet.Budget / 2);

                foreach (var unit in firstPlanet.Army)
                {
                    sumOfUnits += unit.Cost;
                }

                foreach (var weapon in firstPlanet.Weapons)
                {
                    sumOfWeapons += weapon.Price;
                }
                secondPlanet.Profit(sumOfUnits + sumOfWeapons);
                planets.RemoveItem(planetOne);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            else if(firstPlanet.MilitaryPower == secondPlanet.MilitaryPower && firstPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)) && secondPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)))
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                secondPlanet.Spend(secondPlanet.Budget / 2);

                return OutputMessages.NoWinner;
            }
            else if(firstPlanet.MilitaryPower == secondPlanet.MilitaryPower && !firstPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)) && !secondPlanet.Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)))
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                secondPlanet.Spend(secondPlanet.Budget / 2);

                return OutputMessages.NoWinner;
            }
            else if(firstPlanet.MilitaryPower >  secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);

                foreach (var unit in secondPlanet.Army)
                {
                    sumOfUnits += unit.Cost;
                }

                foreach (var weapon in secondPlanet.Weapons)
                {
                    sumOfWeapons += weapon.Price;
                }
                firstPlanet.Profit(sumOfUnits + sumOfWeapons);
                planets.RemoveItem(planetTwo);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);

                foreach (var unit in firstPlanet.Army)
                {
                    sumOfUnits += unit.Cost;
                }

                foreach (var weapon in firstPlanet.Weapons)
                {
                    sumOfWeapons += weapon.Price;
                }
                secondPlanet.Profit(sumOfUnits + sumOfWeapons);
                planets.RemoveItem(planetOne);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if(planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.Spend(1.25);
            foreach(var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }
            return string.Format(OutputMessages.ForcesUpgraded, planetName);

        }
    }
}
