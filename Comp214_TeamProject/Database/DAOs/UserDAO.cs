using System.Data.Common;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using Comp214_TeamProject.Utils;

namespace Comp214_TeamProject.Database.DAOs
{
    /// <summary>
    /// Class to manage data access to the TBUB_USERS table.
    /// </summary>
    public class UserDAO : GenericDAO<DecimalPrimaryKey, User, UserDAO>, IUserDAO
    {
        private UserDAO()
        {
        }

        /// <see cref="GenericDAO{PK, M}"/>
        protected override string BuildFindAllOracleQueryString() => BuildFindAllQueryString();

        /// <see cref="GenericDAO{PK, M}"/>
        protected override string BuildFindAllSqlServerQueryString() => BuildFindAllQueryString();

        /// <see cref="GenericDAO{PK, M}"/>
        protected override User CreateObjectFromDataReader(DbDataReader dr)
        {
            // The user password won't be set for security reasons.
            var user = new User()
            {
                PrimaryKey = new DecimalPrimaryKey(DatabaseUtils.SafeGetDecimal(dr, "USER_ID")),
                Email = DatabaseUtils.SafeGetString(dr, "USER_EMAIL"),
                FirstName = DatabaseUtils.SafeGetString(dr, "USER_FIRST_NAME"),
                LastName = DatabaseUtils.SafeGetString(dr, "USER_LAST_NAME"),
                CreateDate = DatabaseUtils.SafeGetDateTime(dr, "USER_CREATE_DATE")
            };

            return user;
        }

        /// <summary>
        /// Build the select string for finding all the database users.
        /// </summary>
        /// <returns></returns>
        private string BuildFindAllQueryString() =>
            "select   * " +
            "from     TBUB_USERS " +
            "order by USER_ID";
    }
}
