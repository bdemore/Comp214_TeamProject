using Comp214_TeamProject.Controllers;
using System;
using System.Web.UI;

namespace Comp214_TeamProject
{
    public partial class _Default : Page
    {
        // The book controller to be used.
        private IBookController bookController = BookController.GetInstance();

        /// <summary>
        /// Loads the page containing all the selected books.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((null == Session["BookList"]) || ("true" == Request.QueryString["showAll"]))
                {
                    Session["BookList"] = bookController.RetrieveAllBooks();
                }
            }

            ShowBooks();
        }

        /// <summary>
        /// Shows the selected books on the screen.
        /// </summary>
        private void ShowBooks()
        {
            BookRepeater.DataSource = Session["BookList"];
            BookRepeater.DataBind();
        }
    }
}