using Comp214_TeamProject.Database;
using Comp214_TeamProject.Database.DAOs;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System;
using System.Collections.Generic;
using System.Data;

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

        public void UpdateBook(
                decimal isbn,
                string title,
                string description,
                DateTime publicationDate,
                decimal edition,
                bool isAvailable,
                decimal quantityAvailable,
                decimal pages,
                string url01,
                string url02,
                string url03,
                string url04,
                string url05
        )
        {
            QueryParameter bookIsbn = new QueryParameter(paramPrefix + "BookIsbn", isbn, Database.DbType.DECIMAL, 13, ParameterDirection.Input);
            QueryParameter bookTitle = new QueryParameter(paramPrefix + "BookTitle", title, Database.DbType.VARCHAR, 128, ParameterDirection.Input);
            QueryParameter bookDescription = new QueryParameter(paramPrefix + "BookDescription", description, Database.DbType.VARCHAR, 2048, ParameterDirection.Input);
            QueryParameter bookPublicationDate = new QueryParameter(paramPrefix + "BookPublicationDate", publicationDate, Database.DbType.DATE, 0, ParameterDirection.Input);
            QueryParameter bookEdition = new QueryParameter(paramPrefix + "BookEdition", edition, Database.DbType.DECIMAL, 5, ParameterDirection.Input);
            QueryParameter bookIsAvailable = new QueryParameter(paramPrefix + "BookIsAvailable", isAvailable ? 1 : 0, Database.DbType.BIT, 0, ParameterDirection.Input);
            QueryParameter bookQuantityAvailable = new QueryParameter(paramPrefix + "BookQuantityAvailable", quantityAvailable, Database.DbType.DECIMAL, 5, ParameterDirection.Input);
            QueryParameter bookPages = new QueryParameter(paramPrefix + "BookPages", pages, Database.DbType.DECIMAL, 5, ParameterDirection.Input);
            QueryParameter bookImageUrl01 = new QueryParameter(paramPrefix + "BookImageUrl01", url01, Database.DbType.VARCHAR, 255, ParameterDirection.Input);
            QueryParameter bookImageUrl02 = new QueryParameter(paramPrefix + "BookImageUrl02", url02, Database.DbType.VARCHAR, 255, ParameterDirection.Input);
            QueryParameter bookImageUrl03 = new QueryParameter(paramPrefix + "BookImageUrl03", url03, Database.DbType.VARCHAR, 255, ParameterDirection.Input);
            QueryParameter bookImageUrl04 = new QueryParameter(paramPrefix + "BookImageUrl04", url04, Database.DbType.VARCHAR, 255, ParameterDirection.Input);
            QueryParameter bookImageUrl05 = new QueryParameter(paramPrefix + "BookImageUrl05", url05, Database.DbType.VARCHAR, 255, ParameterDirection.Input);

            bookDAO.ExecuteProcedure(
                    "SPUB_UPDATE_BOOK",
                    bookIsbn,
                    bookTitle,
                    bookDescription,
                    bookPublicationDate,
                    bookEdition,
                    bookIsAvailable,
                    bookQuantityAvailable,
                    bookPages,
                    bookImageUrl01,
                    bookImageUrl02,
                    bookImageUrl03,
                    bookImageUrl04,
                    bookImageUrl05
            );
        }
    }
}