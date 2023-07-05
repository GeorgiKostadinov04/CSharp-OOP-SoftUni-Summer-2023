using _01.Vehicles.Classes;
using _01.Vehicles.Interfaces;

IReader reader = new ConsoleReader();

IWriter writer = new ConsoleWriter();

IVehicleFactory vehicleFactory = new VehicleFactory();

IEngine engine = new Engine(reader, writer, vehicleFactory);

engine.Run();
