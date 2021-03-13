namespace CSVServiceLibrary.Extensions
{
    internal static class StringExtensions
    {
        public static string EncloseIfNeeded(this string value, string encloseString)
        {
            if (value.Contains(" "))
            {
                value = $"{encloseString}{value}{encloseString}";
            }

            return value;
        }

    }
}
