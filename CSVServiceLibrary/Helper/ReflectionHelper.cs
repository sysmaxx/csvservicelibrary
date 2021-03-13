using System;
using System.Reflection;

namespace CSVServiceLibrary.Helper
{
    internal static class ReflectionHelper
    {
        public static Type GetPropertyType(PropertyInfo prop)
        {
            var propertyType = prop.PropertyType;
            return Nullable.GetUnderlyingType(propertyType) ?? propertyType;
        }
    }
}
