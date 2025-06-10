namespace Broken_Petrol_Redo.Interfaces;

public interface IFuelPump
{
    IFunctioningVehicle FuellingVehicle { get; set; }
    Dictionary<string, int> LitresDispensed { get; set; }
    bool CanFuel { get; set; }
    bool Blocked { get; set; }
    void ReleaseVehicle();
    
}