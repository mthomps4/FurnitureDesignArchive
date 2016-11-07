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
                    },//Furniture Addition , new Models.Furniture{}
                    new Models.Furniture{
                        FurnitureID=2,
                        FurnitureName="Wooden Jack Plane",
                        furnitureType= Furniture.FurnitureType.Tools,
                        FurnitureImg="https://c1.staticflickr.com/6/5549/30686452192_125dd5d384_o.jpg",
                        buildLevel =Furniture.IntensityLevel.Beginner,
                        AdditionalNotes="Length scaled for plane use -- Joiner, Jack, Smoother",
                        CompletedBefore=true
                    },
                    new Models.Furniture{
                        FurnitureID=3,
                        FurnitureName="Oak Table",
                        furnitureType= Furniture.FurnitureType.Tables,
                        FurnitureImg="https://c3.staticflickr.com/6/5344/30680944106_86c07f6894_o.jpg",
                        buildLevel =Furniture.IntensityLevel.Intermediate,
                        AdditionalNotes="40x72 - 6 person table. Hardware can be used for breakdown instead of solid joints.",
                        CompletedBefore=false
                    },
                    new Models.Furniture{
                        FurnitureID=4,
                        FurnitureName="Dutch Chest",
                        furnitureType= Furniture.FurnitureType.Containers,
                        FurnitureImg="https://c8.staticflickr.com/6/5452/30083178023_4cb4585dc7_o.jpg",
                        buildLevel =Furniture.IntensityLevel.Intermediate,
                        AdditionalNotes="Drawboard and hardware for stability.",
                        CompletedBefore=false
                    },
                    new Models.Furniture{
                        FurnitureID=5,
                        FurnitureName="Wooden Book Case",
                        furnitureType= Furniture.FurnitureType.Containers,
                        FurnitureImg="https://c3.staticflickr.com/6/5328/30522943570_816c03bd8a_o.jpg",
                        buildLevel =Furniture.IntensityLevel.Beginner,
                        AdditionalNotes="3 Tier case -- Inlayed shelves for added stability.",
                        CompletedBefore=false
                    },
                    new Models.Furniture{
                        FurnitureID=6,
                        FurnitureName="Wooden Stool",
                        furnitureType= Furniture.FurnitureType.Seating,
                        FurnitureImg="https://c6.staticflickr.com/6/5695/30736088781_fa99f7d9d5_o.jpg",
                        buildLevel =Furniture.IntensityLevel.Beginner,
                        AdditionalNotes="Drawboarded for stability, full mortise and tenon.",
                        CompletedBefore=false
                    },
                };

                FurnitureAddition.ForEach(f => context.FurniturePieces.Add(f));
                context.SaveChanges();

            var FurniturePartAddition = new List<FurniturePart>
                {
// Piece 1 - Shaker Side Table 
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

// Piece 2 - Wooden Jack Plane 
                    new Models.FurniturePart {
                        FurnitureIndex = 2,
                        PartName = "Plane Sides",
                        PartCount = 2,
                        BoardThickness = .5,
                        Length = 18,
                        Width = 3,
                        PartNotes = "Outer Frame with Pin",
                        partBoardFoot = .375
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 2,
                        PartName = "Plane Body",
                        PartCount = 1,
                        BoardThickness = 2.5,
                        Length = 18,
                        Width = 3,
                        PartNotes = "Mouth and Plane Body created out of one block piece - Outer Sides can be ripped from same thicker block",
                        partBoardFoot = 1
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 2,
                        PartName = "Wedge",
                        PartCount = 1,
                        BoardThickness = 1,
                        Length = 4,
                        Width = 3,
                        PartNotes = "Wedge holds blade against plane bed and brass pin -- Can be made from 'Plane Body' scraps",
                        partBoardFoot = .083
                    },
// Piece 3 - Oak Table  
                    new Models.FurniturePart {
                        FurnitureIndex = 3,
                        PartName = "Table Top",
                        PartCount = 1,
                        BoardThickness = 1.5,
                        Length = 72,
                        Width = 40,
                        PartNotes = "Slab, Glue-up, Mixed-Reclaimed, etc.",
                        partBoardFoot = 31.25
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 3,
                        PartName = "Long Rails",
                        PartCount = 2,
                        BoardThickness = 1.5,
                        Length = 72,
                        Width = 3,
                        PartNotes = "Attatch to short rails with breakdown hardware -- Top attached via buttons",
                        partBoardFoot = 4.5
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 3,
                        PartName = "Short Rails",
                        PartCount = 2,
                        BoardThickness = 1.5,
                        Length = 40,
                        Width = 3,
                        PartNotes = "Short rails Joined to Legs as full part.",
                        partBoardFoot = 2.5
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 3,
                        PartName = "Legs",
                        PartCount = 4,
                        BoardThickness = 3,
                        Length = 30,
                        Width = 3,
                        PartNotes = "Legs tappered and drawboard into 'Short Rails'",
                        partBoardFoot = 7.5
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 3,
                        PartName = "Buttons",
                        PartCount = 24,
                        BoardThickness = 1,
                        Length = 3,
                        Width = 1.5,
                        PartNotes = "Hat shaped buttons created to fix top to Rails",
                        partBoardFoot = .75
                    },
// Piece 4 - Dutch Chest 
                    new Models.FurniturePart {
                        FurnitureIndex = 4,
                        PartName = "Base",
                        PartCount = 1,
                        BoardThickness = 2,
                        Length = 20,
                        Width = 44,
                        PartNotes = "Base secured into bottom long rails with dado",
                        partBoardFoot = 12.222
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 4,
                        PartName = "Long rails",
                        PartCount = 6,
                        BoardThickness = 2,
                        Length = 44,
                        Width = 4,
                        PartNotes = "4-Case 2-Top -- Bottom routed to recieve base.",
                        partBoardFoot = 14.666
                    },


                    new Models.FurniturePart {
                        FurnitureIndex = 4,
                        PartName = "Short rails",
                        PartCount = 4,
                        BoardThickness = 2,
                        Length = 20,
                        Width = 4,
                        PartNotes = "Top and Bottom of Side walls",
                        partBoardFoot = 4.5
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 4,
                        PartName = "Panel Supports",
                        PartCount = 10,
                        BoardThickness = 2,
                        Length = 12,
                        Width = 4,
                        PartNotes = "Vertical supports for panels -- routed for pannel drop ins",
                        partBoardFoot = 6.666
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 4,
                        PartName = "Wooden Dowel",
                        PartCount = 1,
                        BoardThickness = .5,
                        Length = 36,
                        Width = .5,
                        PartNotes = "Used to drawboard side walls together around base.",
                        partBoardFoot = 1
                    },


                    new Models.FurniturePart {
                        FurnitureIndex = 4,
                        PartName = "Top - Short Side ",
                        PartCount = 3,
                        BoardThickness = 2,
                        Length = 20,
                        Width = 4,
                        PartNotes = "Connected to Top Rails to create top.",
                        partBoardFoot = 3.334
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 4,
                        PartName = "Top Cover",
                        PartCount = 1,
                        BoardThickness = 2,
                        Length = 20,
                        Width = 44,
                        PartNotes = "Top inset into Top Rails -- Middle 'Top Short Side' piece for structure support.",
                        partBoardFoot = 12.223
                    },
// Piece 5 - Book Case 
                    new Models.FurniturePart {
                        FurnitureIndex = 5,
                        PartName = "",
                        PartCount = 4,
                        BoardThickness = 3,
                        Length = 30,
                        Width = 3,
                        PartNotes = "",
                        partBoardFoot = 7.5
                    },

                    new Models.FurniturePart {
                        FurnitureIndex = 5,
                        PartName = "",
                        PartCount = 4,
                        BoardThickness = 3,
                        Length = 30,
                        Width = 3,
                        PartNotes = "",
                        partBoardFoot = 7.5
                    },
              };

                FurniturePartAddition.ForEach(p => context.FurnitureParts.Add(p));
                context.SaveChanges();

                base.Seed(context);

            }//Override Seed() 
        }//Initializer 
    }