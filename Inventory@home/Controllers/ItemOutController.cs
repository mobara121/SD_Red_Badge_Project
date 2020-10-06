﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Data;
using Inventory_home.Data;

namespace Inventory_home.Controllers
{
    public class ItemOutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemOut
        public ActionResult Index()
        {
            var itemsOut = db.ItemsOut.Include(i => i.Item).Include(i => i.Member);
            return View(itemsOut.ToList());
        }

        // GET: ItemOut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOut itemOut = db.ItemsOut.Find(id);
            if (itemOut == null)
            {
                return HttpNotFound();
            }
            return View(itemOut);
        }

        // GET: ItemOut/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName");
            return View();
        }

        // POST: ItemOut/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OwnerId,MemberId,ItemId,Qty,RecordDate")] ItemOut itemOut)
        {
            if (ModelState.IsValid)
            {
                db.ItemsOut.Add(itemOut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemOut.ItemId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName", itemOut.MemberId);
            return View(itemOut);
        }

        // GET: ItemOut/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOut itemOut = db.ItemsOut.Find(id);
            if (itemOut == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemOut.ItemId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName", itemOut.MemberId);
            return View(itemOut);
        }

        // POST: ItemOut/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerId,MemberId,ItemId,Qty,RecordDate")] ItemOut itemOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", itemOut.ItemId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName", itemOut.MemberId);
            return View(itemOut);
        }

        // GET: ItemOut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemOut itemOut = db.ItemsOut.Find(id);
            if (itemOut == null)
            {
                return HttpNotFound();
            }
            return View(itemOut);
        }

        // POST: ItemOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemOut itemOut = db.ItemsOut.Find(id);
            db.ItemsOut.Remove(itemOut);
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