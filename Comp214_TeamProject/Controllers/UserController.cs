using System.Data;
using Comp214_TeamProject.Database;
using Comp214_TeamProject.Database.DAOs;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using Comp214_TeamProject.Utils;

namespace Comp214_TeamProject.Controllers
{
    public class UserController : GenericController<UserController>, IUserController
    {
        // The user dao.
        private IUserDAO userDAO = UserDAO.GetInstance();

        // The parameter prefix.
        private string paramPrefix = DatabaseUtils.IsOracle() ? "" : "@";

        private UserController()
        {
        }

        /// <see cref="IUserController"/>
        public User Login(string email, string password)
        {
            QueryParameter userEmail = new QueryParameter(paramPrefix + "UserEmail", email, Database.DbType.VARCHAR, 64, ParameterDirection.Input);
            QueryParameter userPassword = new QueryParameter(paramPrefix + "UserPassword", password, Database.DbType.CHAR, 64, ParameterDirection.Input);
            QueryParameter userId = new QueryParameter(paramPrefix + "UserId", Database.DbType.DECIMAL, 11, ParameterDirection.Output);
            QueryParameter userFirstName = new QueryParameter(paramPrefix + "UserFirstName", Database.DbType.VARCHAR, 32, ParameterDirection.Output);
            QueryParameter userLastName = new QueryParameter(paramPrefix + "UserLastName", Database.DbType.VARCHAR, 64, ParameterDirection.Output);

            userDAO.ExecuteProcedure("SPUB_LOGIN", userEmail, userPassword, userId, userFirstName, userLastName);

            if (int.Parse(userId.Value.ToString()) > 0)
            {
                return new User()
                {
                    PrimaryKey = new DecimalPrimaryKey(decimal.Parse(userId.Value.ToString())),
                    Email = email,
                    FirstName = userFirstName.Value.ToString(),
                    LastName = userLastName.Value.ToString()
                };
            }

            return null;
        }

        /// <see cref="IUserController"/>
        public User Register(string email, string password, string firstName, string lastName)
        {
            QueryParameter userEmail = new QueryParameter(paramPrefix + "UserEmail", email, Database.DbType.VARCHAR, 64, ParameterDirection.Input);
            QueryParameter userPassword = new QueryParameter(paramPrefix + "UserPassword", password, Database.DbType.CHAR, 64, ParameterDirection.Input);
            QueryParameter userFirstName = new QueryParameter(paramPrefix + "UserFirstName", firstName, Database.DbType.VARCHAR, 32, ParameterDirection.Input);
            QueryParameter userLastName = new QueryParameter(paramPrefix + "UserLastName", lastName, Database.DbType.VARCHAR, 64, ParameterDirection.Input);
            QueryParameter userId = new QueryParameter(paramPrefix + "UserId", Database.DbType.DECIMAL, 11, ParameterDirection.Output);

            userDAO.ExecuteProcedure("SPUB_REGISTER", userEmail, userPassword, userFirstName, userLastName, userId);

            if (int.Parse(userId.Value.ToString()) > 0)
            {
                return new User()
                {
                    PrimaryKey = new DecimalPrimaryKey(decimal.Parse(userId.Value.ToString())),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };
            }

            return null;
        }
    }
}