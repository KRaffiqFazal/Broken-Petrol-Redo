namespace Broken_Petrol_Redo.Classes;

public static class ForecourtDisplay
{
    private static string singlePump = "single pump";
    private static string horizontalDivider = "horizontal divider";
    private static string verticalDivider = "vertical divider";
    
    private static string ForecourtDrawn(int numOfPaths, int pumpsPerPath)
    {
        string horizontalRow = "";
        string result = "";
        for (int i = 0; i < numOfPaths; i++)
        {
            horizontalRow += singlePump + verticalDivider;
        }

        for (int i = 0; i < pumpsPerPath; i++)
        {
            result += horizontalRow + verticalDivider;
        }
        return result;
    }

    private static string ForecourtStats()
    {
        return "None";
    }

    public static string Display(int numOfPaths = 3, int pumpsPerPath = 3)
    {
        return ForecourtDrawn(numOfPaths, pumpsPerPath) + ForecourtStats();
    }

}