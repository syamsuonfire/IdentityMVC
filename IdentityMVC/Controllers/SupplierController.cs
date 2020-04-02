using IdentityMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupplierController : Controller
    {
        IdentityMVCEntities connection2 = new IdentityMVCEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(connection2.Suppliers.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(string mail)
        {
            return View(connection2.Suppliers.Where(S => S.Email == mail).FirstOrDefault());
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return RedirectToAction("Register", "Account");
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                connection2.Suppliers.Add(supplier);
                connection2.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(string mail)
        {
            return View(connection2.Suppliers.Where(S => S.Email == mail).FirstOrDefault());
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(Supplier item_)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                item_.Email = User.Identity.GetUserId();
                connection2.Entry(item_).State = EntityState.Modified;
                connection2.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(string mail)
        {
            return View(connection2.Suppliers.Where(S => S.Email == mail).FirstOrDefault());
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(string mail, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Supplier item_ = connection2.Suppliers.Where(X => X.Email == mail).FirstOrDefault();
                connection2.Suppliers.Remove(item_);
                connection2.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

