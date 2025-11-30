class BirdCount
{
    private int[] birdsPerDay;
    private static int[] birdsPerDayLastWeek = {0, 2, 5, 3, 7, 8, 4};

    private int GetDayOfWeek()
    {
        int dayOfWeek = (int)DateTime.Now.DayOfWeek;
        --dayOfWeek;
        if(dayOfWeek < 0)
            dayOfWeek = 6;

        return dayOfWeek;
    }

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => birdsPerDayLastWeek;

    public int Today() => birdsPerDay[GetDayOfWeek()];

    public void IncrementTodaysCount()
    {
        birdsPerDay[GetDayOfWeek()] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach(int count in birdsPerDay)
        {
            if(count == 0)
                return true;
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        for(int i = 0; i < numberOfDays; ++i)
            sum += birdsPerDay[i];
        return sum;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach(int count in birdsPerDay)
            if(count > 4)
                ++busyDays;
        return busyDays;
    }
}
