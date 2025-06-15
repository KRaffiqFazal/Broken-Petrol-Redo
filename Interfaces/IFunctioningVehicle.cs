using System.Timers;

namespace Broken_Petrol_Redo.Interfaces;

public interface IFunctioningVehicle
{
    IVehicle CurrentVehicle { get; }
    bool IsCompleted { get; }
    
}