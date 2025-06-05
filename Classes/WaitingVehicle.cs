using System.Timers;
using Broken_Petrol_Redo.Interfaces;
using Timer = System.Timers.Timer;

namespace Broken_Petrol_Redo.Classes;

public class WaitingVehicle: IFunctioningVehicle
{
    public IVehicle CurrentVehicle { get; set; }
    public bool IsCompleted { get; set; }
    private Timer _completionTimer;

    public WaitingVehicle(IVehicle currentVehicle, int waitingTime)
    {
        CurrentVehicle = currentVehicle;
        _completionTimer = new (waitingTime);
        _completionTimer.AutoReset = false;
        _completionTimer.Elapsed += CompletionTimerOnElapsed;
        IsCompleted = false;

    }
    private void CompletionTimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        IsCompleted = true;
    }

}