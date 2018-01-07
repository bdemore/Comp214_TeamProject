using Comp214_TeamProject.Database.Models;
using System;

namespace Comp214_TeamProject
{
    public partial class ReserveDetails : System.Web.UI.Page
    {
        protected string reserveNumber = "";
        protected string reserveDate = "";
        protected string reserveDueDate = "";

        private BookRental bookRental;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Session["BookRental"])
            {
                Response.Redirect("~/");
            }
            else
            {
                bookRental = (Session["BookRental"] as BookRental);
                reserveNumber = GetBookRentalIdAsString();
                reserveDate = GetDateAsString(bookRental.RentalDate);
                reserveDueDate = GetDateAsString(bookRental.RentalDueDate);
                Session["BookRental"] = null;
                ShowDetails();
            }
        }

        /// <summary>
        /// Stringfy and add zeros to the left of the rental id.
        /// </summary>
        /// <returns>The stringfied rental id.</returns>
        private string GetBookRentalIdAsString()
        {
            return bookRental.PrimaryKey.Key.ToString().PadLeft(15, '0');
        }

        private string GetDateAsString(DateTime date)
        {
            return date.ToString(@"MM\/dd\/yyyy");
        }

        private void ShowDetails()
        {
            ReserveItemRepeater.DataSource = bookRental.Books;
            ReserveItemRepeater.DataBind();
        }
    }
}