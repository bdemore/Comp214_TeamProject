using Comp214_TeamProject.Controllers;
using System;

namespace Comp214_TeamProject
{
    public partial class Register : System.Web.UI.Page
    {
        // The User Controller.
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Session["LoggedUser"])
            {
                Session["LoggedUser"] = userController.Register("bruno@demore.com", "Teste1234", "Bruno", "Demore");
            }
        }
    }
}