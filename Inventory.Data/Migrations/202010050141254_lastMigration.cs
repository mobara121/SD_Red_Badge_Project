namespace Inventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemOut", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Member", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "OwnerId");
            DropColumn("dbo.ItemOut", "OwnerId");
        }
    }
}
