using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XFilter.Exceptions;

namespace XFilter.DataExpressionHandlers
{
    public class ExpressionDataHandlerFactory
    {
        /// <summary>
        /// Creates a data handler for the informed type.
        /// </summary>
        /// <param name="ruleClause"></param>
        /// <param name="dataHandlers"></param>
        /// <returns></returns>
        public static IExpressionDataHandler BuildDataHandler(Type type)
        {
            var dataHandlers = GetDefaultHandlers();

            var targetHandler = dataHandlers.FirstOrDefault(x => x.Type == type);
            if (targetHandler == null)
                throw new ExpressionDataHandlerException(type);

            return targetHandler;
        }

        public static IExpressionDataHandler BuildDataHandler(string dataHandlerName)
        {
            var defaultHandlers = GetDefaultHandlers();


            //if (dataHandlerName != null)
            //{
            //    var newHandlers = new List<IExpressionDataHandler>();
            //    for (int i = 0; i < dataHandlers.Count; i++)
            //    {
            //        var externalHandler = customHandlers.FirstOrDefault(x => x.Type == dataHandlers[i].Type);
            //        if (externalHandler != null)
            //            dataHandlers[i] = externalHandler;
            //        else
            //            newHandlers.Add(externalHandler);
            //    }

            //    dataHandlers.AddRange(newHandlers);
            //}

            var classNamespace = typeof(IExpressionDataHandler).Namespace;

            string assemblyQualifiedName = Assembly.CreateQualifiedName(classNamespace, "");

            return null;
        }

        private static IEnumerable<IExpressionDataHandler> GetDefaultHandlers()
        {
            var classNamespace = typeof(IExpressionDataHandler).Namespace;

            var dataHandlers = AppDomain.CurrentDomain.GetAssemblies()
                  .SelectMany(s => s.GetTypes().Where(x => x.Namespace == classNamespace && x.IsClass))
                  .Where(p => typeof(IExpressionDataHandler).IsAssignableFrom(p));

            foreach (var dataHandler in dataHandlers)
            {
               yield return (IExpressionDataHandler)Activator.CreateInstance(dataHandler);
            }
        }
    }
}
