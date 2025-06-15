using System.IO.Compression;
using Broken_Petrol_Redo.Classes;
using Broken_Petrol_Redo.Factories;
using Broken_Petrol_Redo.Interfaces;
using Broken_Petrol_Redo.Workers;
namespace Broken_Petrol_Redo;

internal class Program
{
    static void Main(string[] args)
    {
        EnqueueWorker worker = new EnqueueWorker();

        Task.Run(() => worker.StartQueueing());
        Task.Run(() => worker.RemoveWaitingVehicles());
        Task.Run(() => worker.FuelVehicles());
        Task.Run(() => worker.RemoveFuelledVehicles());
        Thread.Sleep(10000);
        worker.StopFunction();
        Console.WriteLine("STOPPED");
        Console.ReadKey();
    }
}