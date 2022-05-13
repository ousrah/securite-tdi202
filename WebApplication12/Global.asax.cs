using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication12
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code qui s’exécute au démarrage de l’application
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }

        void Application_End(object sender, EventArgs e)
        {
            // Code qui s’exécute au fermeture de l’application
          
        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code qui s’exécute au démarerage de la session
           
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code qui s’exécute au fermeture de la session

        }

    }
}