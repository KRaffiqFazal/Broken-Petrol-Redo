namespace Broken_Petrol_Redo.Interfaces;

public interface IVehicle
{
    int CurrentCapacity { get; set; }
    string FuelType {get; set; }

    public int FuelDif();
    int Fueled();
}