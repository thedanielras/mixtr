using Mixtr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

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
            IEnumerable<Post> posts = db.Posts.Include(p => p.Playlist);

            try
            {
                (posts as IQueryable<Post>).Include(p => p.UserWhoPosted);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<PostViewModel> listOfPosts = posts.Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    LikesCount = p.LikesCount,
                    Playlist = p.Playlist,
                    UserName = p.UserWhoPosted?.UserName
                }
            ).ToList();

            try
            {
                string json = JsonConvert.SerializeObject(listOfPosts);
                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(500);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.UserId = User.Identity.GetUserId();
                db.Posts.Add(post);
                db.SaveChanges();
            }

            return RedirectToAction("Index", new {status = "success"});
        }
    }
}