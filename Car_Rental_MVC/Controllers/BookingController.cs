using Car_Rental_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rental_MVC.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        CarRentalEntities obj = new CarRentalEntities();

        public ActionResult BookingList()
        {
            return View(obj.Bookings.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Booking data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Bookings.Add(data);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("BookingList");

        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int Editid)
        {
            var EditId = (from m in obj.Bookings where m.id == Editid select m).First();
            return View(EditId);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(Booking BookId)
        {
            var orignalRecord = (from m in obj.Bookings where m.id == BookId.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(BookId);

            obj.SaveChanges();
            return RedirectToAction("BookingList");


        }

        // GET: Booking/Delete/5
        public ActionResult Delete(Booking bookId)
        {
            var d =obj.Bookings.Where(x => x.id == bookId.id).FirstOrDefault();
            obj.Bookings.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("BookingList");
        }

        // POST: Booking/Delete/5
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
