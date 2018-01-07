using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System;
using System.Collections.Generic;

namespace Comp214_TeamProject.Database.Models
{
    /// <summary>
    /// Class that will be used to store a book rental returned from the database table TBUB_BOOK_RENTAL.
    /// </summary>
    public class BookRental : GenericModel<DecimalPrimaryKey>
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public BookRental()
        {
            Books = new List<Book>();
        }

        // The date the rental was made.
        public DateTime RentalDate { get; set; }

        // The maximum date to return the rental.
        public DateTime RentalDueDate { get; set; }

        // The date the rental was returned
        public DateTime RentalReturnDate { get; set; }

        // The user that performed the rental.
        public User User { get; set; }

        // The books related to this rental.
        public List<Book> Books { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is BookRental) && PrimaryKey.Equals((obj as BookRental).PrimaryKey));
        }

        public override int GetHashCode()
        {
            return PrimaryKey.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("BookRental: {{ PrimaryKey: \"{0}\", RentalDate: \"{1}\", RentalDueDate: \"{2}\", RentalReturnDate: \"{3}\", User: \"{4}\" }}",
                PrimaryKey, RentalDate.ToShortDateString(), RentalDueDate.ToShortDateString(), RentalReturnDate.ToShortDateString(), User.PrimaryKey);
        }

    }
}