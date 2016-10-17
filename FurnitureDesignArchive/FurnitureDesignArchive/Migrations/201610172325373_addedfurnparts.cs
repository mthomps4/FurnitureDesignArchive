namespace FurnitureDesignArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfurnparts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FurnitureParts",
                c => new
                    {
                        FurniturePartId = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        PartCount = c.Int(nullable: false),
                        Width = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        BoardThickness = c.Double(nullable: false),
                        partBoardFoot = c.Double(nullable: false),
                        PartNotes = c.String(),
                        PartImgUrl = c.String(),
                        Furniture_FurnitureID = c.Int(),
                    })
                .PrimaryKey(t => t.FurniturePartId)
                .ForeignKey("dbo.Furnitures", t => t.Furniture_FurnitureID)
                .Index(t => t.Furniture_FurnitureID);
            
            DropColumn("dbo.Furnitures", "PartList");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Furnitures", "PartList", c => c.String());
            DropForeignKey("dbo.FurnitureParts", "Furniture_FurnitureID", "dbo.Furnitures");
            DropIndex("dbo.FurnitureParts", new[] { "Furniture_FurnitureID" });
            DropTable("dbo.FurnitureParts");
        }
    }
}
