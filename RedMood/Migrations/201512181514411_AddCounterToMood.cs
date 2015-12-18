namespace RedMood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCounterToMood : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Moods", "count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Moods", "count");
        }
    }
}
