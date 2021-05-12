using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTTT.Modles;


namespace TTTT
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

                
                LoginStr();
                SignUp();
                Usertest1();
                Usertest();
        }

        public IQueryable<Category> GetCategories()
        {
            var _db = new TTTT.Modles.ProductContext();
            IQueryable<Category> query = _db.Categories;
            return query;
        }

        public string LoginStr()//注意这里必须要有返回值，否则将会发生运行时错误
        {
            if (Session["IDnumber"] != null)
            {
                return " LogOut";
            }
            else
            {
                return " LogIn";
            }

                
        }
        public string SignUp()//注意这里必须要有返回值，否则将会发生运行时错误
        {
            if (Session["IDnumber"] != null)
            {
                string User = Session["IDnumber"].ToString();
                return " " + User;
            }
            else
            {
                return " Sign Up";
            }  
        }
        public string Usertest1()
        {
            if (Session["IDnumber"] != null)
            {
                string SignUP = "UserPage";
                return SignUP;
            }
            else
            {
                string SignUP = "Sign Up";
                return SignUP;
            }


        }
        public string Usertest()
        {
            if (Session["IDnumber"] != null)
            {
                return "LogOut";
            }
            else
            { 
                return "Login";
            }
               
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Home?id=" + TextBox1.Text);

        }

        

    }
}