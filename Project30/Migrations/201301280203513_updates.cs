namespace Project30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "UserProfile_UserId", c => c.Int());
            AddForeignKey("dbo.Message", "UserProfile_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Message", "UserProfile_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Message", new[] { "UserProfile_UserId" });
            DropForeignKey("dbo.Message", "UserProfile_UserId", "dbo.UserProfile");
            DropColumn("dbo.Message", "UserProfile_UserId");
            DropTable("dbo.UserProfile");
        }
    }
}
