namespace Capstone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Weeklyspecialstospecials : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MondayBars", "Specials", c => c.String());
            DropColumn("dbo.MondayBars", "WeeklySpecials");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MondayBars", "WeeklySpecials", c => c.String());
            DropColumn("dbo.MondayBars", "Specials");
        }
    }
}
