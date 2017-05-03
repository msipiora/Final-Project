namespace Capstone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavoriteBars", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.FavoriteBars", "ApplicationUser_Id");
            AddForeignKey("dbo.FavoriteBars", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriteBars", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FavoriteBars", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.FavoriteBars", "ApplicationUser_Id");
        }
    }
}
