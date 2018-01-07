using Comp214_TeamProject.Controllers;
using Comp214_TeamProject.Database.Models;
using Comp214_TeamProject.Database.Models.PrimaryKeys;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp214_TeamProject
{
    public partial class MyAccount : System.Web.UI.Page
    {
        // The erro message.
        protected string message = "";

        // The User Controller.
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Session["LoggedUser"])
            {
                Response.Redirect("~/Login");
            }
            else
            {
                if (!IsPostBack)
                {
                    FirstNameTextBox.Focus();
                    User user = Session["LoggedUser"] as User;
                    EmailTextBox.Text = user.Email;
                    FirstNameTextBox.Text = user.FirstName;
                    LastNameTextBox.Text = user.LastName;
                }
            }
        }

        protected void UpdateProfileButton_Click(object sender, EventArgs e)
        {
            if (null != Session["LoggedUser"])
            {

                User currUser = Session["LoggedUser"] as User;
                User prevUser = new User()
                {
                    PrimaryKey = new DecimalPrimaryKey(currUser.PrimaryKey.Key),
                    Role = currUser.Role,
                    Email = currUser.Email,
                    FirstName = currUser.FirstName,
                    LastName = currUser.LastName
                };

                Session["LoggedUser"] = userController.UpdateProfile(EmailTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text);

                if (null == Session["LoggedUser"])
                {
                    Session["LoggedUser"] = prevUser;
                    ShowErrorMessage(string.Format("An error has occurred when updating {0}'s profile.", prevUser.FirstName));
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