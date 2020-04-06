using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Mixtr.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LikesCount { get; set; } = 0;
        public int? PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}