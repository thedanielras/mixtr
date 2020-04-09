namespace Mixtr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTheIsSingleTrackColumnOnPlaylistsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Playlists", "IsSingleTrack");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlists", "IsSingleTrack", c => c.Boolean(nullable: false));
        }
    }
}
