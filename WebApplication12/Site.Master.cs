using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["passport"] != null)
            {
                if (Session["passport"].ToString() != "ok")
                    Response.Redirect("login.aspx");
            }
            else
                Response.Redirect("login.aspx");

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["passport"] = "";
            HttpCookie c = new HttpCookie("ismo");
            if (c != null)
            {
                c["a"] = "";
                c["b"] = "";
                c["c"] = "";
                c["d"] = "";
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            Response.Redirect("login.aspx");
        }
    }
}