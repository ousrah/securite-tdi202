using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace WebApplication12
{
    public partial class validationInscription : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress;initial catalog= librairie;user id=sa;password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("update [user] set valide = 1 where email like @email and hash like @hash", cn);
            cmd.Parameters.AddWithValue("@email", Request.QueryString["email"]);
            cmd.Parameters.AddWithValue("@hash", Request.QueryString["hash"]);

            cmd.ExecuteNonQuery();
            cmd = null;
            cn.Close();
            cn = null;

            Response.Redirect("login.aspx");

        }
    }
}