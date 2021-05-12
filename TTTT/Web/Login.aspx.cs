using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TTTT.Web
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-PR4VPFA\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string sSql2 = "Select * From account Where id = '" + TextBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(sSql2, conn);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["name"].ToString() == TextBox2.Text)
                    {
                        ErrorMessage.Text = "登入成功";
                        Session.Add("IDnumber", TextBox1.Text);
                        //HttpContext.Current.Session["test"] = HttpContext.Current.User.Identity.Name;

                        Response.Redirect("Home.aspx"); ////連線
                    }
                    else
                    {
                        ErrorMessage.Text = "密碼有誤";
                    }
                }
                else
                {
                    ErrorMessage.Text = "查無此帳號";
                }
               
                

            }
            catch (Exception ex) { ErrorMessage.Text = "伺服器錯誤，請稍後再登"; }
            finally
            {


                conn.Close();

            }

        }
    }
}