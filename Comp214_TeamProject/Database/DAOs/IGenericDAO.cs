using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System.Collections.Generic;

namespace Comp214_TeamProject.Database.DAOs
{
    /// <summary>
    /// Interface containing all the methods that will have to be implementes by any DAO class.
    /// </summary>
    /// <typeparam name="PK">The Model's Primary Key class</typeparam>
    /// <typeparam name="M">The Model class</typeparam>
    public interface IGenericDAO<PK, M>
        where PK : GenericPrimaryKey
        where M : GenericModel<PK>, new()
    {
        /// <summary>
        /// This method will bring all the elements from the given model from the database.
        /// </summary>
        /// <returns>The list of all database elements.</returns>
        List<M> FindAll();

        /// <summary>
        /// This method will bring a page with the number of elements defined by the queryPage parameter.
        /// </summary>
        /// <param name="queryPage">The class containing the pagination definition for the query.</param>
        /// <returns>The list of elements defined by the queryPage parameter.</returns>
        List<M> FindPaged(QueryPage queryPage);
    }
}
