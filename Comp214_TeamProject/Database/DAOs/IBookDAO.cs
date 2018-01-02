using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System.Collections.Generic;

namespace Comp214_TeamProject.Database.DAOs
{
    /// <summary>
    /// Interface containing all the methods to be implemented by the BookDAO.
    /// </summary>
    public interface IBookDAO : IGenericDAO<DecimalPrimaryKey, Book>
    {
        /// <summary>
        /// Searchs for books on the database that matches the given criteria.
        /// </summary>
        /// <param name="filterType">The type of filter: ISBN, Author or Title</param>
        /// <param name="filterValue">The value to be used on the filter</param>
        /// <returns>The list of books found or an empty list if no books are found.</returns>
        List<Book> FindBooksByFilter(string filterType, string filterValue);
    }
}
