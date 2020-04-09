using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mixtr.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}