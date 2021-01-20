using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RadSaGreskama2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Server.ClearError();
            //Ovdje je preporuèljivo staviti kod za spremanje
            //globalnih grešaka u log datoteku ili bazu podataka

            Response.Redirect("~/GlobalneGreske/Index");
        }
    }
}
