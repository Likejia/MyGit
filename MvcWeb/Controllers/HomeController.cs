using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWeb.Models;

namespace MvcWeb.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }

        public ActionResult Index(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                FormsService = new FormsAuthenticationService();
                FormsService.SignIn(model.UserName, true);

                string id = model.UserName.Trim().ToString();
                string password = model.Password.Trim().ToString();

                UserValidates user = new UserValidates();

                if(id == "10086" && password == "10086")
                {
                    return RedirectToAction("Admin","Home");
                }

                if (user.TeacherValidate(id, password))
                {
                    
                    return RedirectToAction("Teacher", "Home");
                }

                if (user.StudentValidate(id, password))
                {
                    return RedirectToAction("Student", "Home");
                }
            }            
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Teacher()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            foreach (var item in data.Marks)
            {
                foreach (var item1 in data.ThesisChecks)
                {
                    if (item.ID == item1.ID)
                    {
                        item.ThesisMark = item1.Topic + item1.Literature + item1.ResearchCapacity + item1.ThesisQuality + item1.InnovationCapacity;
                    }
                }
            }
            data.SubmitChanges();
            return View();
        }

        public ActionResult Student()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            foreach (var item in data.Marks)
            {
                foreach (var item1 in data.ThesisChecks)
                {
                    if (item.ID == item1.ID)
                    {
                        item.ThesisMark = item1.Topic + item1.Literature + item1.ResearchCapacity + item1.ThesisQuality + item1.InnovationCapacity;
                    }
                }
            }
            data.SubmitChanges();
            return View();
        }
    }
}
