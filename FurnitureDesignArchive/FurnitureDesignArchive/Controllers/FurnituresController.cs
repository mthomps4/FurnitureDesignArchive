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
    public class FurnituresController : Controller
    {
        private FurnitureContext db = new FurnitureContext();

        // GET: Furnitures
        public ActionResult Index()
        {
            return View(db.FurniturePieces.ToList());
        }

        // GET: Furnitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.FurniturePieces.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            ViewBag.Parts = db.FurnitureParts.ToList();
            return View(furniture);
        }

        // GET: Furnitures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Furnitures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FurnitureID,FurnitureName,FurnitureImg,buildLevel,furnitureType,BoardFootEst,AdditionalNotes,CompletedBefore")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.FurniturePieces.Add(furniture);
                db.SaveChanges();
                return RedirectToAction("Create", "FurnitureParts", furniture);
            }

            return View(furniture);
        }

        // GET: Furnitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.FurniturePieces.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FurnitureID,FurnitureName,FurnitureImg,buildLevel,furnitureType,BoardFootEst,AdditionalNotes,CompletedBefore")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(furniture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(furniture);
        }

        // GET: Furnitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.FurniturePieces.Find(id);
            if (furniture == null)
            {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Furniture furniture = db.FurniturePieces.Find(id);
            db.FurniturePieces.Remove(furniture);
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
