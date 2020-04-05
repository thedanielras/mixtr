using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixtr.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsSingleVideo { get; set; }
    }
}