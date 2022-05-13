using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class testCookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEcrireCookie_Click(object sender, EventArgs e)
        {
            HttpCookie c = new HttpCookie("maCookie");
            c["nom"] = TextBox1.Text;
            c["prenom"] = TextBox2.Text;
            c.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(c);
        }

        protected void btnLireCookie_Click(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["maCookie"];
            if (c == null)
                Label1.Text = "cookie introuvable";
            else

                Label1.Text = c["nom"].ToString() + " " + c["prenom"].ToString();

        }

        protected void btnSupprimerCookie_Click(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["maCookie"];
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);
        }
    }
}