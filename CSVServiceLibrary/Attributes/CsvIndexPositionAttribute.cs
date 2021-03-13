using System;

namespace CSVServiceLibrary.Attributes
{
    public class CsvIndexPositionAttribute : Attribute
    {
        public int IndexPostion { get; set; }

        public CsvIndexPositionAttribute(int indexPostion)
        {
            IndexPostion = indexPostion;
        }
    }
}