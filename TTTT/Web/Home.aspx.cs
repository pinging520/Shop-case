using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TTTT.Modles;
using System.Web.ModelBinding;


namespace TTTT.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            select1();
        }

        public IQueryable<Product> GetProducts([QueryString("id")] string categoryId)
        {
            var _db = new TTTT.Modles.ProductContext();
            IQueryable<Product> query = _db.Products;

            if (categoryId != null)
            {
                query = query.Where(p => (p.ProductName.ToString()).Contains(categoryId));
            }



            return query;

        }

        public string select1()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string name = (Request.QueryString["id"]).ToString();
                string st = "搜尋：" + name;
                return st;
            }
            else
            {

                return "熱門商品介紹.";
            }


        }


    }
}