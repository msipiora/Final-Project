namespace Capstone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entireweek : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FridayBars",
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
            
            CreateTable(
                "dbo.SaturdayBars",
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
            
            CreateTable(
                "dbo.SundayBars",
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
            
            CreateTable(
                "dbo.ThursdayBars",
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
            DropTable("dbo.ThursdayBars");
            DropTable("dbo.SundayBars");
            DropTable("dbo.SaturdayBars");
            DropTable("dbo.FridayBars");
        }
    }
}
