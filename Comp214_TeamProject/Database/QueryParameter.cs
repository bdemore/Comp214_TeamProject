using System.Data;

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
        public object Value { get; set; }

        // The parameter direction.
        public ParameterDirection Direction { get; }

        // The parameter Database type.
        public DbType DbType { get; }

        public int DbSize { get; }

        /// <summary>
        /// Constructor passing the parameter name, type, size, and direction. In this constructor the value will be set later.
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="dbType">The paramater database type</param>
        /// <param name="dbSize">The parameter database size</param>
        /// <param name="direction">The parameter direction.</param>
        public QueryParameter(string name, DbType dbType, int dbSize, ParameterDirection direction)
        {
            Name = name;
            Value = null;
            DbType = dbType;
            DbSize = dbSize;
            Direction = direction;
        }

        /// <summary>
        /// Constructor passing the parameter name, value, type, size, and direction. In this constructor the value will be set later.
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The value to be used.</param>
        /// <param name="dbType">The paramater database type</param>
        /// <param name="dbSize">The parameter database size</param>
        /// <param name="direction">The parameter direction.</param>
        public QueryParameter(string name, object value, DbType dbType, int dbSize, ParameterDirection direction)
        {
            Name = name;
            Value = value;
            DbType = dbType;
            DbSize = dbSize;
            Direction = direction;
        }

        /// <summary>
        /// Constructor passing the parameter name and the parameter value. For this constructor de default paramter direction is Input.
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value.</param>
        public QueryParameter(string name, object value)
        {
            Name = name;
            Value = value;
            Direction = ParameterDirection.Input;
            DbSize = -1;
            DbType = DbType.NONE;
        }

        public bool IsInput()
        {
            return Direction == ParameterDirection.Input;
        }

        public bool IsOutput()
        {
            return Direction == ParameterDirection.Output;
        }

        public bool IsInputOutput()
        {
            return Direction == ParameterDirection.InputOutput;
        }

        public bool IsReturnValue()
        {
            return Direction == ParameterDirection.ReturnValue;
        }
    }
}