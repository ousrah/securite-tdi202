using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class afficherRapport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = Request.QueryString["rapport"];
            if (r != null)
            {
                switch (r)

                    {
                    case "ouvrage":
                        CrystalReport1 cr = new CrystalReport1();
                        cr.SetDatabaseLogon("sa", "P@ssw0rd");
                        CrystalReportViewer1.ReportSource = cr;
                        break;
                    case "editeur":
                        lstEditeurs cr1 = new lstEditeurs();
                        cr1.SetDatabaseLogon("sa", "P@ssw0rd");
                        CrystalReportViewer1.ReportSource = cr1;
                        break;

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("afficherRapport.aspx?rapport=ouvrage");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("afficherRapport.aspx?rapport=editeur");

        }
    }
}