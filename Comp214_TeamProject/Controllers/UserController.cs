using System.Data;
using Comp214_TeamProject.Database;
using Comp214_TeamProject.Database.DAOs;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;

namespace Comp214_TeamProject.Controllers
{
    /// <summary>
    /// Class containing all the necessary business logic do deal with Users.
    /// </summary>
    public class UserController : GenericController<UserController>, IUserController
    {
        // The user dao.
        private IUserDAO userDAO = UserDAO.GetInstance();

        /// <summary>
        /// Default constructor to be used by the Singleton.
        /// </summary>
        private UserController()
        {
        }

        /// <see cref="IUserController"/>
        public User Login(string email, string password)
        {
            QueryParameter userEmail = new QueryParameter(paramPrefix + "UserEmail", email, Database.DbType.VARCHAR, 64, ParameterDirection.Input);
            QueryParameter userPassword = new QueryParameter(paramPrefix + "UserPassword", password, Database.DbType.CHAR, 64, ParameterDirection.Input);
            QueryParameter userId = new QueryParameter(paramPrefix + "UserId", Database.DbType.DECIMAL, 11, ParameterDirection.Output);
            QueryParameter userRole = new QueryParameter(paramPrefix + "UserRole", Database.DbType.VARCHAR, 5, ParameterDirection.Output);
            QueryParameter userFirstName = new QueryParameter(paramPrefix + "UserFirstName", Database.DbType.VARCHAR, 32, ParameterDirection.Output);
            QueryParameter userLastName = new QueryParameter(paramPrefix + "UserLastName", Database.DbType.VARCHAR, 64, ParameterDirection.Output);

            userDAO.ExecuteProcedure("SPUB_LOGIN", userEmail, userPassword, userId, userRole, userFirstName, userLastName);

            if (int.Parse(userId.Value.ToString()) > 0)
            {
                return new User()
                {
                    PrimaryKey = new DecimalPrimaryKey(decimal.Parse(userId.Value.ToString())),
                    Email = email,
                    Role = userRole.Value.ToString(),
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
            QueryParameter userRole = new QueryParameter(paramPrefix + "UserRole", Database.DbType.VARCHAR, 5, ParameterDirection.Output);

            userDAO.ExecuteProcedure("SPUB_REGISTER", userEmail, userPassword, userFirstName, userLastName, userId, userRole);

            if (int.Parse(userId.Value.ToString()) > 0)
            {
                return new User()
                {
                    PrimaryKey = new DecimalPrimaryKey(decimal.Parse(userId.Value.ToString())),
                    Email = email,
                    Role = userRole.Value.ToString(),
                    FirstName = firstName,
                    LastName = lastName
                };
            }

            return null;
        }

        /// <see cref="IUserController"/>
        public User UpdateProfile(string email, string firstName, string lastName)
        {
            QueryParameter userEmail = new QueryParameter(paramPrefix + "UserEmail", email, Database.DbType.VARCHAR, 64, ParameterDirection.Input);
            QueryParameter userFirstName = new QueryParameter(paramPrefix + "UserFirstName", firstName, Database.DbType.VARCHAR, 32, ParameterDirection.Input);
            QueryParameter userLastName = new QueryParameter(paramPrefix + "UserLastName", lastName, Database.DbType.VARCHAR, 64, ParameterDirection.Input);
            QueryParameter userId = new QueryParameter(paramPrefix + "UserId", Database.DbType.DECIMAL, 11, ParameterDirection.Output);
            QueryParameter userRole = new QueryParameter(paramPrefix + "UserRole", Database.DbType.VARCHAR, 5, ParameterDirection.Output);

            userDAO.ExecuteProcedure("SPUB_UPDATE_PROFILE", userEmail, userFirstName, userLastName, userId, userRole);

            if (int.Parse(userId.Value.ToString()) > 0)
            {
                return new User()
                {
                    PrimaryKey = new DecimalPrimaryKey(decimal.Parse(userId.Value.ToString())),
                    Email = email,
                    Role = userRole.Value.ToString(),
                    FirstName = firstName,
                    LastName = lastName
                };
            }

            return null;
        }
    }
}