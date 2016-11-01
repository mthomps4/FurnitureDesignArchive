using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FurnitureDesignArchive.Models
{
     public class FurnitureDBInitializer : DropCreateDatabaseAlways<FurnitureDBContext>
        {
            protected override void Seed(FurnitureDBContext context)
            {
                //Furniture Addition 
                var FurnitureAddition = new List<Furniture>
                {
                    new Models.Furniture{
                        FurnitureID=1,
                        FurnitureName="Shaker Side Table",
                        furnitureType= Furniture.FurnitureType.Tables,
                        FurnitureImg="https://c8.staticflickr.com/6/5466/30083185503_ede227ac96_o.jpg",
                        buildLevel=Furniture.IntensityLevel.Intermediate,
                        AdditionalNotes="~30\" high -- Multiple drawer types -- Customize demensions to fit space needed -- Bottom shelf can be added.",
                        CompletedBefore=true
                    }//Furniture Addition , new Models.Furniture{}
                };

                FurnitureAddition.ForEach(f => context.FurniturePieces.Add(f));
                context.SaveChanges();

            var FurniturePartAddition = new List<FurniturePart>
                {
                    new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Legs",
                        PartCount = 4,
                        BoardThickness = 2,
                        Length = 30,
                        Width = 30,
                        PartNotes = "4 legs squared. Drawboard into Sides. Front Piece has a top and bottom rail with center acting as drawer front.",
                        partBoardFoot = 12.5
                    },//Furniture Part Addition , new FurniturePart

                    new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Outer Frame Sides",
                        PartCount = 2,
                        BoardThickness = 1,
                        Length = 18,
                        Width = 4,
                        PartNotes = "Left and Right outer sides of the frame.",
                        partBoardFoot = 1
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Outer Frame Front/Back",
                        PartCount = 2,
                        BoardThickness = 1,
                        Length = 15,
                        Width = 4,
                        PartNotes = "Front ripped into 3 pieces -- Center piece used for drawer Front. Flush finish.",
                        partBoardFoot = .833
                    },

                     new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Drawer Sides",
                        PartCount = 2,
                        BoardThickness = 1,
                        Length = 15,
                        Width = 3,
                        PartNotes = "Height dependant on drawer front.",
                        partBoardFoot = .625
                    },

                      new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Drawer Back",
                        PartCount = 1,
                        BoardThickness = 1,
                        Length = 15,
                        Width = 2.5,
                        PartNotes = "Length planed to fit inside frame. Bottom groove cut off for drawer expansion",
                        partBoardFoot = .3125
                    },

                        new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Drawer Bottom",
                        PartCount = 1,
                        BoardThickness = 1,
                        Length = 15,
                        Width = 15,
                        PartNotes = "Planed to fit inside rabbet. Grain oriented for seasonal movement to back of frame.",
                        partBoardFoot = 1.5625
                    },
                        new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Drawer Rail Slides",
                        PartCount = 2,
                        BoardThickness = 1,
                        Length = 15,
                        Width = 1,
                        PartNotes = "Drawer has outer dado -- rails and sides left unfinished -- waxed for movement.",
                        partBoardFoot = .625
                    },
                        new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Top",
                        PartCount = 1,
                        BoardThickness = 1,
                        Length = 20,
                        Width =18,
                        PartNotes = "Planed to fit inside rabbet. Grain oriented for seasonal movement to back of frame.",
                        partBoardFoot = 2.5
                    },
                        new Models.FurniturePart {
                        FurnitureIndex = 1,
                        PartName = "Dowel",
                        PartCount = 1,
                        BoardThickness = .5,
                        Length = 36,
                        Width =.5,
                        PartNotes = "Half inch dowel used for drawboarding legs to sides.",
                        partBoardFoot = .0625
                    },
              };

                FurniturePartAddition.ForEach(p => context.FurnitureParts.Add(p));
                context.SaveChanges();

                base.Seed(context);

            }//Override Seed() 
        }//Initializer 
    }