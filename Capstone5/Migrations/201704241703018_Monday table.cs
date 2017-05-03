namespace Capstone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mondaytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MondayBars",
                c => new
                    {
                        BarsID = c.Int(nullable: false, identity: true),
                        BarName = c.String(),
                        WeeklySpecials = c.String(),
                        DaytimeBusyness = c.Int(nullable: false),
                        EveningBusyness = c.Int(nullable: false),
                        NightTimeBusyness = c.Int(nullable: false),
                        AdditionalFeatures = c.String(),
                    })
                .PrimaryKey(t => t.BarsID);
            
            DropTable("dbo.Bars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bars",
                c => new
                    {
                        BarsID = c.Int(nullable: false, identity: true),
                        BarName = c.String(),
                        WeeklySpecials = c.String(),
                        Busyness = c.String(),
                        AdditionalFeatures = c.String(),
                    })
                .PrimaryKey(t => t.BarsID);
            
            DropTable("dbo.MondayBars");
        }
    }
}
