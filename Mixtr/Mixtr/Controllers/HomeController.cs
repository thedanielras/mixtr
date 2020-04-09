using Mixtr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Mixtr.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
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

        [HttpGet]
        public ActionResult GetPosts()
        {
            List<Post> listOfPosts;

            IEnumerable<Post> posts = db.Posts.Include(p => p.Playlist);
            listOfPosts = posts.ToList();

            return Json(listOfPosts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPost(Post post)
        {

            if(ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }            

            return RedirectToAction("Index", new { status = "success" });
        }
    }
}