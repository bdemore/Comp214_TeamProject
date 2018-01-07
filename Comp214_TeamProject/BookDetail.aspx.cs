using Comp214_TeamProject.Controllers;
using Comp214_TeamProject.Database.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Comp214_TeamProject
{
    public partial class BookDetail : System.Web.UI.Page
    {
        // The book controller to be used.
        private IBookController bookController = BookController.GetInstance();
        private IBookRentalController bookRentalController = BookRentalController.GetInstance();

        // The error message.
        protected string message = "";

        // The book selected by the user.
        protected Book book;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((null != Session["BookList"]) && (null != Request.QueryString["isbn"]))
            {
                book = bookController.RetrieveBookDetails(Request.QueryString["isbn"], Session["BookList"] as List<Book>);
                if (!IsPostBack)
                {
                    FillBookDetails();
                }
            }
            else
            {
                Response.Redirect("~/");
            }
        }

        /// <summary>
        /// Performs the book reservation if the user hasn't any pending reservations.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            User user = Session["LoggedUser"] as User;
            List<Book> books = Session["BookList"] as List<Book>;
            BookRental bookRental = bookRentalController.ReserveBook(user, books.Find(tBook => tBook.PrimaryKey.Key == decimal.Parse(Request.QueryString["isbn"])));

            if (null == bookRental)
            {
                ShowErrorMessage(string.Format("{0}, you have a pending rental. Please, return the book(s) in your possession before renting again!", user.FirstName));
            }
            else
            {
                Session["BookRental"] = bookRental;
                Response.Redirect("~/ReserveDetails");
            }
        }

        /// <summary>
        /// This event will only be available for admin staff and will allow an administrator to update the book information.
        /// If the user is not an administrator, he / she is logged out and redirected to the login page.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void BookUpdateButton_Click(object sender, EventArgs e)
        {
            if ((null != Session["LoggedUser"]) && (Session["LoggedUser"] as User).Role == "ADMIN")
            {
                Response.Redirect("~/UpdateBook?isbn=" + Request.QueryString["isbn"]);
            }
            else
            {
                Session["LoggedUser"] = null;
                Response.Redirect("~/Login");
            }
        }

        /// <summary>
        /// Changes the large image based on the thumbnail clicked.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void BookUrl02ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            ImageButton button = sender as ImageButton;

            switch (button.CommandArgument)
            {
                case "1":
                    BookImage.ImageUrl = book.ImageUrl01;
                    break;

                case "2":
                    BookImage.ImageUrl = book.ImageUrl02;
                    break;

                case "3":
                    BookImage.ImageUrl = book.ImageUrl03;
                    break;

                case "4":
                    BookImage.ImageUrl = book.ImageUrl04;
                    break;

                case "5":
                    BookImage.ImageUrl = book.ImageUrl05;
                    break;
            }
        }

        ///// <summary>
        ///// Shows to the user any unexpecte error that may occur during the database communication.
        ///// </summary>
        ///// <param name="message">The error message to be shown.</param>
        private void ShowErrorMessage(string message)
        {
            this.message = string.Format("<hr/><b>{0}</b><hr/>", message);
            ErrorPanel.CssClass = "register-error-message";
        }

        /// <summary>
        /// Fills all the book details on the page.
        /// </summary>
        private void FillBookDetails()
        {
            // Setting Image 01
            BookImage.AlternateText = book.Title;
            BookImage.ImageUrl = book.ImageUrl01;

            // Setting Thumbnail Image 01
            if (!string.IsNullOrEmpty(book.ImageUrl01))
            {
                BookUrl01ImageButton.AlternateText = "Thumbnail 1";
                BookUrl01ImageButton.ImageUrl = book.ImageUrl01;
            }

            // Setting Thumbnail Image 02
            if (!string.IsNullOrEmpty(book.ImageUrl02))
            {
                BookUrl02ImageButton.AlternateText = "Thumbnail 2";
                BookUrl02ImageButton.ImageUrl = book.ImageUrl02;
            }

            // Setting Thumbnail Image 03
            if (!string.IsNullOrEmpty(book.ImageUrl03))
            {
                BookUrl03ImageButton.AlternateText = "Thumbnail 3";
                BookUrl03ImageButton.ImageUrl = book.ImageUrl03;
            }

            // Setting Thumbnail Image 04
            if (!string.IsNullOrEmpty(book.ImageUrl04))
            {
                BookUrl04ImageButton.AlternateText = "Thumbnail 4";
                BookUrl04ImageButton.ImageUrl = book.ImageUrl04;
            }

            // Setting Thumbnail Image 05
            if (!string.IsNullOrEmpty(book.ImageUrl05))
            {
                BookUrl05ImageButton.AlternateText = "Thumbnail 5";
                BookUrl05ImageButton.ImageUrl = book.ImageUrl05;
            }

            // Binds the authors to its repeater
            BookAuthorRepeater.DataSource = book.Authors;
            BookAuthorRepeater.DataBind();

            // Binds the categories to its repeater
            BookCategoryRepeater.DataSource = book.Categories;
            BookCategoryRepeater.DataBind();
        }
    }
}