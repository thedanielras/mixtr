using Mixtr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mixtr.Controllers
{
    public class HomeController : Controller
    {
        Models.AppContext db = new Models.AppContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPlaylists()
        {
            List<Playlist> listOfPlaylists;

            try
            {
                IEnumerable<Playlist> playlists = db.Playlists;
                listOfPlaylists = playlists.ToList();
            }
            catch (Exception e)
            {
                return Json(e);
            }

            return Json(listOfPlaylists, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPlaylist(Playlist playlist)
        {
            db.Playlists.Add(playlist);
            db.SaveChanges();

            return RedirectToAction("Index", new { status = "success" });
        }
    }
}