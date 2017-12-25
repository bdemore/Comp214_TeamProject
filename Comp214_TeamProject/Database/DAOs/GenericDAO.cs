using Comp214_TeamProject.Database.Exceptions;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using Comp214_TeamProject.Patterns;
using Comp214_TeamProject.Utils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Comp214_TeamProject.Database.DAOs
{
    /// <summary>
    /// Class that will be implemented by all the DAO classes.
    /// </summary>
    /// <typeparam name="PK">The Model's Primary Key class</typeparam>
    /// <typeparam name="M">The Model class</typeparam>
    public abstract class GenericDAO<PK, M, TS> : Singleton<TS>, IGenericDAO<PK, M>
        where PK : GenericPrimaryKey
        where M : GenericModel<PK>, new()
    {
        // SQL Server connection type.
        protected const string CNN_TYPE_SQLSVR = "SQLSVR";

        // The database connection string for SQL Server.
        protected string cnnStr = DatabaseUtils.CNN_STR;

        /// <see cref="IGenericDAO{PK, M}"/>
        public List<M> FindAll()
        {
            if (CNN_TYPE_SQLSVR == DatabaseUtils.DB_CFG)
            {
                return FindByQuerySqlServer(BuildFindAllSqlServerQueryString());
            }
            else
            {
                return FindByQueryOracle(BuildFindAllOracleQueryString());
            }
        }

        /// <see cref="IGenericDAO{PK, M}"/>
        public List<M> FindPaged(QueryPage queryPage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method that will be implemented by chikd classes in order to provide the correct query
        /// for the FindAll method.
        /// </summary>
        /// <returns>The build query string.</returns>
        protected abstract string BuildFindAllSqlServerQueryString();

        /// <summary>
        /// Method that will be implemented by chikd classes in order to provide the correct query
        /// for the FindAll method.
        /// </summary>
        /// <returns>The build query string.</returns>
        protected abstract string BuildFindAllOracleQueryString();

        /// <summary>
        /// Method that will crete an object using the given SqlDataReader
        /// </summary>
        /// <returns></returns>
        protected abstract M CreateObjectFromDataReader(DbDataReader dataReader);

        /// <summary>
        /// Finds all the database objects for the given type using SQL Server database.
        /// </summary>
        /// <param name="queryString">The query to be executed</param>
        /// <exception cref="DatabaseException">If an error occurs when trying to retrieve the data from the database.</exception>
        /// <returns>The list of objects populated with the database data.</returns>
        private List<M> FindByQuerySqlServer(string queryString)
        {
            var objectList = new List<M>();

            try
            {
                using (SqlConnection cnn = new SqlConnection(cnnStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                    {
                        cnn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    objectList.Add(CreateObjectFromDataReader(reader));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("An error has occurred when searching for records on a SQL Server database.", ex);
            }

            return objectList;
        }

        /// <summary>
        /// Finds all the database objects for the given type using SQL Server database.
        /// </summary>
        /// <param name="queryString">The query to be executed</param>
        /// <exception cref="DatabaseException">If an error occurs when trying to retrieve the data from the database.</exception>
        /// <returns>The list of objects populated with the database data.</returns>
        private List<M> FindByQueryOracle(string queryString)
        {
            var objectList = new List<M>();

            try
            {
                using (OracleConnection cnn = new OracleConnection(cnnStr))
                {
                    using (OracleCommand cmd = new OracleCommand(queryString, cnn))
                    {
                        cnn.Open();

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    objectList.Add(CreateObjectFromDataReader(reader));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("An error has occurred when searching for records on a SQL Server database.", ex);
            }

            return objectList;
        }
    }
}