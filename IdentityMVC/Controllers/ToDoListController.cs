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
    public class ToDoListController : Controller
    {
        ApplicationDbContext connection = new ApplicationDbContext();

        // GET: ToDoList
        public ActionResult Index()
        {

            List<ToDoList> _List = new List<ToDoList>();

            foreach (ToDoList list_ in connection.ToDoLists.ToList())
            {
                if (list_.UserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                {
                    _List.Add(list_);
                }
            }

            return View(_List.ToList());
        }

        // GET: ToDoList/Details/5
        public ActionResult Details(int id)
        {
            return View(connection.ToDoLists.Where(x => x.Id == id).FirstOrDefault());
        }

        // GET: ToDoList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/Create
        [HttpPost]
        public ActionResult Create(ToDoList item_)
        {
            try
            {
                item_.UserId = User.Identity.GetUserId();
                connection.ToDoLists.Add(item_);
                connection.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoList/Edit/5
        public ActionResult Edit(int id)
        {
            return View(connection.ToDoLists.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: ToDoList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ToDoList item_)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                item_.UserId = User.Identity.GetUserId();
                connection.Entry(item_).State = EntityState.Modified;
                connection.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int id)
        {
            return View(connection.ToDoLists.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: ToDoList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ToDoList item_ = connection.ToDoLists.Where(x => x.Id == id).FirstOrDefault();
                connection.ToDoLists.Remove(item_);
                connection.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
