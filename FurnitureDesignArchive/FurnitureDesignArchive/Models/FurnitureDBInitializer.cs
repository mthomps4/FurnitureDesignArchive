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
                        FurnitureImg="URL",
                        buildLevel=Furniture.IntensityLevel.Intermediate,
                        AdditionalNotes="Front is ripped into pieces for drawer front. Dowel is used for drawboarding legs and sides together. Slides used for drawer sides.",
                        CompletedBefore=false
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
                        PartNotes = "4 legs squared. Mortise and Tennoned into Sides. Front Piece has top and bottom mortised in with center piece acting as drawer front.",
                        partBoardFoot = 12.5
                    }//Furniture Part Addition , new FurniturePart
                };

                FurniturePartAddition.ForEach(p => context.FurnitureParts.Add(p));
                context.SaveChanges();

                base.Seed(context);

            }//Override Seed() 
        }//Initializer 
    }