using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Inventory_home.Controllers
{
    //[Authorize]
    public class ItemController : Controller
    {
       // private readonly ItemService _service = new ItemService();
        // GET: Item
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            var model = service.GetItems();
            return View(model);
        }

        // GET the view for user to fill in the required info of item
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateItemService();

            if(service.CreateItem(model))
            {
                TempData["SaveResult"] = "Item was created.";
                return RedirectToAction("index");
            };

            ModelState.AddModelError("", "Item could not be added.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateItemService();
            var detail = service.GetItemById(id);
            var model =
                new ItemEdit
                {
                    ItemId = detail.ItemId,
                    Category = detail.Category,
                    ItemName = detail.ItemName,
                    Shelf = detail.Shelf,
                    Qty = detail.Qty,
                    Location = detail.Location,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ItemId != id)
            {
                ModelState.AddModelError("", "Id doesn't match.");
                return View(model);
            }

            var service = CreateItemService();

            if (service.UpdateItem(model))
            {
                TempData["SaveResult"] = "Item info updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to update.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateItemService();

            service.DeleteItem(id);

            TempData["SaveResult"] = "Item deleted.";

            return RedirectToAction("Index");
        }

        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            return service;
        }
    }
}