using System;
using System.Collections.Generic;
using System.Text;

namespace CSVServiceLibrary.Interfaces
{
    internal interface ICsvWriteable
    {
        object PerformWriteAttribute(object value);
    }
}
