using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;

namespace Comp214_TeamProject.Database.DAOs
{
    /// <summary>
    /// Interface containing all the methods to be implemented by the UserDAO.
    /// </summary>
    interface IUserDAO : IGenericDAO<DecimalPrimaryKey, User>
    {
    }
}
