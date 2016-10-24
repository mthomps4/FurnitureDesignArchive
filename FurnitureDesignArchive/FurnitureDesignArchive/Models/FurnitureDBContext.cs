using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FurnitureDesignArchive.Models
{
    // example entity framework create database if not exists seed data
    // http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

    public class FurnitureDBContext : DbContext
    {

        public class FurnitureDBInitializer : CreateDatabaseIfNotExists<FurnitureDBContext>
        {
            protected override void Seed(FurnitureDBContext context)
            {
                base.Seed(context);
            }
        }

            //CreateDatabaseIfNotExists<FurnitureDBContext>());
            //DropCreateDatabaseIfModelChanges<SchoolDBContext>());


            //DropCreateDatabaseAlways<SchoolDBContext>());
       

        public DbSet<Furniture> FurniturePieces { get; set; }
        public DbSet<FurniturePart> FurnitureParts { get; set; }
    }

}