using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mixtr.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
}