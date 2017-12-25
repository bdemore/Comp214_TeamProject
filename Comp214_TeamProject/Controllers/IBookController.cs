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
    }
}
