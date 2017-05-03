namespace Capstone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedfavorites : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FavoriteBars", "DaytimeBusyness");
            DropColumn("dbo.FavoriteBars", "EveningBusyness");
            DropColumn("dbo.FavoriteBars", "NightTimeBusyness");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FavoriteBars", "NightTimeBusyness", c => c.Int(nullable: false));
            AddColumn("dbo.FavoriteBars", "EveningBusyness", c => c.Int(nullable: false));
            AddColumn("dbo.FavoriteBars", "DaytimeBusyness", c => c.Int(nullable: false));
        }
    }
}
