using CSVServiceLibrary.Attributes;
using CSVServiceLibrary.Models;
using System;

namespace HowToUse.Models
{
    class SampleModel : CsvBaseModel
    {
        [CsvColumnHeader("ID")]
        [CsvIndexPosition(0)]
        public int ID { get; set; }

        [CsvIgnoreField]
        [CsvColumnHeader("Vorname")]
        [CsvIndexPosition(1)]
        public string FirstName { get; set; }

        [CsvColumnHeader("Nachname")]
        [CsvIndexPosition(2)]
        public string LastName { get; set; }

        [CsvColumnHeader("Geburtstag")]
        [CsvIndexPosition(3)]
        [CsvDateFormat("MM-dd-yyyy")]
        public DateTime BirthDay { get; set; }

    }
}
