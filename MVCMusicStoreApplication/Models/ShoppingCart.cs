using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class ShoppingCart
    {
        private string ShoppingCartId;
        private const string CartSessionKey = "CartId";

        MVCMusicStoreDB db = new MVCMusicStoreDB();

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            string cartId;
            if (context.Session[CartSessionKey] == null)
            {
                //Create a cart id and add it to the session variable
                cartId = Guid.NewGuid().ToString();
                context.Session[CartSessionKey] = cartId;
            }
            else
            {
                //retrieve cart id
                cartId = context.Session[CartSessionKey].ToString();
            }

            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public decimal GetCartTotal()
        {
            decimal? total = (from cartItems in db.Carts
                where cartItems.CartId == ShoppingCartId
                select cartItems.AlbumSelected.Price * (int?) cartItems.Count).Sum();
            return total ?? decimal.Zero;
        }

        public void AddToCart(int id)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.AlbumId == id);

            //CartItem does not exist in the db => add CartItem to db
            if (cartItem == null)
            {
                Album album = db.Albums.SingleOrDefault(a => a.AlbumId == id);
                cartItem = new Cart
                {
                    CartId = ShoppingCartId,
                    AlbumId = id,
                    AlbumSelected = album,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
            }
            else
            {
                //CartItem exists already in db => Update count
                cartItem.Count++;
            }

            db.SaveChanges();
        }
    }
}