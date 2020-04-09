namespace Mixtr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IsSingleTrack = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        LikesCount = c.Int(nullable: false),
                        PlaylistId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId)
                .Index(t => t.PlaylistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.Posts", new[] { "PlaylistId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Playlists");
        }
    }
}
