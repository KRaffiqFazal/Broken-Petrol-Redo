using System.Timers;
using Broken_Petrol_Redo.Interfaces;
using Timer = System.Timers.Timer;

namespace Broken_Petrol_Redo.Classes;

public class FuelingVehicle: IFunctioningVehicle
{
    public IVehicle CurrentVehicle { get; set; }
    public bool IsCompleted { get; set; }
    private readonly Timer _completionTimer;
    public int LitresDifference { get; set; }

    public FuelingVehicle(IVehicle vehicle)
    {
        CurrentVehicle = vehicle;
        IsCompleted = false;
        _completionTimer = new(vehicle.FuelDif() * 1000);
        _completionTimer.AutoReset = false;
        _completionTimer.Elapsed += CompletionTimerOnElapsed; 
        _completionTimer.Enabled = true;
        LitresDifference = 0;

    }
    private void CompletionTimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        IsCompleted = true;
        _completionTimer.Dispose();
        LitresDifference = CurrentVehicle.Fueled();
    }
}