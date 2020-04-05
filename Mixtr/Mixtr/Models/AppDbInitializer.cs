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

            db.Playlists.Add(new Playlist { Name = "Tracy Chapman - Fast Car", Url = "J4WIlBoKTrI", IsSingleVideo = true });
            db.Playlists.Add(new Playlist { Name = "The Cardigans - My Favourite Game Stone Version", Url = "PL3485902CC4FB6C67", IsSingleVideo = false });
            
            base.Seed(db);
        }
    }
}
