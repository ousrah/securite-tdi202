using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class server_variables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*foreach (string a in Request.ServerVariables)
            {
                Response.Write(a+" = " +  Request.ServerVariables[a] +"<br>");

            }*/

            Response.Write("l'adress ip du client est : " + Request.ServerVariables["REMOTE_ADDR"]);
        
        
        }
    }
}