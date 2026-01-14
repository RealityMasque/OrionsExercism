public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            long denomination = checked(@base * multiplier);
            return denomination.ToString();
        }  
        catch(Exception ex)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        try
        {
            float gdp = checked(@base * multiplier);
            if(gdp == float.PositiveInfinity)
            {
                return "*** Too Big ***";
            }
            return gdp.ToString();
        }  
        catch(Exception ex)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            decimal salary = checked(salaryBase * multiplier);
            return salary.ToString();
        }  
        catch(Exception ex)
        {
            return "*** Much Too Big ***";
        }
    }
}
