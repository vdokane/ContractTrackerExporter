namespace FileExporter.Infrastructure
{
    internal static class StringExtensionMethods
    {
        internal static string Filter(this string str, List<char> charsToRemove)
        {
            if(string.IsNullOrEmpty(str))
                return str;

            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }

        internal static string ConvertNullableBoolToYesNo(this bool? property)
        {
            return property.HasValue ? (property.Value ? "Y" : "N") : string.Empty;  //I think or does it default to no?
        }

        internal static string ConvertNullableDateToString(this DateTime? property)
        {
            return property.HasValue ? property.Value.ToString("YYYY-MM-dd") : string.Empty;
        }

        internal static string ConvertNullableDecimalToString(this decimal? property)
        {
            return property.HasValue ? property.Value.ToString() : string.Empty;
        }
    }
}
