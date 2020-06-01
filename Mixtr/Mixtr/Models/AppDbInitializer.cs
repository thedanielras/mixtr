using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mixtr.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            db.Posts.Add(new Post() { Title = "Test 1", Playlist = new Playlist() { Url = "J4WIlBoKTrI" } });
            db.Posts.Add(new Post() { Title = "Test 2", Playlist = new Playlist() { Url = "PL3485902CC4FB6C67" } });

            base.Seed(db);
        }
    }
}
