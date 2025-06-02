using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Classes;

public class Car(string fuelType, int currentCapacity) : IVehicle
{
    public int CurrentCapacity { get; set; } = currentCapacity;
    public static int MaxCapacity = 50;
    public string FuelType { get; set; } = fuelType;
}