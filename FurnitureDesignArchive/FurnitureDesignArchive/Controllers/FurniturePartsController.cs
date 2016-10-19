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
        private FurnitureContext db = new FurnitureContext();

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: FurnitureParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FurniturePartId,FurnitureIndex,PartName,PartCount,Width,Length,BoardThickness,partBoardFoot,PartNotes,PartImgUrl")] FurniturePart furniturePart)
        {
            if (ModelState.IsValid)
            {
                db.FurnitureParts.Add(furniturePart);
                db.SaveChanges();
                return RedirectToAction("Index");
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
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(furniturePart);
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
