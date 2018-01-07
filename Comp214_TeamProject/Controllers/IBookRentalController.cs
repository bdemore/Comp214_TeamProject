using Comp214_TeamProject.Database.Models;

namespace Comp214_TeamProject.Controllers
{
    interface IBookRentalController
    {
        /// <summary>
        /// Performs the rent of one book for the given user.
        /// </summary>
        /// <param name="user">The user that is renting the book</param>
        /// <param name="book">The book rented</param>
        /// <returns>The book rental information if successful. null otherwise.</returns>
        BookRental ReserveBook(User user, Book book);
    }
}
