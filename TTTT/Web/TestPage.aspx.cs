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
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public IQueryable<Product> GetProducts([QueryString("id")] string categoryId)  //public IQueryable<Product> GetProducts(網誌id)
        {
            var _db = new TTTT.Modles.ProductContext();
            IQueryable<Product> query = _db.Products;
            
            if(categoryId != null)
            {
                query = query.Where(p => (p.ProductName.ToString()).Contains(categoryId));
            }
            
            
           
            return query;

        }


    }
}