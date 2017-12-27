using Comp214_TeamProject.Controllers;
using System;

namespace Comp214_TeamProject
{
    public partial class Login : System.Web.UI.Page
    {
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Session["LoggedUser"])
            {
                Session["LoggedUser"] = userController.Login("rjdsilv@gmail.com", "Teste1234");
            }
        }
    }
}