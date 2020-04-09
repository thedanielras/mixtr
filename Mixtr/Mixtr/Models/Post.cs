using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mixtr.Models
{
    public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [ScaffoldColumn(false)]
        public int LikesCount { get; set; } = 0;
        [ScaffoldColumn(false)]
        public int? PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}