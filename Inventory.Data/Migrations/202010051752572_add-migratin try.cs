namespace Inventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigratintry : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ItemOut", name: "ItemName", newName: "ItemId");
            RenameColumn(table: "dbo.ItemOut", name: "MemberName", newName: "MemberId");
            RenameIndex(table: "dbo.ItemOut", name: "IX_MemberName", newName: "IX_MemberId");
            RenameIndex(table: "dbo.ItemOut", name: "IX_ItemName", newName: "IX_ItemId");
            AddColumn("dbo.ItemOut", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.ItemOut", "RecordDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemOut", "RecordDate");
            DropColumn("dbo.ItemOut", "Qty");
            RenameIndex(table: "dbo.ItemOut", name: "IX_ItemId", newName: "IX_ItemName");
            RenameIndex(table: "dbo.ItemOut", name: "IX_MemberId", newName: "IX_MemberName");
            RenameColumn(table: "dbo.ItemOut", name: "MemberId", newName: "MemberName");
            RenameColumn(table: "dbo.ItemOut", name: "ItemId", newName: "ItemName");
        }
    }
}
