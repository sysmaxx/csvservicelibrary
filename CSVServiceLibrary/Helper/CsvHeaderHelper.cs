using CSVServiceLibrary.Attributes;
using System.Collections.Generic;
using System.Linq;
using static CSVServiceLibrary.Helper.CsvPropertyHelper;
using static CSVServiceLibrary.Extensions.StringExtensions;

namespace CSVServiceLibrary.Helper
{
    internal static class CsvHeaderHelper
    {
        public static string[] GetCsvHeadersOfType<T>(string encloseString)
        {
            var output = new List<string>();

            var propertiesAttributeMap = GetPropertiesAttributeMap<T>();

            foreach (var propAttr in propertiesAttributeMap)
            {
                var header = ((CsvColumnHeaderAttribute)propAttr.Attributes.FirstOrDefault(attr => attr is CsvColumnHeaderAttribute))?.ColumnHeader ?? string.Empty;
                output.Add(header.EncloseIfNeeded(encloseString));
            }

            return output.ToArray();
        }

    }
}
