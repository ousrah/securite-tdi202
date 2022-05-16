using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace WebApplication12
{
    public partial class login : System.Web.UI.Page
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["ismo"];
            if (c != null)
            {
                string email = "";
                string pwd = "";
                string mac = "";
               myLib.DecryptSym(System.Convert.FromBase64String(c["a"]), myLib.cle, myLib.iv);

                if (c["a"] != null) nom = myLib.DecryptSym(System.Convert.FromBase64String(c["a"]), myLib.cle, myLib.iv);
                if (c["b"] != null) email = myLib.DecryptSym(System.Convert.FromBase64String(c["b"]), myLib.cle, myLib.iv);
                if (c["c"] != null) pwd = myLib.DecryptSym(System.Convert.FromBase64String(c["c"]), myLib.cle, myLib.iv);
                if (c["d"] != null) mac = myLib.DecryptSym(System.Convert.FromBase64String(c["d"]), myLib.cle, myLib.iv);

                if (email != "" && pwd != "" && mac==getClientMac())
                {
                   bool flag =  connexion(email, pwd);
                    if (flag)
                              Response.Redirect("default.aspx");
                                    

                }

            }

        }
        string nom = "";
  
        private bool connexion(string email, string pwd)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress;initial catalog= librairie;user id=sa;password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from [user] where valide=1 and email like @email", cn);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader dr = cmd.ExecuteReader();
            bool flag = false;
            if (dr.Read())
                if (dr["password"].ToString() == pwd)
                {
                    nom = dr["nom"].ToString();
                    flag = true;
                    Session["passport"] = "ok";
                }
            dr.Close();
            dr = null;
            cmd = null;
            cn.Close();
            cn = null;
            return flag;
        }

        protected void btnConnection_Click(object sender, EventArgs e)
        {

          bool  flag =  connexion(txtEmail.Text, txtPwd.Text);
            if (flag)
            {
                if (chksession.Checked)
                {
                    HttpCookie c = new HttpCookie("ismo");


                

                    c["a"] = Convert.ToBase64String(myLib.EncryptSym(nom, myLib.cle, myLib.iv));
                  
                    c["b"] = Convert.ToBase64String(myLib.EncryptSym(txtEmail.Text, myLib.cle, myLib.iv));

                    c["c"] = Convert.ToBase64String(myLib.EncryptSym(txtPwd.Text, myLib.cle, myLib.iv));
                    c["d"] = Convert.ToBase64String(myLib.EncryptSym(getClientMac(), myLib.cle, myLib.iv));  
                    c.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(c);
                }
                Response.Redirect("default.aspx");
            }
            else
                lblErrConnection.Visible = true;


        }
        public string getClientMac()
        {
            try
            {
                string userip = Request.UserHostAddress;
                string strClientIP = Request.UserHostAddress.ToString().Trim();
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");
                if (mac_src == "0")
                {
                    if (userip == "127.0.0.1")
                        Response.Write("visited Localhost!");
                    else
                        Response.Write("the IP from" + userip + "" + "<br>");
                    return "";
                }

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                string mac_dest = "";

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }

                return mac_dest;
                
             }
            catch (Exception err)
            {
                return "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        /*  foreach(string a in Request.ServerVariables)
                        {
                            Response.Write(a + " --> " + Request.ServerVariables[a] + "<br>");

                        }
        */
            Response.Write(Request.ServerVariables["REMOTE_ADDR"]);
            Response.Write(Request.UserHostAddress);
        }
    }
}