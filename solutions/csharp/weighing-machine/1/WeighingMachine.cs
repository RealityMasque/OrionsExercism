class WeighingMachine
{
    private int _precision;
    private double _weight;
    private double _tareAdjustment = 5;
    
    public int Precision => _precision;

    public double Weight 
    {
        get
        {
           return _weight; 
        }
        
        set
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException();

            _weight = value;
        }
    }

    public double TareAdjustment
    {
        get
        {
            return _tareAdjustment;
        }
        
        set
        {
            _tareAdjustment = value;
        }
    }

    public string DisplayWeight
    {
        get
        {
            double adjustedWeight = _weight - _tareAdjustment;
            string precisionFormat = $"N{_precision}";
            return $"{adjustedWeight.ToString(precisionFormat)} kg";
        }
    }

    public WeighingMachine(int precision) 
    {
        _precision = precision;
    }
}
