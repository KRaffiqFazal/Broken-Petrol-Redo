using System.Runtime.InteropServices;
using Broken_Petrol_Redo.Factories;
using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Workers;

public class EnqueueWorker
{
    private Queue<IVehicle> _queue = new();
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private void Enqueue(IVehicle vehicle)
    {
        if (_queue.Count >= 5)
        {
            return;
        }
        _queue.Enqueue(vehicle);
    }

    public IVehicle Dequeue()
    {
        try
        {
            return _queue.Dequeue();
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public async Task StartQueueing()
    {
        CancellationToken  ct = _cancellationTokenSource.Token;
        Random rnd = new();
        VehicleFactory  factory = new();
        while (!ct.IsCancellationRequested)
        {
            Thread.Sleep(rnd.Next(1500, 2200));
            Enqueue(factory.CreateVehicle());
        }
    }

    public void StopQueueing()
    {
        _cancellationTokenSource.Cancel();
    }
}