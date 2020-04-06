using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mixtr.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<AppContext>
    {
        protected override void Seed(AppContext db)
        {
            db.Posts.Add(new Post() { Title = "Test 1", Playlist = new Playlist() { Url = "J4WIlBoKTrI", IsSingleTrack = true } });
            db.Posts.Add(new Post() { Title = "Test 2", Playlist = new Playlist() { Url = "PL3485902CC4FB6C67", IsSingleTrack = false } });

            base.Seed(db);
        }
    }
}
