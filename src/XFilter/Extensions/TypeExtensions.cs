using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace XFilter
{
    public static class TypeExtensions
    {
        //public static Type GetTypeObject(this object obj)
        //{
        //    if (obj is int)
        //        return typeof(int);

        //    if (obj is string)
        //        return typeof(string);

        //    if (obj is bool)
        //        return typeof(bool);

        //    if (obj is DateTime)
        //        return typeof(DateTime);

        //    return null;
        //}

        /// <summary>
        /// Build a new object with all the items from dictionaty.
        /// </summary>
        /// <param name="ruleTargets"></param>
        /// <returns></returns>
        public static object BuildTargetObject(this Dictionary<string, object> fields)
        {
            if (fields == null)
                throw new ArgumentNullException(nameof(fields));

            var listNullValues = fields.Where(x => x.Value == null).ToDictionary(x => x.Key, x => x.Value);
            if (listNullValues != null)
            {
                foreach (var nullItem in listNullValues)
                    fields.Remove(nullItem.Key);
            }

            var properties = fields.Select(x => new DynamicProperty(x.Key, x.Value.GetType())).ToList();

            Type type = DynamicClassFactory.CreateType(properties);
            var target = Activator.CreateInstance(type);

            properties.ForEach(x => type.GetProperty(x.Name)
                .SetValue(target,
                fields.First(k => k.Key == x.Name).Value, null));

            return target;
        }
    }
}
