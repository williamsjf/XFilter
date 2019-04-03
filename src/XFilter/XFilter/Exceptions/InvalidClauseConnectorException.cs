using System;
using XFilter.Query;

namespace XFilter.Exceptions
{
    public class InvalidClauseConnectorException : Exception
    {
        public InvalidClauseConnectorException(Connector connector)
            : base($"The clause connector {connector} is not supported")
        {
        }
    }
}
