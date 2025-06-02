namespace Broken_Petrol_Redo.Interfaces;

public interface IVehicle
{
    int CurrentCapacity { get; set; }
    static int MaxCapacity { get; set; }
    string FuelType {get; set; }
}