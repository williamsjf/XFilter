using System;

namespace XFilter.Exceptions
{
    public class IncompatibleClauseException : Exception
    {
        public IncompatibleClauseException(string message)
            :base(message)
        {

        }
    }
}
