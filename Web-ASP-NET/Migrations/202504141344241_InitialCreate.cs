namespace Web_ASP_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Slug = c.String(),
                        ShowOnHomePage = c.Boolean(),
                        DisplayOrder = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Slug = c.String(),
                        ShowOnHomePage = c.Boolean(),
                        DisplayOrder = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(),
                        CreatedAt = c.DateTime(),
                        DisplayName = c.String(),
                        Provider = c.String(),
                        FirebaseUid = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        ShortDes = c.String(),
                        ShowOnHomePage = c.Boolean(),
                        FullDescription = c.String(),
                        Price = c.Double(nullable: false),
                        PriceDiscount = c.Double(),
                        TypeId = c.Int(),
                        Slug = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
