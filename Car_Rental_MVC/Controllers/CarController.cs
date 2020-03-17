using Car_Rental_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rental_MVC.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        CarRentalEntities obj = new CarRentalEntities();

        public ActionResult CarDetails()
        {
            return View(obj.Cars.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Car carDetails)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Cars.Add(carDetails);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("CarDetails");


        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Cars where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(Car IdtoEdit)
        {
            var orignalRecord = (from m in obj.Cars where m.id == IdtoEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdtoEdit);

            obj.SaveChanges();
            return RedirectToAction("CarDetails");

        }

        // GET: Car/Delete/5
        public ActionResult Delete(Car IdtoDelete)
        {
            var d = obj.Cars.Where(x => x.id == IdtoDelete.id).FirstOrDefault();
            obj.Cars.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("CarDetails");
        }

        // POST: Car/Delete/5
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
