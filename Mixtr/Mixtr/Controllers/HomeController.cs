using Mixtr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Mixtr.Utils;
using Newtonsoft.Json;

namespace Mixtr.Controllers
{
    public class HomeController : Controller
    {
        private IAppRepository _repository;

        public HomeController()
        {
            _repository = new AppRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPosts()
        {
            var listOfPosts = _repository.GetPostsViews();

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
            bool isStatusOk = false;

            if (ModelState.IsValid)
            {
                post.UserId = User.Identity.GetUserId();
                bool urlValidationResult = YoutubeUrlValidator.CheckIfValid(post.Playlist.Url);
                if (urlValidationResult)
                {
                    string youtubeId = YoutubeUrlValidator.GetId(post.Playlist.Url);
                    if (youtubeId != null) post.Playlist.Url = youtubeId;
                    isStatusOk = true;

                    _repository.AddPost(post);
                }
            }

            return RedirectToAction("Index", new {status = isStatusOk ? "success" : "fail"});
        }

        [Authorize]
        [HttpPost]
        public void AddLike(int postId)
        {
            _repository.IncrementLikes(postId);
        }

        public void RemoveLike(int postId)
        {
            _repository.DecrementLikes(postId);
        }
    }
}