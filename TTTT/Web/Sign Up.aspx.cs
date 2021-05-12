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
    public partial class Sign_Up : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-PR4VPFA\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
        SqlCommand cmd = null;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Text1_Textchang(object sender, EventArgs e)
        {
            string[] testname =new string[] { "@", "!","=","$",",","~","%","^" };

            for(int i=0;i<testname.Length;i++)
            {
                if (TextBox1.Text.IndexOf(testname[i]) > 0)
                {
                    ErrorMessage.Text = "帳號內禁用符號";
                    break;
                }
                else { ErrorMessage.Text = ""; }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == TextBox2.Text && TextBox1.Text != "" && TextBox2.Text != "")
            {

                try
                {
                    conn.Open();
                    string Sid = "Select * From account where id = '" + TextBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sid, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        ErrorMessage.Text = "帳號已被使用";
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        string ssql = "Insert Into account (id,name)";
                        ssql += "Values ('" + TextBox1.Text + "','" + TextBox2.Text + "')";

                        SqlCommand cmd1 = new SqlCommand(ssql, conn);
                        cmd1.ExecuteNonQuery();
                        Response.Redirect("Home.aspx");
                    }



                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message;
                }
                finally
                {

                    
                    conn.Close();
                   
                }
            }
            else
            {
                ErrorMessage.Text = "密碼確認錯誤";
            }
        }
    }
}