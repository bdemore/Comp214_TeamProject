using System;

namespace Comp214_TeamProject.Database.Exceptions
{
    /// <summary>
    /// Class that will encapsulate any application's database thrown exception.
    /// </summary>
    [Serializable()]
    public class DatabaseException : Exception
    {
        /// <summary>
        /// Creates a new instance of DatabaseException
        /// </summary>
        public DatabaseException() : base() { }

        /// <summary>
        /// Creates a new instance of DatabaseException using an user defined message.
        /// </summary>
        /// <param name="message">The message to be shown by the exception.</param>
        public DatabaseException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance of DatabaseException using an user defined message and the exception that caused it.
        /// </summary>
        /// <param name="message">The message to be shown by the exception.</param>
        /// <param name="cause">The exception's cause.</param>
        public DatabaseException(string message, Exception cause) : base(message, cause) { }
    }
}