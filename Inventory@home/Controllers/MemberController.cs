using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_home.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userId);
            var model = service.GetMembers();
            
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMemberService();

            if (service.CreateMember(model))
            {
                TempData["SaveResult"] = "Member added.";
                return RedirectToAction("index");
            };

            ModelState.AddModelError("", "Member could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMemberService();
            var model = svc.GetMemberById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMemberService();
            var detail = service.GetMemberById(id);
            var model =
                new MemberEdit
                {
                    MemberId = detail.MemberId,
                    MemberName = detail.MemberName,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MemberEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.MemberId != id)
            {
                ModelState.AddModelError("", "ID doesn't match.");
                return View(model);
            }

            var service = CreateMemberService();

            if (service.UpdateMember(model))
            {
                TempData["SaveResult"] = "Member info updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to update.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMemberService();
            var model = svc.GetMemberById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMemberService();

            service.DeleteMember(id);

            TempData["SaveResult"] = "Member deleted.";

            return RedirectToAction("Index");
        }

        private MemberService CreateMemberService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userId);
            return service;
        }

    }
}