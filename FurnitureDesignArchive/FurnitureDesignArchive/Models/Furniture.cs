using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace FurnitureDesignArchive.Models
{
    public class Furniture
    {
        public int FurnitureID { get; set; }
        public string FurnitureName { get; set; } 
        public string FurnitureType { get; set; } //<list> Table, Chair, Container, Misc
        public string FurnitureImg { get; set; } //URL string 
        public double BoardFootEst { get; set; } //12.5 BF
        public string PartList { get; set; } //Explode string "Part: ..." 
        public int TimeLevel { get; set; } //1-5
        public string AdditionalNotes { get; set; } 
    }

    public class FurnitureContext : DbContext
    {
        public DbSet<Furniture> FurniturePieces { get; set; }
    }
}