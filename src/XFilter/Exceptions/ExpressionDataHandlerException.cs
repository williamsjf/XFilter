using System;

namespace XFilter.Exceptions
{
    public class ExpressionDataHandlerException : Exception
    {
        public ExpressionDataHandlerException(Type type)
            :base($"No data handler was found for type '{type.Name}'")
        {
        }
    }
}
