namespace Mixtr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToManyRelationBetweenUserAndPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id");
        
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
            DropTable("dbo.Playlists");
        }
    }
}
