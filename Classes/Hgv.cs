using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Classes;

public class Hgv(string fuelType, int currentCapacity) : IVehicle
{
    public int CurrentCapacity { get; set; }
    public static int MaxCapacity = 150;
    public string FuelType { get; set; }
}