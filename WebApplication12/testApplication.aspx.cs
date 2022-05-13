using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class testApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEcrireApplication_Click(object sender, EventArgs e)
        {
            Application["nom"] = TextBox1.Text;
        }

        protected void btnLireApplication_Click(object sender, EventArgs e)
        {
            if (Application["nom"] == null)
                Label1.Text = "variable application introuvable";
            else

                Label1.Text = Application["nom"].ToString();
        }
    }
}