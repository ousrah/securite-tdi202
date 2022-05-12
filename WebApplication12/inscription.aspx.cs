using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication12
{
    public partial class inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        protected void btnInscription_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress;initial catalog= librairie;user id=sa;password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from [user] where email like @email", cn);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            bool flag = false;
            if (dr.Read())
                    flag = true;
                  
            dr.Close();
            dr = null;


            if (flag)
            {
                lblErrExiste.Visible = true;
                cmd = null;
                cn.Close();
                cn = null;
            }
            else
            {  StringBuilder sb = new StringBuilder();
                foreach (byte b in GetHash(DateTime.Now.ToString()))
                    sb.Append(b.ToString("X2"));
                string hash = sb.ToString();
                cmd.CommandText = "insert into [user] (email, nom, password, valide, hash) values (@email, @nom,@pwd,0, @hash)";
            //    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@nom", txtNom.Text);
                cmd.Parameters.AddWithValue("@pwd", txtPwd1.Text);
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.ExecuteNonQuery();
                cmd = null;
                cn.Close();
                cn = null;


              

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ismotdi202@outlook.com");
                mail.Subject = "inscription ismo tétouan";
                mail.Body = "votre inscription à <b> ismo.ma</b> à été effectuée avec succés, cliquez sur le lien suivant pour valider votre inscription <br /><br /><a href = 'https://localhost:44362/validationInscription.aspx?email=" + txtEmail.Text + "&hash="+hash+"' > https://localhost:44362/validationInscription.aspx?email=" + txtEmail.Text + "&hash=" + hash + "</ a > ";


                mail.IsBodyHtml = true;


                mail.To.Add(txtEmail.Text);

                SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587);

              smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ismotdi202@outlook.com", "ISMO@2022");

                try
                {
                    smtp.Send(mail);
                    Response.Redirect("Inscriptioneffectuee.aspx");

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }



            }





        }
    }
}