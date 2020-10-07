namespace Inventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Category", c => c.String(nullable: false));
            AddColumn("dbo.Item", "Shelf", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Shelf");
            DropColumn("dbo.Item", "Category");
        }
    }
}
