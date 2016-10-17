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
            Tools,
            Misc
        }

        public int FurnitureID { get; set; }

        [Required]
        [Display(Name = "Furniture Name")]
        public string FurnitureName { get; set; }

        [Display(Name = "Image")]
        public string FurnitureImg { get; set; } //URL string 

        [Display(Name = "Build Level")]
        public IntensityLevel buildLevel { get; set; }

        [Required]
        [Display(Name = "Furniture Type")]
        public FurnitureType furnitureType { get; set; }

        [Display(Name = "Board Foot Estimate")]
        public double BoardFootEst { get; set; } //12.5 BF

        [Display(Name = "Additional Notes")]
        public string AdditionalNotes { get; set; }

        [Display(Name = "Completed Before")]
        public bool CompletedBefore { get; set; }


        //Furniture Parts Table 
        [Display(Name = "Furniture Parts")]
        public virtual ICollection<FurniturePart> FurnitureParts { get; set; }

        public Furniture()
        {
            this.FurnitureParts = new List<FurniturePart>();
        }

    }

    public class FurnitureContext : DbContext
    {
        public DbSet<Furniture> FurniturePieces { get; set; }
        public DbSet<FurniturePart> FurnitureParts { get; set; }
    }


}