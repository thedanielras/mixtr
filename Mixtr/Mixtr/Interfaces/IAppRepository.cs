using System;
using System.Collections.Generic;

namespace Mixtr.Models
{
    public interface IAppRepository : IDisposable
    {
        void AddPost(Post p);
        List<PostViewModel> GetPostsViews();
        void IncrementLikes(int postId);
        void DecrementLikes(int postId);
    }
}