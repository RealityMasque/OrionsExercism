static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string badge = (id == null) ? "" : $"[{id.Value}] - ";

        badge += $"{name} - {department?.ToUpper() ?? "OWNER"}";

        return badge;
    }
}
