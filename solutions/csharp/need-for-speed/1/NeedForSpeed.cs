class RemoteControlCar
{
    private int _speed = 0;
    private int _batteryDrain = 1;
    private int _battery = 100;
    private int _distanceDriven = 0;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _battery < _batteryDrain;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if(_battery >= _batteryDrain)
        {
            _distanceDriven += _speed;
            _battery -= _batteryDrain;
        }
    }

    /*
    public string CarState()
    {
        return $"";
    }
    */

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int _distance = 0;
    
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while(!car.BatteryDrained())
        {
            car.Drive();
        }

        return car.DistanceDriven() >= _distance;
    }
}
