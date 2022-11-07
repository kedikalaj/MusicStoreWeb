namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tetst : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Songs");
            DropIndex("dbo.Songs", new[] { "GenreID" });
            
            RenameColumn(table: "dbo.Songs", name: "GenreID", newName: "ID");
            DropPrimaryKey("dbo.Songs");
            AlterColumn("dbo.Songs", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Songs", "ID");
            CreateIndex("dbo.Songs", "ID");
            AddForeignKey("dbo.Songs", "ID", "dbo.Genres", "ID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Songs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Songs");
            DropForeignKey("dbo.Songs", "ID", "dbo.Genres");
            DropIndex("dbo.Songs", new[] { "ID" });
            DropPrimaryKey("dbo.Songs");
            AlterColumn("dbo.Songs", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Songs", "ID");
            RenameColumn(table: "dbo.Songs", name: "ID", newName: "GenreID");
            AddColumn("dbo.Songs", "ID", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Songs", "GenreID");
            AddForeignKey("dbo.OrderItems", "ID", "dbo.Songs", "ID");
            AddForeignKey("dbo.Songs", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
        }
    }
}
