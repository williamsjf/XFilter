using System;

namespace XFilter.Extensions
{
    public static class TypeExtensions
    {
        public static Type GetTypeObject(this object obj)
        {
            if (obj is int)
                return typeof(int);

            if (obj is string)
                return typeof(string);

            if (obj is bool)
                return typeof(bool);

            if (obj is DateTime)
                return typeof(DateTime);

            return null;
        }
    }
}
