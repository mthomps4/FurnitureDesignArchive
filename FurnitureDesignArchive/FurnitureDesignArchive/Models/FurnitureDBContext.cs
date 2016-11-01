using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FurnitureDesignArchive.Models
{
    // example entity framework create database if not exists seed data
    // http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
    //https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

    public class FurnitureDBContext : DbContext
    {

        public FurnitureDBContext(): base("Furniture Database") //Connection String 
        {
            Database.SetInitializer<FurnitureDBContext>(new FurnitureDBInitializer());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Furniture> FurniturePieces { get; set; }
        public DbSet<FurniturePart> FurnitureParts { get; set; }

    }//DBContext
}//Namespace