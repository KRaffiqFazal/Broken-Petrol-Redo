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
        IVehicle currentVehicle = null;
        for (int i = 0; i < 300000; i++)
        {
            currentVehicle = worker.Dequeue();
            if (currentVehicle != null)
            {
                Console.WriteLine(currentVehicle.GetType());
            }
        }
        worker.StopQueueing();
        Console.WriteLine("STOPPED");
        Thread.Sleep(3000);
    }
}