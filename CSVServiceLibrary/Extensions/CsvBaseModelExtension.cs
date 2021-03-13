using CSVServiceLibrary.Attributes;
using CSVServiceLibrary.Models;
using System;
using System.Linq;
using CSVServiceLibrary.Interfaces;
using System.Collections.Generic;
using static CSVServiceLibrary.Helper.CsvPropertyHelper;
using static CSVServiceLibrary.Helper.ReflactionHelper;

namespace CSVServiceLibrary.Extensions
{
    internal static class CsvBaseModelExtension
    {
        public static void SetProperties<T>(this T callerObj, string[] rowData)
            where T : CsvBaseModel
        {
            var properties = typeof(T).GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(CsvIndexPositionAttribute)));

            foreach (var property in properties)
            {
                Attribute[] attributes = Attribute.GetCustomAttributes(property);

                var indexPositionAttribute = attributes.FirstOrDefault(attr => attr is CsvIndexPositionAttribute) as CsvIndexPositionAttribute;
                object fieldValue = rowData[indexPositionAttribute.IndexPostion];

                foreach (ICsvReadable attribute in attributes.Where(attr => attr is ICsvReadable))
                {
                    fieldValue = attribute.PerformReadAttribute(fieldValue);
                }

                Type propertyType = GetPropertyType(property);
                property.SetValue(callerObj, Convert.ChangeType(fieldValue, propertyType));
            }
        }

        public static string[] GetProperties<T>(this T calllerObj, string encloseString)
            where T : CsvBaseModel
        {
            var output = new List<string>();

            var propertiesAttributeMap = GetPropertiesAttributeMap<T>();

            foreach (var propAttr in propertiesAttributeMap)
            {
                object fieldValue = propAttr.Propertie.GetValue(calllerObj);

                foreach (ICsvWriteable attribute in propAttr.Attributes.Where(attr => attr is ICsvWriteable))
                {
                    fieldValue = attribute.PerformWriteAttribute(fieldValue);
                }

                output.Add(fieldValue.ToString().EncloseIfNeeded(encloseString));
            }
            return output.ToArray();
        }
    }
}
