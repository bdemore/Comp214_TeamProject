using Comp214_TeamProject.Utils;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;
using System.Web.Routing;

namespace Comp214_TeamProject
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DatabaseUtils.DB_CFG = WebConfigurationManager.AppSettings["DbType"];

            // SQL Server configured as the database.
            if (DatabaseUtils.DB_CFG == "SQLSVR")
            {
                // SQL Server Developer version.
                var cnnStr = WebConfigurationManager.ConnectionStrings["SqlCnnStr"].ConnectionString;

                try
                {
                    // Tries the first connection string.
                    using (SqlConnection cnn = new SqlConnection(cnnStr))
                    {
                        cnn.Open();
                    }
                    DatabaseUtils.CNN_STR = cnnStr;
                }
                catch
                {
                    // SQL Server Express version.
                    DatabaseUtils.CNN_STR = WebConfigurationManager.ConnectionStrings["SqlExprCnnStr"].ConnectionString;
                }
            }
            // Oracle configured as the database.
            else
            {
                // Let's get the Oracle String.
                DatabaseUtils.CNN_STR = WebConfigurationManager.ConnectionStrings["OraCnnStr"].ConnectionString;
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            Session["LoggedUser"] = null;
        }
    }
}