static class AssemblyLine
{
    private static double carsPerHour = 221.0d;
    private static double minutesPerHour = 60.0d;
    
    public static double SuccessRate(int speed)
    {
        if(speed < 1)
            return 0.0d;
        else if(speed < 5)
            return 1.0d;
        else if(speed < 9)
            return 0.9d;
        else if(speed < 10)
            return 0.8d;

        return 0.77d;
    }
    
    public static double ProductionRatePerHour(int speed) => carsPerHour * SuccessRate(speed) * speed;

    public static int WorkingItemsPerMinute(int speed) => (int)(ProductionRatePerHour(speed) / minutesPerHour);
}
