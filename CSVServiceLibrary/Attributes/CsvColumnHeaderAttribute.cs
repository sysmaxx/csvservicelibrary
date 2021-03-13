using System;

namespace CSVServiceLibrary.Attributes
{
    public class CsvColumnHeaderAttribute : Attribute
    {
        internal string ColumnHeader { get; set; }

        public CsvColumnHeaderAttribute(string columnHeader)
        {
            ColumnHeader = columnHeader ?? throw new ArgumentNullException(nameof(columnHeader));
        }
    }
}
