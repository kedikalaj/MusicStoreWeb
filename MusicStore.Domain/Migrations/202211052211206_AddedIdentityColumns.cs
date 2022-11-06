namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIdentityColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ID", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Songs");
            DropIndex("dbo.Orders", new[] { "ID" });
            DropIndex("dbo.Users", new[] { "ID" });
            DropIndex("dbo.OrderItems", new[] { "ID" });
            DropIndex("dbo.Songs", new[] { "ID" });
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.OrderItems");
            DropPrimaryKey("dbo.Songs");
            AlterColumn("dbo.Orders", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderItems", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Songs", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "ID");
            AddPrimaryKey("dbo.Users", "ID");
            AddPrimaryKey("dbo.OrderItems", "ID");
            AddPrimaryKey("dbo.Songs", "ID");
            CreateIndex("dbo.Orders", "ID");
            CreateIndex("dbo.Users", "ID");
            CreateIndex("dbo.OrderItems", "ID");
            CreateIndex("dbo.Songs", "ID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Orders", "ID");
            AddForeignKey("dbo.Orders", "ID", "dbo.Users", "ID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Songs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Songs");
            DropForeignKey("dbo.Orders", "ID", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Orders");
            DropIndex("dbo.Songs", new[] { "ID" });
            DropIndex("dbo.OrderItems", new[] { "ID" });
            DropIndex("dbo.Users", new[] { "ID" });
            DropIndex("dbo.Orders", new[] { "ID" });
            DropPrimaryKey("dbo.Songs");
            DropPrimaryKey("dbo.OrderItems");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Songs", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderItems", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Songs", "ID");
            AddPrimaryKey("dbo.OrderItems", "ID");
            AddPrimaryKey("dbo.Users", "ID");
            AddPrimaryKey("dbo.Orders", "ID");
            CreateIndex("dbo.Songs", "ID");
            CreateIndex("dbo.OrderItems", "ID");
            CreateIndex("dbo.Users", "ID");
            CreateIndex("dbo.Orders", "ID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Songs", "ID");
            AddForeignKey("dbo.Orders", "ID", "dbo.Users", "ID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Orders", "ID");
        }
    }
}
