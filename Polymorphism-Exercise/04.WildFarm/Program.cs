using WildFarm.Models;
using WildFarm.Interfaces;
using System.Security.Cryptography.X509Certificates;
using WildFarm.IO.Interfaces;
using WildFarm.IO;
using WildFarm.Factories.Interfaces;
using WildFarm.Factories;
using WildFarm.Core.Interfaces;
using WildFarm.Core;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);

engine.Run();