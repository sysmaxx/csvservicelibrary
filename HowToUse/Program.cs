using System;
using System.Linq;
using CSVServiceLibrary;
using HowToUse.Models;

namespace HowToUse
{
    class Program
    {
        static void Main()
        {
            var persons = CsvService.Read<SampleModel>(@"Sample.txt").ToList();

            CsvService.Write(persons, @"Sample2.txt", true);
        }
    }
}
