using System;
using XFilter.Query;

namespace XFilter.Exceptions
{
    public class UnsupportedOperatorException : Exception
    {
        public UnsupportedOperatorException(Operator @operator)
            : base($"The operator '{@operator}' is not supported")
        {

        }

        public UnsupportedOperatorException(Operator @operator, Type type)
             : base($"The operator '{@operator}' is not supported for the type {type.Name}")
        {
        }
    }
}
