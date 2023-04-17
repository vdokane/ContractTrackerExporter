namespace TrackerFile.Infrastructure.Utilities
{
    public static class StringExtensionMethods
    {
        public static string Filter(this string str, List<char> charsToRemove)
        {
            if(string.IsNullOrEmpty(str))
                return string.Empty;

            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }

        public static string ConvertNullableBoolToYesNo(this bool? property)
        {
            return property.HasValue ? (property.Value ? "Y" : "N") : string.Empty;  //I think or does it default to no?
        }

        public static string ConvertNullableDateToString(this DateTime? property)
        {
            return property.HasValue ? property.Value.ToString("YYYY-MM-dd") : string.Empty;
        }

        public static string ConvertNullableDecimalToString(this decimal? property)
        {
            return property.HasValue ? property.Value.ToString() : string.Empty;
        }
    }
}
