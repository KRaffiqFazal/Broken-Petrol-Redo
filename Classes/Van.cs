using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Classes;

public class Van(string fuelType, int currentCapacity) : IVehicle
{
    public int CurrentCapacity { get; set; } =  currentCapacity;
    public const int MaxCapacity = 80;
    public string FuelType { get; set; } = fuelType;
    
    public int Fueled()
    {
        int litresDifference = FuelDif();
        CurrentCapacity = MaxCapacity;
        return litresDifference;
    }
    
    public int FuelDif()
    {
        return MaxCapacity - CurrentCapacity;
    }
}