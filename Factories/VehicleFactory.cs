using Broken_Petrol_Redo.Classes;
using Broken_Petrol_Redo.Interfaces;


namespace Broken_Petrol_Redo.Factories;

public class VehicleFactory
{
    public IVehicle CreateVehicle()
    {
        Random rnd = new Random();
        
        string[] vehicleTypes = { "Car", "Van", "HGV" };
        string vehicleType = vehicleTypes[rnd.Next(0, vehicleTypes.Length)];
        
        string[] fuelTypes = { "Petrol", "Diesel",  "LPG" };
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
}