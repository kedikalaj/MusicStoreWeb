namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreationMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        SongID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.ID)
                .ForeignKey("dbo.Songs", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ShipDetailsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ShippingDetails", t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Line1 = c.String(nullable: false),
                        Line2 = c.String(),
                        Line3 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(),
                        Country = c.String(nullable: false),
                        GiftWrap = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GenreID = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Songs");
            DropForeignKey("dbo.Songs", "ID", "dbo.Genres");
            DropForeignKey("dbo.OrderItems", "ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ID", "dbo.Users");
            DropForeignKey("dbo.Users", "ID", "dbo.Roles");
            DropForeignKey("dbo.Orders", "ID", "dbo.ShippingDetails");
            DropIndex("dbo.Songs", new[] { "ID" });
            DropIndex("dbo.Users", new[] { "ID" });
            DropIndex("dbo.Orders", new[] { "ID" });
            DropIndex("dbo.OrderItems", new[] { "ID" });
            DropTable("dbo.Songs");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Genres");
        }
    }
}
