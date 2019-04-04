namespace XFilter.Query
{
    public class Clause
    {
        public string Member { get; set; }
        public object Value { get; set; }

        public Operator Operator { get; set; }
        public Connector Connector { get; set; }

        public string DataHandlerName { get; set; }
    }
}
