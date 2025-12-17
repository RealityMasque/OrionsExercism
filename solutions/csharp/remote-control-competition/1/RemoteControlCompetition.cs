public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        ProductionRemoteControlCar other = obj as ProductionRemoteControlCar;
        if (other != null)
            return NumberOfVictories.CompareTo(other.NumberOfVictories);
        else
           throw new ArgumentException("Object is not a ProductionRemoteControlCar");
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> rankedCars = new List<ProductionRemoteControlCar> { prc1, prc2 };
        rankedCars.Sort();
        return rankedCars;
    }
}
