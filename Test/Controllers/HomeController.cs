using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models; 

namespace Test.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                DataDataContext ddc = new DataDataContext();
                var usertype = (from n in ddc.Users
                                where n.Name == User.Identity.Name
                                select n.UserType).First();
                if (usertype == "Student")
                    return RedirectToAction("Index", "Student");
                else if (usertype == "Teacher")
                    return RedirectToAction("Index", "Teacher");
                else
                    return RedirectToAction("Index", "Admin"); 
            }
            else
            {
                ViewData["Message"] = "欢迎使用 ASP.NET MVC!";

                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
