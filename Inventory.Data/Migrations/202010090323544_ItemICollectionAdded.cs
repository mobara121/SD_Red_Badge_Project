namespace Inventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemICollectionAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemOut", "ItemId", "dbo.Item");
            AddColumn("dbo.Item", "ItemOut_Id", c => c.Int());
            AddColumn("dbo.ItemOut", "Item_Id", c => c.Int());
            CreateIndex("dbo.Item", "ItemOut_Id");
            CreateIndex("dbo.ItemOut", "Item_Id");
            AddForeignKey("dbo.Item", "ItemOut_Id", "dbo.ItemOut", "Id");
            AddForeignKey("dbo.ItemOut", "Item_Id", "dbo.Item", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemOut", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.Item", "ItemOut_Id", "dbo.ItemOut");
            DropIndex("dbo.ItemOut", new[] { "Item_Id" });
            DropIndex("dbo.Item", new[] { "ItemOut_Id" });
            DropColumn("dbo.ItemOut", "Item_Id");
            DropColumn("dbo.Item", "ItemOut_Id");
            AddForeignKey("dbo.ItemOut", "ItemId", "dbo.Item", "Id", cascadeDelete: true);
        }
    }
}
