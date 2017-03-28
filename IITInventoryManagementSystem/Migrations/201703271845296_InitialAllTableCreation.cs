namespace IITInventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAllTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddingTime = c.DateTime(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAvailable = c.Boolean(nullable: false),
                        Location = c.String(),
                        Arrival_Id = c.Int(),
                        ItemCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemArrivals", t => t.Arrival_Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategory_Id)
                .Index(t => t.Arrival_Id)
                .Index(t => t.ItemCategory_Id);
            
            CreateTable(
                "dbo.ItemArrivals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Voucher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vouchers", t => t.Voucher_Id)
                .Index(t => t.Voucher_Id);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        FilePath = c.String(),
                        Sector_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectors", t => t.Sector_Id)
                .Index(t => t.Sector_Id);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequisedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Id = c.Int(),
                        RequisitionSlip_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.RequisitionSlips", t => t.RequisitionSlip_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.RequisitionSlip_Id);
            
            CreateTable(
                "dbo.RequisitionSlips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purpose = c.String(),
                        ApplicationDate = c.DateTime(nullable: false),
                        RecommendationDate = c.DateTime(nullable: false),
                        VerificationDate = c.DateTime(nullable: false),
                        ApplicantId = c.String(),
                        RecommenderId = c.String(),
                        VerifierId = c.String(),
                        RejectionCause = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Designation = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequisedItems", "RequisitionSlip_Id", "dbo.RequisitionSlips");
            DropForeignKey("dbo.RequisedItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Carts", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "ItemCategory_Id", "dbo.ItemCategories");
            DropForeignKey("dbo.ItemCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Items", "Arrival_Id", "dbo.ItemArrivals");
            DropForeignKey("dbo.ItemArrivals", "Voucher_Id", "dbo.Vouchers");
            DropForeignKey("dbo.Vouchers", "Sector_Id", "dbo.Sectors");
            DropIndex("dbo.RequisedItems", new[] { "RequisitionSlip_Id" });
            DropIndex("dbo.RequisedItems", new[] { "Item_Id" });
            DropIndex("dbo.ItemCategories", new[] { "Category_Id" });
            DropIndex("dbo.Vouchers", new[] { "Sector_Id" });
            DropIndex("dbo.ItemArrivals", new[] { "Voucher_Id" });
            DropIndex("dbo.Items", new[] { "ItemCategory_Id" });
            DropIndex("dbo.Items", new[] { "Arrival_Id" });
            DropIndex("dbo.Carts", new[] { "Item_Id" });
            DropTable("dbo.UserDetails");
            DropTable("dbo.RequisitionSlips");
            DropTable("dbo.RequisedItems");
            DropTable("dbo.Categories");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.Sectors");
            DropTable("dbo.Vouchers");
            DropTable("dbo.ItemArrivals");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
