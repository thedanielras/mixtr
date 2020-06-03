using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mixtr.Models
{
    public class AppRepository : IAppRepository
    {
        private IApplicationDbContext _dbContext = new ApplicationDbContext();

        public void AddPost(Post p)
        {
            _dbContext.Posts.Add(p);
            _dbContext.SaveChanges();
        }

        public List<PostViewModel> GetPostsViews()
        {
            IEnumerable<Post> posts = null;
            
            try
            {
                posts = _dbContext.Posts.Include(p => p.Playlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

            return listOfPosts;
        }

        public void IncrementLikes(int postId)
        {
            var post = _dbContext.Posts.SingleOrDefault(p => p.Id == postId);
            if (post != null)
            {
                post.LikesCount++;
            }

            _dbContext.SaveChanges();
        }

        public void DecrementLikes(int postId)
        {
            var post = _dbContext.Posts.SingleOrDefault(p => p.Id == postId);
            if (post != null)
            {
                post.LikesCount--;
            }

            _dbContext.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}