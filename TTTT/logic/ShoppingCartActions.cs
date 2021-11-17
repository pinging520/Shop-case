using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTTT.Modles;

namespace TTTT.logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; } //購物車ID

        private ProductContext _db = new ProductContext(); //連接產品

        public const string CartSessionKey = "CartId";  //常數設定

        
        public void AddToCart(int id) //根據資料傳達
        {
            ShoppingCartId = GetCartId();

            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
          c => c.CartId == ShoppingCartId && c.ProductId == id);

            if (cartItem == null)
            {
                // 如果沒有購物車，新增                 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = _db.Products.SingleOrDefault(
                   p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++; //如果購物車有此商品 數量++
            }

            _db.SaveChanges(); //存回DB
        }

        public void Dispose() //資料處置
        {
            if (_db != null)
            {
                _db.Dispose(); //如果_DB有東西就清除
                _db = null;
            }
        }


        public string GetCartId()
        {
            //個人購物車ID
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid(); //給隨機ID
                    HttpContext.Current.Session[CartSessionKey] = tempCartId;
                }

            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }



    }
}
