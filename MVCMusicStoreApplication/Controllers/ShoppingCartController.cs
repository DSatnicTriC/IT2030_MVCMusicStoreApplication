using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;
using MVCMusicStoreApplication.Models.ViewModels;

namespace MVCMusicStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        MVCMusicStoreDB dbContext = new MVCMusicStoreDB();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            ShoppingCartViewModel vm = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetCartTotal()
            };
            return View(vm);
        }

        // GET: /ShoppingCart/AddtoCart
        public ActionResult AddToCart(int id)
        {
            //id is AlbumId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        // Post: AjaxCall
        public ActionResult RemoveFromCart(int id)
        {
            //id == RecordId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            string albumTitle = dbContext.Carts.SingleOrDefault(c => c.RecordId == id)?.AlbumSelected.Title;
            int itemCnt = cart.RemoveFromCart(id);

            ShoppingCartRemoveViewModel vm = new ShoppingCartRemoveViewModel
            {
                ItemCount = itemCnt,
                DeleteId = id,
                CartTotal = cart.GetCartTotal(),
                Message = albumTitle + " has been removed from the cart "
            };

            return Json(vm);
        }
    }
}