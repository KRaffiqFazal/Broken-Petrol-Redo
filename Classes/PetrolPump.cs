using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Classes;

public class PetrolPump : IFuelPump
{
    public IFunctioningVehicle FuellingVehicle { get; set; }
    public Dictionary<string, int> LitresDispensed { get; set; }
    public bool CanFuel { get; set; }
    public bool Blocked { get; set; }
    
    public void ReleaseVehicle()
    {
        LitresDispensed[FuellingVehicle.CurrentVehicle.FuelType] += FuellingVehicle.CurrentVehicle.Fueled();
        FuellingVehicle = null;
        CanFuel = true;
    }

    public PetrolPump()
    {
        FuellingVehicle = null;
        LitresDispensed = new(){
            { "Petrol", 0},
            { "Diesel", 0},
            { "LPG", 0 }
        };
        CanFuel = true;
        Blocked = false;
    }

    public bool AttachVehicle(IFunctioningVehicle vehicle)
    {
        FuellingVehicle = new FuelingVehicle(vehicle.CurrentVehicle);
        return true;
    }
}