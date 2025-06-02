using Broken_Petrol_Redo.Factories;
using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo;

class Program
{
    static void Main(string[] args)
    {
        VehicleFactory factory = new VehicleFactory();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(factory.CreateVehicle().GetType());
        }

        IVehicle vehicle = factory.CreateVehicle();
        Console.WriteLine(vehicle.GetType());
    }
}