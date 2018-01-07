using Comp214_TeamProject.Database;
using Comp214_TeamProject.Database.DAOs;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System;
using System.Data;

namespace Comp214_TeamProject.Controllers
{
    /// <summary>
    /// Class containing all the necessary business logic do deal with Book Rentals.
    /// </summary>
    public class BookRentalController : GenericController<BookRentalController>, IBookRentalController
    {
        // The book rental DAO.
        private IBookRentalDAO bookRentalDAO = BookRentalDAO.GetInstance();

        /// <summary>
        /// Default constructor to be used by the Singleton.
        /// </summary>
        private BookRentalController()
        {
        }

        /// <see cref="IBookRentalController"/>
        public BookRental ReserveBook(User user, Book book)
        {
            QueryParameter userId = new QueryParameter(paramPrefix + "UserId", user.PrimaryKey.Key, Database.DbType.DECIMAL, 11, ParameterDirection.Input);
            QueryParameter bookIsbn = new QueryParameter(paramPrefix + "BookIsbn", book.PrimaryKey.Key, Database.DbType.DECIMAL, 13, ParameterDirection.Input);
            QueryParameter rentalId = new QueryParameter(paramPrefix + "RentalId", Database.DbType.DECIMAL, 15, ParameterDirection.Output);
            QueryParameter rentalDate = new QueryParameter(paramPrefix + "RentalDate", Database.DbType.DATE, 0, ParameterDirection.Output);
            QueryParameter rentalDueDate = new QueryParameter(paramPrefix + "RentalDueDate", Database.DbType.DATE, 0, ParameterDirection.Output);

            bookRentalDAO.ExecuteProcedure("SPUB_RESERVE_BOOK", userId, bookIsbn, rentalId, rentalDate, rentalDueDate);

            if (int.Parse(rentalId.Value.ToString()) > 0)
            {
                return new BookRental()
                {
                    PrimaryKey = new DecimalPrimaryKey(decimal.Parse(rentalId.Value.ToString())),
                    RentalDate = (DateTime)rentalDate.Value,
                    RentalDueDate = (DateTime)rentalDueDate.Value,
                    User = user,
                    Books = { book }
                };
            }

            return null;
        }
    }
}