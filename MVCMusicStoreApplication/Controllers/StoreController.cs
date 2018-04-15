using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        private MVCMusicStoreDB db = new MVCMusicStoreDB();

        // GET: Store/Browse
        public ActionResult Browse()
        {
            var genres = db.Genres.ToList();
            return View(genres);
        }

        // GET: Store/Index/5
        public ActionResult Index(int id)
        {
            var albums = db.Albums.Where(x => x.GenreId == id).OrderBy(x => x.Title).ToList();
            return View(albums);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var album = db.Albums.Include(x => x.Artist).First(x => x.AlbumId == id);
            return View(album);
        }

        // GET: Store/AddToCart/5
        // Note: this will be moved to a ShoppingCart Controller
        public ActionResult AddToCart(int id)
        {
            return Content("Added To Cart Album id " + id);
        }
    }
}