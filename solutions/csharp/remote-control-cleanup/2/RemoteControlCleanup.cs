public class RemoteControlCar
{
    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }
    
        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }
    
        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }
    
            return Amount + " " + unitsString;
        }
    }
    
    public class MyTelemetry
    {
        private RemoteControlCar _remoteControlCar;

        public MyTelemetry(RemoteControlCar remoteControlCar)
        {
            this._remoteControlCar = remoteControlCar;
        }
        
        public void Calibrate()
        {
    
        }
    
        public bool SelfTest()
        {
            return true;
        }
    
        public void ShowSponsor(string sponsorName)
        {
            _remoteControlCar.SetSponsor(sponsorName);
        }
    
        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }
    
            _remoteControlCar.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public RemoteControlCar()
    {
        Telemetry = new MyTelemetry(this);
    }
    
    public MyTelemetry Telemetry { get; private set; }
    
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}
