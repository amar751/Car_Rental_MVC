using Car_Rental_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rental_MVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        CarRentalEntities obj = new CarRentalEntities();

        public ActionResult PaymentList()
        {
            return View(obj.Payments.ToList());
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Payment payment)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Payments.Add(payment);
            obj.SaveChanges();
            return RedirectToAction("PaymentList");

        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Payments where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Payment/Edit/5
        [HttpPost]
        public ActionResult Edit(Payment paymentID)
        {
            var orignalRecord = (from m in obj.Payments where m.id ==paymentID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(paymentID);

            obj.SaveChanges();
            return RedirectToAction("PaymentList");
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(Payment paymentId)
        {
            var d =obj.Payments.Where(x => x.id == paymentId.id).FirstOrDefault();
            obj.Payments.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("PaymentList");
            
        }

        // POST: Payment/Delete/5
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
