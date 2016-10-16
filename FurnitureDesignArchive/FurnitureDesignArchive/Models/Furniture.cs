using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FurnitureDesignArchive.Models
{
    public class Furniture
    {
       public enum IntensityLevel
        {
            Beginner,
            Intermediate,
            Hard
        }

        public enum FurnitureType
        {
            Tables,
            Seating,
            Containers,
            Misc
        }

        public int FurnitureID { get; set; }
        public string FurnitureName { get; set; }
        public string FurnitureImg { get; set; } //URL string 
        public IntensityLevel buildLevel { get; set; }
        public FurnitureType furnitureType { get; set; }
        public double BoardFootEst { get; set; } //12.5 BF
        public string PartList { get; set; } //Explode string "Part: ..." 
        public string AdditionalNotes { get; set; }
        public bool CompletedBefore { get; set; }
    }

    public class FurnitureContext : DbContext
    {
        public DbSet<Furniture> FurniturePieces { get; set; }
    }


}