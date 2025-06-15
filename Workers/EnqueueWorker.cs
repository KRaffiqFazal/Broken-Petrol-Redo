using System.Runtime.InteropServices;
using Broken_Petrol_Redo.Classes;
using Broken_Petrol_Redo.Factories;
using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Workers;

public class EnqueueWorker
{
    private List<IFunctioningVehicle> _queue = new();
    private IFuelPump[][] _petrolPumps = {
        [
            new PetrolPump(), new PetrolPump(), new PetrolPump()
        ],
        [
            new PetrolPump(), new PetrolPump(), new PetrolPump()
        ],
        [
            new PetrolPump(), new PetrolPump(), new PetrolPump()
        ]
    };
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private void Enqueue(IFunctioningVehicle waitingVehicle)
    {
        if (_queue.Count >= 5)
        {
            return;
        }
        _queue.Add(waitingVehicle);
    }

    private IFunctioningVehicle Dequeue()
    {
        try
        {
            IFunctioningVehicle selectedVehicle = _queue[^1];
            _queue.Remove(selectedVehicle);
            return selectedVehicle;
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
                Display();
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
        int preSize = -1;
        int postSize = -1;
        while (!ct.IsCancellationRequested)
        {
            try
            {
                preSize = _queue.Count;
                _queue.RemoveAll(x => x.IsCompleted);
                postSize = _queue.Count;
                if (preSize != postSize) Display();
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    public async Task RemoveFuelledVehicles()
    {
        CancellationToken  ct = _cancellationTokenSource.Token;
        while (!ct.IsCancellationRequested)
        {
            try
            {
                foreach (var path in _petrolPumps)
                {
                    foreach (var pump in path)
                    {
                        if (pump.FuellingVehicle.IsCompleted)
                        {
                            pump.ReleaseVehicle();
                            Display();
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    public async Task FuelVehicles()
    {
        CancellationToken  ct = _cancellationTokenSource.Token;
        while (!ct.IsCancellationRequested)
        {
            try
            {
                KeyValuePair<int,int> availablePump = GetAvailablePumpIndex();
                IFunctioningVehicle toFuel = Dequeue();
                _petrolPumps[availablePump.Key][availablePump.Value].AttachVehicle(toFuel);
                // TODO: Add function to block pumps based on pumps that are now in use.
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    private KeyValuePair<int, int> GetAvailablePumpIndex()
    {
        for (int i=0; i<_petrolPumps.Length; i++)
        {
            for (int j=0; j<_petrolPumps[i].Length; j++)
            {
                if (_petrolPumps[i][j] is { Blocked: false, CanFuel: true })
                {
                    return new KeyValuePair<int, int>(i, j);
                }
            }
        }
        return  new KeyValuePair<int, int>(-1, -1);
    }

    public void StopFunction()
    {
        _cancellationTokenSource.Cancel();
    }

    private void Display()
    {
        Console.Clear();
        Console.WriteLine(ForecourtDisplay.Display(_petrolPumps, _queue));
    }
}