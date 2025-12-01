using System.Text;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) => 
        studentA.PadLeft(29, ' ') + " ♡ " + studentB.PadRight(29, ' ');        

    private static string GetInitials(string name) => name.Substring(0, 1) + ". " + name.Substring(name.IndexOf(" ") + 1, 1) + ".";
    
    public static string DisplayBanner(string studentA, string studentB)
    {
        StringBuilder heartBuilder = new StringBuilder();
        heartBuilder.AppendLine("     ******       ******");
        heartBuilder.AppendLine("   **      **   **      **");
        heartBuilder.AppendLine(" **         ** **         **");
        heartBuilder.AppendLine("**            *            **");
        heartBuilder.AppendLine("**                         **");

        string initialsA = GetInitials(studentA).PadLeft(10, ' ').PadLeft(12, '*');
        string initialsB = GetInitials(studentB).PadRight(10, ' ').PadRight(12, '*');
        heartBuilder.AppendLine($"{initialsA}  +  {initialsB}");
        
        heartBuilder.AppendLine(" **                       **");
        heartBuilder.AppendLine("   **                   **");
        heartBuilder.AppendLine("     **               **");
        heartBuilder.AppendLine("       **           **");
        heartBuilder.AppendLine("         **       **");
        heartBuilder.AppendLine("           **   **");
        heartBuilder.AppendLine("             ***");
        heartBuilder.AppendLine("              *");

        return heartBuilder.ToString();
    }

    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours)
    {
        CultureInfo cultureInfo = new CultureInfo("de-DE");
        string formattedStart = start.ToString("d", cultureInfo);
        string formattedHours = hours.ToString("N2", cultureInfo);
        return $"{studentA} and {studentB} have been dating since {formattedStart} - that's {formattedHours:n} hours";
    }
}
