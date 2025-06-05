using System.Runtime.InteropServices;
using Broken_Petrol_Redo.Factories;
using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Workers;

public class EnqueueWorker
{
    private Queue<IFunctioningVehicle> _queue = new();
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private void Enqueue(IFunctioningVehicle waitingVehicle)
    {
        if (_queue.Count >= 5)
        {
            return;
        }
        _queue.Enqueue(waitingVehicle);
    }

    public IFunctioningVehicle Dequeue()
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
            try
            {
                await Task.Delay(rnd.Next(1500, 2200), ct);
                Enqueue(factory.CreateFunctioningVehicle());
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    public async Task RemoveWaitingVehicles()
    {
        CancellationToken  ct = _cancellationTokenSource.Token;
        while (!ct.IsCancellationRequested)
        {
            try
            {
                _queue =  new Queue<IFunctioningVehicle>(_queue.Where(x => !x.IsCompleted));
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    public void StopQueueing()
    {
        _cancellationTokenSource.Cancel();
    }
}