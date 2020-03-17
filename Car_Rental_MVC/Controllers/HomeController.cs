using Car_Rental_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rental_MVC.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }




        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AdminZone()
        {
            return View();
        }
        public ActionResult Wrong()
        {
            return View();
        }

        public ActionResult SendMsg(Contactcls data)
        {
            Login obj = new Login();
            String query = "insert into Contact(Name,Contact,Subject,Msg) values('"+data.txtName.ToString()+"','"+data.txtContact.ToString()+"','"+data.txtSubject.ToString()+"','"+data.txtMsg.ToString()+"')";
            obj.SqlQuery(query);
            return View("Feedback");

        }
        public ActionResult Feedback()
        {
            return View();
        }


        public ActionResult LoginPass(Login data)
        {
            DataTable tbl = new DataTable();
            tbl = data.srchRecord("select * from admin where admin='"+data.AdminName+ "' and password='"+data.AdminPassword+"'");
            if (tbl.Rows.Count>0) {
                return View("AdminZone");
            }
            else {
                return View("Wrong");
            }

        }


        public ActionResult Contactcls()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}