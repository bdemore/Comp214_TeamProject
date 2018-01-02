using Comp214_TeamProject.Database;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace Comp214_TeamProject.Utils
{
    /// <summary>
    /// Utiliy Class to be used by database objects
    /// </summary>
    public class DatabaseUtils
    {
        public static string CNN_STR = "";
        public static string DB_CFG = "";

        /// <summary>
        /// Ceates a Publisher with the given parameters.
        /// </summary>
        /// <param name="publisherId">The publisher identification.</param>
        /// <param name="publisherName">The publiher name.</param>
        /// <param name="publisherCreateDate">The publisher create date.</param>
        /// <returns></returns>
        public static Publisher CreatePublisher(decimal publisherId, string publisherName, DateTime publisherCreateDate)
        {
            var publisher = new Publisher();

            publisher.PrimaryKey = new DecimalPrimaryKey(publisherId);
            publisher.Name = publisherName;
            publisher.CreateDate = publisherCreateDate;

            return publisher;
        }

        /// <summary>
        /// Returns a Category from a string separated by the given separator. The Category fields must be in the following order:
        /// <ol>
        ///     <li>PrimaryKey</li>
        ///     <li>Name</li>
        ///     <li>CreateDate</li>
        /// </ol>
        /// </summary>
        /// <param name="separatedString">The string formated with the separator.</param>
        /// <param name="separator">The separator to be used</param>
        /// <returns>The category created</returns>
        public static DM CreateDomainModelFromStringWithSeparator<DM>(string separatedString, char[] separator) where DM : DomainModel<DecimalPrimaryKey>
        {
            var domainModel = ReflectionUtils.ConstructDefault<DM>();
            var domainModelFields = separatedString.Split(separator);

            domainModel.PrimaryKey = new DecimalPrimaryKey(decimal.Parse(domainModelFields[0]));
            domainModel.Name = domainModelFields[1];
            domainModel.CreateDate = DateTime.ParseExact(domainModelFields[2], "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture);

            return domainModel;
        }

        /// <summary>
        /// Safely returns a decinal even when the field has a null value on the database.
        /// </summary>
        /// <param name="dr">The data reader</param>
        /// <param name="columnName">The database column name</param>
        /// <returns></returns>
        public static decimal SafeGetDecimal(DbDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetDecimal(dr.GetOrdinal(columnName));
            }

            return default(decimal);
        }

        /// <summary>
        /// Safely returns a string even when the field has a null value on the database.
        /// </summary>
        /// <param name="dr">The data reader</param>
        /// <param name="columnName">The database column name</param>
        /// <returns></returns>
        public static string SafeGetString(DbDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetString(dr.GetOrdinal(columnName));
            }

            return "";
        }

        /// <summary>
        /// Safely returns a boolean even when the field has a null value on the database.
        /// </summary>
        /// <param name="dr">The data reader</param>
        /// <param name="columnName">The database column name</param>
        /// <returns></returns>
        public static bool SafeGetBoolean(DbDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                if (IsOracle())
                {
                    return SafeGetDecimal(dr, columnName) == 1 ? true : false;
                }
                else
                {
                    return dr.GetBoolean(dr.GetOrdinal(columnName));
                }
            }

            return default(bool);
        }

        /// <summary>
        /// Safely returns a DateTime even when the field has a null value on the database.
        /// </summary>
        /// <param name="dr">The data reader</param>
        /// <param name="columnName">The database column name</param>
        /// <returns></returns>
        public static DateTime? SafeGetDateTime(DbDataReader dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                return dr.GetDateTime(dr.GetOrdinal(columnName));
            }

            return null;
        }

        /// <summary>
        /// Checks if the configuration is set to Oracle server.
        /// </summary>
        /// <returns>true if the configuration is set to Oracle.</returns>
        public static bool IsOracle()
        {
            return "ORACLE" == DB_CFG;
        }

        /// <summary>
        /// Adds a parameter to the SQL Server command passed as parameter.
        /// </summary>
        /// <param name="command">The command to be used.</param>
        /// <param name="parameter">The parameter to be passed.</param>
        public static void AddCommandParameter(SqlCommand command, QueryParameter parameter)
        {
            if (null != parameter)
            {
                if (parameter.IsInput())
                {
                    if (null != parameter.Value)
                    {
                        if (parameter.DbSize > 0)
                        {
                            command.Parameters.Add(parameter.Name, DbTypeToSqlDbType(parameter.DbType), parameter.DbSize).Value = parameter.Value;
                        }
                        else
                        {
                            command.Parameters.AddWithValue(parameter.Name, parameter.Value);
                        }
                    }
                    else
                    {
                        command.Parameters.AddWithValue(parameter.Name, DBNull.Value);
                    }
                }
                else if (parameter.IsInputOutput() || parameter.IsOutput())
                {
                    if (parameter.DbType == Database.DbType.DECIMAL)
                    {
                        command.Parameters.Add(parameter.Name, DbTypeToSqlDbType(parameter.DbType)).Precision = (byte)parameter.DbSize;
                        command.Parameters[parameter.Name].Direction = parameter.Direction;
                    }
                    else
                    {
                        command.Parameters.Add(parameter.Name, DbTypeToSqlDbType(parameter.DbType), parameter.DbSize);
                        command.Parameters[parameter.Name].Direction = parameter.Direction;
                    }

                }
            }
        }

        /// <summary>
        /// Adds a parameter to the Oracle command passed as parameter.
        /// </summary>
        /// <param name="command">The command to be used.</param>
        /// <param name="parameter">The parameter to be passed.</param>
        public static void AddCommandParameter(OracleCommand command, QueryParameter parameter)
        {
            if (null != parameter)
            {
                if (parameter.IsInput())
                {
                    if (null != parameter.Value)
                    {
                        if (parameter.DbSize > 0)
                        {
                            command.Parameters.Add(parameter.Name, DbTypeToOracleDbType(parameter.DbType), parameter.DbSize).Value = parameter.Value;
                        }
                        else
                        {
                            command.Parameters.Add(parameter.Name, parameter.Value);
                        }
                    }
                    else
                    {
                        command.Parameters.Add(parameter.Name, DBNull.Value);
                    }
                }
                else if (parameter.IsInputOutput() || parameter.IsOutput())
                {
                    if (parameter.DbType == Database.DbType.DECIMAL)
                    {
                        command.Parameters.Add(parameter.Name, DbTypeToOracleDbType(parameter.DbType), parameter.Direction).Precision = (byte) parameter.DbSize;
                    }
                    else
                    {
                        command.Parameters.Add(parameter.Name, DbTypeToOracleDbType(parameter.DbType), parameter.DbSize).Direction = parameter.Direction;
                    }
                }
            }
        }

        /// <summary>
        /// Converts the given DbType to a SqlDbType.
        /// </summary>
        /// <param name="dbType">The type to be converted.</param>
        /// <returns>The converted Type.</returns>
        private static SqlDbType DbTypeToSqlDbType(Database.DbType dbType)
        {
            switch(dbType)
            {
                case Database.DbType.BIT:
                    return SqlDbType.Bit;

                case Database.DbType.CHAR:
                    return SqlDbType.Char;

                case Database.DbType.DATE:
                    return SqlDbType.Date;

                case Database.DbType.DATETIME:
                    return SqlDbType.DateTime2;

                case Database.DbType.DECIMAL:
                    return SqlDbType.Decimal;

                case Database.DbType.VARCHAR:
                    return SqlDbType.VarChar;
            }

            return SqlDbType.VarChar;
        }

        /// <summary>
        /// Converts the given DbType to an OracleDbType.
        /// </summary>
        /// <param name="dbType">The type to be converted.</param>
        /// <returns>The converted Type.</returns>
        private static OracleDbType DbTypeToOracleDbType(Database.DbType dbType)
        {
            switch (dbType)
            {
                case Database.DbType.BIT:
                    return OracleDbType.Decimal;

                case Database.DbType.CHAR:
                    return OracleDbType.Char;

                case Database.DbType.DATE:
                    return OracleDbType.Date;

                case Database.DbType.DATETIME:
                    return OracleDbType.TimeStamp;

                case Database.DbType.DECIMAL:
                    return OracleDbType.Decimal;

                case Database.DbType.VARCHAR:
                    return OracleDbType.Varchar2;
            }

            return OracleDbType.Varchar2;
        }
    }
}