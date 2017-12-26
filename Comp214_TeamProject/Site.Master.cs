using Comp214_TeamProject.Controllers;
using System;
using System.Web.UI;

namespace Comp214_TeamProject
{
    public partial class SiteMaster : MasterPage
    {
        // The controller to handle book operations.
        private IBookController bookController = BookController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Searches books by the criteria selected by the user.
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event arguments.</param>
        protected void SearchByButton_Click(object sender, EventArgs e)
        {
            Session["BookList"] = bookController.RetrivedBooksByFilter(SearchByDropDownList.SelectedItem.Value, SearchByTextBox.Text);
            Response.Redirect("~/");
        }
    }
}