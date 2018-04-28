using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;
using MVCMusicStoreApplication.Models.ViewModels;

namespace MVCMusicStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
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

        // GET: /ShoppingCart/AddtoCart/5
        public ActionResult AddToCart(int id)
        {
            //id is AlbumId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        // Post: AjaxCall
        public ActionResult RemoveFromCart()
        {
            return View();
        }
    }
}