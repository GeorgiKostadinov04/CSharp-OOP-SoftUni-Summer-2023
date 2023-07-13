﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Interfaces;
using WildFarm.Models;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string[] animalTokens)
        {
            string type = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);
            switch (type)
            {
                case "Cat":
                    return new Cat(name, weight, animalTokens[3], animalTokens[4]);
                case "Tiger":
                    return new Tiger(name, weight, animalTokens[3], animalTokens[4]);
                case "Dog":
                    return new Dog(name, weight, animalTokens[3]);
                case "Mouse":
                    return new Mouse(name, weight, animalTokens[3]);
                case "Hen":
                    return new Hen(name, weight, double.Parse(animalTokens[3]));
                default:
                    return new Owl(name, weight, double.Parse(animalTokens[3]));

            }
        }
    }
}
