using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FurnitureDesignArchive.Models;

namespace FurnitureDesignArchive
{
    public class FurniturePartsController : Controller
    {
        private FurnitureDBContext db = new FurnitureDBContext();

        // GET: FurnitureParts
        public ActionResult Index()
        {
            return View(db.FurnitureParts.ToList());
        }

        // GET: FurnitureParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FurniturePart furniturePart = db.FurnitureParts.Find(id);
            if (furniturePart == null)
            {
                return HttpNotFound();
            }
            return View(furniturePart);
        }

        // GET: FurnitureParts/Create
        [HttpGet]
        public ActionResult Create(Furniture furniture, FurniturePart furnitureParts)
        {
            //If part Index not set?? 
            if (furnitureParts.FurnitureIndex == 0)
            {
                furnitureParts.FurnitureIndex = furniture.FurnitureID;
                furnitureParts.FurniturePieceName = furniture.FurnitureName;
                return View(furnitureParts);
            }
            else
            {
                //Redirect using TempData 
                //TODO: MSG Adding another Part Failed. 
                return View("Index", "furnitures");
            }
        }

        // POST: FurnitureParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string submit, Furniture furniture, [Bind(Include = "FurniturePartId,FurnitureIndex,PartName,PartCount,Width,Length,BoardThickness,partBoardFoot,PartNotes,PartImgUrl")] FurniturePart furniturePart)
        {

            switch (submit)
            {
                case "Add Another Part":
                    if (ModelState.IsValid)
                    {
                        furniturePart.FurniturePieceName = furniture.FurnitureName; //Set Name and ID for Parts DB 
                        furniturePart.FurnitureIndex = furniture.FurnitureID;
                        furniturePart.partBoardFoot = 0;
                        double BoardFoot = furniturePart.PartCount*((furniturePart.Width * furniturePart.Length * furniturePart.BoardThickness)/144);
                        BoardFoot = Math.Round(BoardFoot, 4);
                        furniturePart.partBoardFoot = BoardFoot;
                        db.FurnitureParts.Add(furniturePart);
                        db.SaveChanges();

                        return RedirectToAction("create", "FurnitureParts", furniture); //Returns Furniture for ID and Name 
                    }
                    break;

                case "Finished":
                    if (ModelState.IsValid)
                    {
                        furniturePart.FurniturePieceName = furniture.FurnitureName;
                        furniturePart.FurnitureIndex = furniture.FurnitureID;
                        double BoardFoot = furniturePart.PartCount * ((furniturePart.Width * furniturePart.Length * furniturePart.BoardThickness) / 144);
                        BoardFoot = Math.Round(BoardFoot, 4);
                        furniturePart.partBoardFoot = BoardFoot;
                        db.FurnitureParts.Add(furniturePart);
                        db.SaveChanges();
                        var id = furniturePart.FurnitureIndex; //FurnitureID = FurnitureIndex 
                        return RedirectToAction("Details", "Furnitures", new { id }); //Back to Furniture Details View
                    }
                    break;

                case "Cancel":
                    {
                        return RedirectToAction("Index", "furnitures");
                    }

                default:
                    break;
            }

            return View(furniturePart);
        }

        // GET: FurnitureParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FurniturePart furniturePart = db.FurnitureParts.Find(id);
            if (furniturePart == null)
            {
                return HttpNotFound();
            }
            return View(furniturePart);
        }

        // POST: FurnitureParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FurniturePartId,FurnitureIndex,PartName,PartCount,Width,Length,BoardThickness,partBoardFoot,PartNotes,PartImgUrl")] FurniturePart furniturePart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(furniturePart).State = EntityState.Modified;

                furniturePart.partBoardFoot = 0;
                double BoardFoot = furniturePart.PartCount * ((furniturePart.Width * furniturePart.Length * furniturePart.BoardThickness) / 144);
                BoardFoot = Math.Round(BoardFoot, 4);
                furniturePart.partBoardFoot = BoardFoot;


                db.SaveChanges();
                var id = furniturePart.FurnitureIndex; //FurnitureID = FurnitureIndex 
                return RedirectToAction("Details", "Furnitures", new {id}); //Back to Furniture Details View 
            }
            return View("Index", "Furnitures");
        }

        // GET: FurnitureParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FurniturePart furniturePart = db.FurnitureParts.Find(id);
            if (furniturePart == null)
            {
                return HttpNotFound();
            }
            return View(furniturePart);
        }

        // POST: FurnitureParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FurniturePart furniturePart = db.FurnitureParts.Find(id);
            db.FurnitureParts.Remove(furniturePart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
