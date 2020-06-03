using System.Data.Entity;

namespace Mixtr.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Playlist> Playlists { get; set; }
        DbSet<Post> Posts { get; set; }
        int SaveChanges();
        void Dispose();
    }
}