using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CSVServiceLibrary.Models;
using static CSVServiceLibrary.Extensions.CsvBaseModelExtension;
using static CSVServiceLibrary.Helper.CsvHeaderHelper;

namespace CSVServiceLibrary
{
    public static class CsvService
    {
        private const string defaultPattern = "(?<=^|,)(\"(?:[^\"]|\"\")*\"|[^,]*)";
        public static IEnumerable<T> Read<T>(string @filePath, 
            bool ignoreHeader = false, 
            string defaultPattern = defaultPattern)
            where T : CsvBaseModel, new ()
        {
            using (var reader = new StreamReader(filePath))
            {
                if (ignoreHeader)
                    _ = reader.ReadLine();

                var regexPattern = new Regex(defaultPattern);

                while (reader.ReadLine() is string line)
                {
                    string[] splittedCsv = ParseDataFromLine(regexPattern, line);

                    var tObj = new T();
                    tObj.SetProperties(splittedCsv);

                    yield return tObj;
                }
            }
        }

        private static string[] ParseDataFromLine(Regex regexPattern, string line)
        {
            return regexPattern.Matches(line)
                .Cast<Match>()
                .Select(m => m.Value.Trim(new char[] { ' ', '"' }))
                .ToArray();
        }


        private const string defaultSeperator = ",";
        private const string defaultStringEncloser = "\"";
        private const string defaultLineEnding = "\n";
        private const bool addHeader = false;

        public static void Write<T>(IEnumerable<T> dataToWrite, 
            string @filePath, 
            bool addHeader = addHeader, 
            string seperator = defaultSeperator, 
            string stringEncloser = defaultStringEncloser,
            string lineEnding = defaultLineEnding)
            where T : CsvBaseModel
        {
            using (var writer = new StreamWriter(filePath))
            {
                if (addHeader)
                {
                    writer.Write($"{string.Join(seperator, GetCsvHeadersOfType<T>(stringEncloser))}{lineEnding}");
                }

                foreach (var lineObj in dataToWrite)
                {
                    writer.Write($"{string.Join(seperator, lineObj.GetProperties(stringEncloser))}{lineEnding}");
                }
            }
        
        }


    }
}
