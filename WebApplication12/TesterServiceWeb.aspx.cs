using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class TesterServiceWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.StockSoapClient s = new ServiceReference1.StockSoapClient();
            string l = "en";
            if (RadioButton2.Checked) l= "ar";
            if (RadioButton3.Checked) l= "fr";
            if (RadioButton4.Checked) l= "es";
         
            Label1.Text = s.HelloWorld(l);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.StockSoapClient s = new ServiceReference1.StockSoapClient();
            Label2.Text = s.GetPriceById(TextBox1.Text);
        }
     

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("test");
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

        }

        protected void Button3_Click2(object sender, EventArgs e)
        {

        }
    }
}