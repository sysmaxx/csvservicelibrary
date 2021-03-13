using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSVServiceLibrary.Models
{
    class CsvPropertyAttributeMap
    {
        public PropertyInfo Propertie { get; set; }
        public Attribute[] Attributes { get; set; }
    }
}
