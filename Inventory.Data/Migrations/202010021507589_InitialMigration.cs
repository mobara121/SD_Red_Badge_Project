namespace Inventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ItemOut", name: "ItemId", newName: "ItemName");
            RenameIndex(table: "dbo.ItemOut", name: "IX_ItemId", newName: "IX_ItemName");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ItemOut", name: "IX_ItemName", newName: "IX_ItemId");
            RenameColumn(table: "dbo.ItemOut", name: "ItemName", newName: "ItemId");
        }
    }
}
