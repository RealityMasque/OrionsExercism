using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime dateTime = DateTime.Parse(appointmentDateDescription);

        //TimeZoneInfo macLinuxNewYork = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
        //TimeZoneInfo macLinuxLondon = TimeZoneInfo.FindSystemTimeZoneById("Europe/London");
        //TimeZoneInfo macLinuxParis = TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris");

        switch(location)
        {
            case Location.NewYork: 
                return TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            case Location.London: 
                return TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
            case Location.Paris: 
                return TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
            default:
                return TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.Local);
        }
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch(alertLevel)
        {
            case AlertLevel.Early: return appointment.AddDays(-1);
            case AlertLevel.Standard: return appointment.AddHours(-1).AddMinutes(-45);
            case AlertLevel.Late: return appointment.AddMinutes(-30);
            default: return appointment;
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        switch(location)
        {
            case Location.NewYork: 
            {
                bool isDst = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time").IsDaylightSavingTime(dt);
                bool wasDst = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time").IsDaylightSavingTime(dt.AddDays(-7));
                return wasDst != isDst;
            }
            case Location.London: 
            {
                bool isDst = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time").IsDaylightSavingTime(dt);
                bool wasDst = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time").IsDaylightSavingTime(dt.AddDays(-7));
                return wasDst != isDst;
            }
            case Location.Paris: 
            {
                bool isDst = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time").IsDaylightSavingTime(dt);
                bool wasDst = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time").IsDaylightSavingTime(dt.AddDays(-7));
                return wasDst != isDst;
            }
            default:
            {
                bool isDst = TimeZoneInfo.Local.IsDaylightSavingTime(dt);
                bool wasDst = TimeZoneInfo.Local.IsDaylightSavingTime(dt.AddDays(-7));
                return wasDst != isDst;
            }
        }
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            switch(location)
            {
                case Location.NewYork: 
                    return DateTime.Parse(dtStr, new CultureInfo("en-US"));
                case Location.London: 
                    return DateTime.Parse(dtStr, new CultureInfo("en-GB"));
                case Location.Paris: 
                    return DateTime.Parse(dtStr, new CultureInfo("fr-FR"));
                default:
                    return new DateTime(1, 1, 1, 0, 0, 0);
            }    
        }
        catch
        {
            return new DateTime(1, 1, 1, 0, 0, 0);
        }
    }
}
