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

        // GET: 
        public ActionResult Index()
        {
            //return View();
            return null;
        }

        // GET: 
        public ActionResult Details()
        {
            //return View();
            return null;
        }
    }
}