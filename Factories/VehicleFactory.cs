using Broken_Petrol_Redo.Classes;
using Broken_Petrol_Redo.Interfaces;


namespace Broken_Petrol_Redo.Factories;

public class VehicleFactory
{
    private IVehicle CreateVehicle()
    {
        Random rnd = new();

        string[] vehicleTypes = { "Car", "Van", "HGV" };
        string vehicleType = vehicleTypes[rnd.Next(0, vehicleTypes.Length)];

        string[] fuelTypes = { "Petrol", "Diesel", "LPG" };
        string fuelType;

        switch (vehicleType)
        {
            case "Car":
                fuelType = fuelTypes[rnd.Next(0, fuelTypes.Length)];
                return new Car(fuelType, rnd.Next(1, Car.MaxCapacity));
            case "Van":
                fuelType = fuelTypes[rnd.Next(1, fuelTypes.Length)];
                return new Van(fuelType, rnd.Next(1, Van.MaxCapacity));
            case "HGV":
                return new Hgv("Diesel", rnd.Next(1, Hgv.MaxCapacity));
            default:
                throw new ApplicationException("Invalid vehicle type");
        }
    }

    public IFunctioningVehicle CreateFunctioningVehicle(bool waiting = true)
    {
        IVehicle vehicle = CreateVehicle();
        if(waiting)
        {
            Random rnd = new();
            return new WaitingVehicle(vehicle, rnd.Next(1000, 2000));
        }

        return new FuelingVehicle(vehicle, vehicle.FuelDif());
    }
}