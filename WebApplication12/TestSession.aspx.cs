using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class TestSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEcrireSession_Click(object sender, EventArgs e)
        {
            Session["nom"] = TextBox1.Text;
        }

        protected void btnLireSession_Click(object sender, EventArgs e)
        {
            if (Session["nom"] == null)
                Label1.Text = "variable session introuvable";
            else
                Label1.Text = Session["nom"].ToString();
        }
    }
}