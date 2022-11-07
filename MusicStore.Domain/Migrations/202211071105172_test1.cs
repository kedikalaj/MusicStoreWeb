namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Songs");
            DropIndex("dbo.Songs", new[] { "ID" });
            DropPrimaryKey("dbo.Songs");
            AlterColumn("dbo.Songs", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Songs", "ID");
            CreateIndex("dbo.Songs", "ID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Songs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Songs");
            DropIndex("dbo.Songs", new[] { "ID" });
            DropPrimaryKey("dbo.Songs");
            AlterColumn("dbo.Songs", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Songs", "ID");
            CreateIndex("dbo.Songs", "ID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Songs", "ID");
        }
    }
}
