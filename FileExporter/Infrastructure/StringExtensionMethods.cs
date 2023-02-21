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
    }
}
