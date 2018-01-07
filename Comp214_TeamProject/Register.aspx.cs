using Comp214_TeamProject.Controllers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp214_TeamProject
{
    public partial class Register : System.Web.UI.Page
    {
        // The erro message.
        protected string message = "";

        // The User Controller.
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            FirstNameTextBox.Focus();
        }

        /// <summary>
        /// Captures the register button click event and registers the user to the database in case it doesn't exist.
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event arguments.</param>
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (null == Session["LoggedUser"])
            {
                Session["LoggedUser"] = userController.Register(EmailTextBox.Text, PasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text);

                if (null == Session["LoggedUser"])
                {
                    ShowErrorMessage("User already registered.");
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }

        /// <summary>
        /// Cancels the operation and redirects the user to the home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClearPageTextBoxes(this);
            Response.Redirect("~/");
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

        /// <summary>
        /// Clears all the text boxes for the given controls.
        /// </summary>
        /// <param name="control">The control to be cleaned</param>
        private void ClearPageTextBoxes(Control control)
        {
            foreach (Control currControl in control.Controls)
            {
                if (currControl is TextBox)
                {
                    (currControl as TextBox).Text = "";
                }
                else
                {
                    ClearPageTextBoxes(currControl);
                }
            }
        }
    }
}