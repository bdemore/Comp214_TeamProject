using Comp214_TeamProject.Database.DAOs;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System.Collections.Generic;

namespace Comp214_TeamProject.Controllers
{
    /// <summary>
    /// Controller class that will have the necessary business logic to deal with Books.
    /// </summary>
    public class BookController : GenericController<BookController>, IBookController
    {
        // The book dao to be accessed.
        private IBookDAO bookDAO = BookDAO.GetInstance();

        private BookController()
        {
        }

        /// <see cref="IUserController"/>
        public List<Book> RetrieveAllBooks()
        {
            return bookDAO.FindAll();
        }

        /// <see cref="IUserController"/>
        public List<Book> RetrivedBooksByFilter(string filterType, string filterValue)
        {
            return bookDAO.FindBooksByFilter(filterType, filterValue);
        }

        /// <see cref="IUserController"/>
        public Book RetrieveBookDetails(string isbn, List<Book> books)
        {
            return books.Find(b => b.PrimaryKey.Equals(new DecimalPrimaryKey(decimal.Parse(isbn))));
        }
    }
}