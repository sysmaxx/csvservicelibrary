using CSVServiceLibrary.Attributes;
using CSVServiceLibrary.Models;
using System;
using System.Linq;

namespace CSVServiceLibrary.Helper
{
    internal static class CsvPropertyHelper
    {
        public static IOrderedEnumerable<CsvPropertyAttributeMap> GetPropertiesAttributeMap<T>()
        {
            return typeof(T).GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(CsvIndexPositionAttribute)) &&
                       !Attribute.IsDefined(prop, typeof(CsvIgnoreFieldAttribute)))
                .Select(prop => new CsvPropertyAttributeMap { Propertie = prop, Attributes = Attribute.GetCustomAttributes(prop) })
                .OrderBy(propAttr => ((CsvIndexPositionAttribute)propAttr.Attributes.First(attr => attr is CsvIndexPositionAttribute))?.IndexPostion);
        }
    }
}
