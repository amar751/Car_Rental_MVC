using Car_Rental_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rental_MVC.Controllers
{
    public class ContactListController : Controller
    {
        // GET: ContactList
        CarRentalEntities1 obj = new CarRentalEntities1();

        public ActionResult contactDisplay()
        {
            return View(obj.Contacts.ToList());
        }

        // GET: ContactList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactList/Delete/5
        public ActionResult Delete(Contact conId)
        {

            var d = obj.Contacts.Where(x => x.id == conId.id).FirstOrDefault();
            obj.Contacts.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("contactDisplay");
        }

        // POST: ContactList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
