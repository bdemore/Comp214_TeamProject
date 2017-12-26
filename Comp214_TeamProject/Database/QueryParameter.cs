namespace Comp214_TeamProject.Database
{
    /// <summary>
    /// Class built to deal with query parameters.
    /// </summary>
    public class QueryParameter
    {
        // The parameter name.
        public string Name { get; }

        // The parameter value.
        public object Value { get; }

        public QueryParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}