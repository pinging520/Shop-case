using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTTT.Modles;
using TTTT.logic;
using System.Diagnostics;

namespace TTTT.Web
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];  //get網頁id= 字串列並存入 rawid
            int productId;

            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))  //如果id不是空直 && url抓來的(string)id是否可以轉會為int類別
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));  //將id轉為int並傳去 AddCart()裡
                }
            }



            Response.Redirect("ShoppingCart.aspx");
        }
    }
}