namespace FurnitureDesignArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        FurnitureID = c.Int(nullable: false, identity: true),
                        FurnitureName = c.String(nullable: false),
                        FurnitureImg = c.String(),
                        buildLevel = c.Int(nullable: false),
                        furnitureType = c.Int(nullable: false),
                        BoardFootEst = c.Double(nullable: false),
                        PartList = c.String(),
                        AdditionalNotes = c.String(),
                        CompletedBefore = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FurnitureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Furnitures");
        }
    }
}
