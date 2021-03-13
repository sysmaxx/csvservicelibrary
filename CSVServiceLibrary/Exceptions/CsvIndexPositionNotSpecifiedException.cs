using System;
using System.Collections.Generic;
using System.Text;

namespace CSVServiceLibrary.Exceptions
{
    class CsvIndexPositionNotSpecifiedException : Exception
    {
        public CsvIndexPositionNotSpecifiedException()
        {

        }
        public CsvIndexPositionNotSpecifiedException(string message) : base(message)
        {

        }
    }
}
