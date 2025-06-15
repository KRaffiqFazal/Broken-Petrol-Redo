using Broken_Petrol_Redo.Interfaces;

namespace Broken_Petrol_Redo.Classes;

public static class ForecourtDisplay
{
    private const string SINGLE_PUMP = "[P:{0}]";
    private const string HORIZONTAL_DIVIDER = "\n---------\n";
    private const string VERTICAL_DIVIDER = " | ";
    
    private static string ForecourtDrawn(IFuelPump[][] pumps)
    {
        string horizontalRow = "";
        string result = "";
        
        int numOfPaths = pumps.Length;
        int pumpsPerPath = pumps[0].Length;

        for (int i = 0; i < numOfPaths; i++)
        {
            for (int j = 0; j < pumpsPerPath; j++)
            {
                horizontalRow += string.Format(SINGLE_PUMP, pumps[i][j].CanFuel ? " " : "X") + VERTICAL_DIVIDER;
            }
            result += horizontalRow + HORIZONTAL_DIVIDER;
            horizontalRow = "";
        }
        return result;
    }

    private static string ForecourtQueue(List<IFunctioningVehicle> queue)
    {
        string result = "";
        foreach (IFunctioningVehicle vehicle in queue)
        {
            result += vehicle.CurrentVehicle.GetType().Name + "\n";
        }

        return result;
    }

    private static string ForecourtStats()
    {
        return "None";
    }

    public static string Display(IFuelPump[][] pumps, List<IFunctioningVehicle> queue)
    {
        return ForecourtDrawn(pumps) + "\n" + ForecourtQueue(queue) + "\n" + ForecourtStats();
    }

}