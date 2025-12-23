public class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _distanceDrivenInMeters = 0;
    private string[] _sponsors = new string[0];
    private int _latestSerialNum = 0;

    public void Drive()
    {
        if (_batteryPercentage > 0)
        {
            _batteryPercentage -= 10;
            _distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors) => _sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => _sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {        
        bool returnVal = true;
        
        if(serialNum < _latestSerialNum)
        {
            serialNum = _latestSerialNum;
            _batteryPercentage = -1;
            _distanceDrivenInMeters = -1;
            returnVal = false;
        }
        else
        {
            _latestSerialNum = serialNum;
        }
        
        batteryPercentage = _batteryPercentage;
        distanceDrivenInMeters = _distanceDrivenInMeters;

        return returnVal;
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage;
        int distanceDrivenInMeters;
        bool result = car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters);

        if(!result || distanceDrivenInMeters == 0)
        {
            return "no data";
        }
        else
        {
            int batteryUsagePerMeter = (100 - batteryPercentage) / distanceDrivenInMeters;
            return $"usage-per-meter={batteryUsagePerMeter}";
        }
    }
}
