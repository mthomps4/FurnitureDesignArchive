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
    public class FurniturePiecesController : Controller
    {
        private FurnitureContext db = new FurnitureContext();

        // GET: FurniturePieces
        public ActionResult Index()
        {
            return View(db.FurniturePieces.ToList());
        }

        // GET: FurniturePieces/Details/5
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
            return View(furniture);
        }

        // GET: FurniturePieces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FurniturePieces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FurnitureID,FurnitureName,FurnitureType,FurnitureImg,BoardFootEst,PartList,TimeLevel,AdditionalNotes")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.FurniturePieces.Add(furniture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(furniture);
        }

        // GET: FurniturePieces/Edit/5
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

        // POST: FurniturePieces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FurnitureID,FurnitureName,FurnitureType,FurnitureImg,BoardFootEst,PartList,TimeLevel,AdditionalNotes")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(furniture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(furniture);
        }

        // GET: FurniturePieces/Delete/5
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

        // POST: FurniturePieces/Delete/5
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
