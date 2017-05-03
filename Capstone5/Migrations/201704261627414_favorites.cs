namespace Capstone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteBars",
                c => new
                    {
                        BarsID = c.Int(nullable: false, identity: true),
                        BarName = c.String(),
                        Specials = c.String(),
                        DaytimeBusyness = c.Int(nullable: false),
                        EveningBusyness = c.Int(nullable: false),
                        NightTimeBusyness = c.Int(nullable: false),
                        AdditionalFeatures = c.String(),
                    })
                .PrimaryKey(t => t.BarsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FavoriteBars");
        }
    }
}
