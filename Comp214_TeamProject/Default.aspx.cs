using Comp214_TeamProject.Controllers;
using Comp214_TeamProject.Database.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp214_TeamProject
{
    public partial class _Default : Page
    {
        // The error message.
        protected string message = "";

        // The book controller to be used.
        private IBookController bookController = BookController.GetInstance();
        private IBookRentalController bookRentalController = BookRentalController.GetInstance();

        /// <summary>
        /// Loads the page containing all the selected books.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if ((null == Session["BookList"]) || ("true" == Request.QueryString["showAll"]))
                    {
                        Session["BookList"] = bookController.RetrieveAllBooks();
                    }

                    ShowBooks();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            User user = Session["LoggedUser"] as User;
            List<Book> books = Session["BookList"] as List<Book>;
            BookRental bookRental = bookRentalController.ReserveBook(user, books.Find(tBook => tBook.PrimaryKey.Key == decimal.Parse(button.CommandArgument)));

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
        /// Shows the selected books on the screen.
        /// </summary>
        private void ShowBooks()
        {
            BookRepeater.DataSource = Session["BookList"];
            BookRepeater.DataBind();
        }

        /// <summary>
        /// Shows to the user any unexpecte error that may occur during the database communication.
        /// </summary>
        /// <param name="message">The error message to be shown.</param>
        private void ShowErrorMessage(string message)
        {
            this.message = string.Format("<hr/><b>{0}</b><hr/>", message);
            ErrorPanel.CssClass = "register-error-message";
        }
    }
}