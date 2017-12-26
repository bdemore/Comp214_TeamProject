using Comp214_TeamProject.Database.Models;
using System.Collections.Generic;

namespace Comp214_TeamProject.Controllers
{
    /// <summary>
    /// Interface containing all the methods that must be implemented by a BookController.
    /// </summary>
    interface IBookController
    {
        /// <summary>
        /// Method responsible for retrieving all the books from the databae.
        /// </summary>
        /// <returns>The list of all books contained on the database.</returns>
        List<Book> RetrieveAllBooks();

        /// <summary>
        /// Method responsible for retrieving from the database the books that matches the user's selected criteria.
        /// </summary>
        /// <param name="filterType">The filter type: ISBN, Author or Title</param>
        /// <param name="filterValue">The filter value to be used.</param>
        /// <returns>The list of books found or an empty list if no books are found.</returns>
        List<Book> RetrivedBooksByFilter(string filterType, string filterValue);
    }
}
