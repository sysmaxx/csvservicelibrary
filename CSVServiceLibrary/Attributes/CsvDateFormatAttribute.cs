using CSVServiceLibrary.Interfaces;
using System;
using System.Globalization;

namespace CSVServiceLibrary.Attributes
{
    public class CsvDateFormatAttribute : Attribute, ICsvReadable, ICsvWriteable
    {
        private string DateTimeFormat { get; set; }

        public CsvDateFormatAttribute(string dateTimeFormat)
        {
            DateTimeFormat = dateTimeFormat ?? throw new ArgumentNullException(nameof(dateTimeFormat));
        }

        public object PerformReadAttribute(object value)
        {
            DateTime.TryParseExact(value.ToString(),
                DateTimeFormat,
                new CultureInfo("en-US"),
                DateTimeStyles.None,
                out DateTime tmpDateTime);
            return tmpDateTime;
        }

        public object PerformWriteAttribute(object value)
        {
            return ((DateTime)value).ToString(DateTimeFormat);
        }
    }
}