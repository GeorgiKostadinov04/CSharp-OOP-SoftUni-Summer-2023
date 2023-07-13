using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.Interfaces;
using WildFarm.IO.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            animals = new List<IAnimal>();
        }

        private IAnimal CreateAnimal(string command)
        {
            string[] animalArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.Create(animalArgs);

            return animal;
        }

        private IFood CreateFood()
        {
            string[] foodTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            IFood food = foodFactory.Create(type, quantity);
            
            return food;
        }

        public void Run()
        {
            string command;

            while((command = reader.ReadLine()) != "End") 
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(command);

                    IFood food = CreateFood();

                    writer.WriteLine(animal.ProduceSound());

                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch 
                {
                    throw;
                }
                animals.Add(animal);
            }

            foreach(IAnimal animal in animals)
            {
                writer.WriteLine(animal);
            }
        }
    }
}
