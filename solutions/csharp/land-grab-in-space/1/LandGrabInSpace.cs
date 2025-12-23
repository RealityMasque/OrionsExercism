public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord Coord1 { get; }
    public Coord Coord2 { get; }
    public Coord Coord3 { get; }
    public Coord Coord4 { get; }
    public List<int> Lengths { get; } = new();
    public int MaxLength => Lengths.Max();
    
    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Coord1 = coord1;
        Coord2 = coord2;
        Coord3 = coord3;
        Coord4 = coord4;
        Lengths.Add(Length(Coord1, Coord2));
        Lengths.Add(Length(Coord2, Coord3));
        Lengths.Add(Length(Coord3, Coord4));
        Lengths.Add(Length(Coord4, Coord1));
    }

    private int Length(Coord a, Coord b)
    {
        int dX = a.X - b.X;
        int dY = a.Y - b.Y;
        int dX2 = dX * dX;
        int dY2 = dY * dY;
        int sum = dX2 + dY2;
        return (int)Math.Sqrt(sum);
    }
}


public class ClaimsHandler
{
    private List<Plot> _plots = new();
    
    public void StakeClaim(Plot plot)
    {
        _plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        foreach(Plot p in _plots)
        {
            if(p.Coord1.Equals(plot.Coord1) && 
               p.Coord2.Equals(plot.Coord2) &&
               p.Coord3.Equals(plot.Coord3) &&
               p.Coord4.Equals(plot.Coord4))
                return true;
        }

        return false;
    }

    public bool IsLastClaim(Plot plot)
    {
        if(_plots.Count == 0)
            return false;
        
        Plot lastPlot = _plots[_plots.Count - 1];

        if(lastPlot.Coord1.Equals(plot.Coord1) && 
           lastPlot.Coord2.Equals(plot.Coord2) &&
           lastPlot.Coord3.Equals(plot.Coord3) &&
           lastPlot.Coord4.Equals(plot.Coord4))
            return true;

        return false;
    }

    public Plot GetClaimWithLongestSide()
    {
        int longestSide = Int32.MinValue;
        Plot plotWithLongestide = new();
        foreach(Plot plot in _plots)
        {
            if(plot.MaxLength > longestSide)
            {
                longestSide = plot.MaxLength;
                plotWithLongestide = plot;
            }
        }
        return plotWithLongestide;
    }
}

