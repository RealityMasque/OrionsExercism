static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string badge = "";
        
        if(id != null)
            badge += $"[{id.Value}] - ";

        badge += $"{name} - ";

        if(department != null)
            badge += department.ToUpper();
        else
            badge += "OWNER";

        return badge;
    }
}
