using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System;
using System.Collections.Generic;

namespace Comp214_TeamProject.Database.Models
{
    /// <summary>
    /// Class that will be used to store a book returned from the database table TBUB_BOOKS.
    /// </summary>
    public class Book : GenericModel<DecimalPrimaryKey>
    {
        // The book title.
        public string Title { get; set; }

        // The book description.
        public string Description { get; set; }

        // The book publication date.
        public DateTime? PublicationDate { get; set; }

        // The book edition.
        public decimal Edition { get; set; }

        // Indicates if the book is available or not.
        public bool IsAvailable { get; set; }

        // The nmber of books available for renting.
        public decimal QuantityAvailable { get; set; }

        // The book's main image to be displayed.
        public string ImageUrl01 { get; set; }

        // The book's 2nd image to be displayed.
        public string ImageUrl02 { get; set; }

        // The book's 3rd image to be displayed.
        public string ImageUrl03 { get; set; }

        // The book's 4th image to be displayed.
        public string ImageUrl04 { get; set; }

        // The book's 5th image to be displayed.
        public string ImageUrl05 { get; set; }

        // The date when the book was removed from the renting shelf
        public DateTime? RemoveDate { get; set; }

        // The last time the book was updated.
        public DateTime? LastUpdateDate { get; set; }

        // The book's publisher.
        public Publisher Publisher { get; set; }

        // The book's authors.
        public HashSet<Author> Authors { get; set; }

        // The book's categories.
        public HashSet<Category> Categories { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is Book) && PrimaryKey.Equals((obj as Book).PrimaryKey));
        }

        public override int GetHashCode()
        {
            return PrimaryKey.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Book: {{ PrimaryKey: \"{0}\", Title: \"{1}\" }}", PrimaryKey, Title);
        }
    }
}