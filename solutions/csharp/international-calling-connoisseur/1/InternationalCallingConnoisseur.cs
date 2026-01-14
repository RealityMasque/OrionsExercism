public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new Dictionary<int, string>();

    public static Dictionary<int, string> GetExistingDictionary() => new Dictionary<int, string>
        {
            {1, "United States of America"},
            {55, "Brazil"},
            {91, "India"}
        };

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) => 
        new Dictionary<int, string>
            {
                {countryCode, countryName}
            };

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int countryCode) =>                            CheckCodeExists(existingDictionary, countryCode) ? existingDictionary[countryCode] : "";

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) => 
        existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if(CheckCodeExists(existingDictionary, countryCode))
            existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longest = "";
        foreach(KeyValuePair<int, string> pair in existingDictionary)
        {
            if(pair.Value.Length > longest.Length)
                longest = pair.Value;
        }
        return longest;
    }
}