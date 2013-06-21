using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;
using Test.Models;
using Test;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.Entity;

namespace Test.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        ChangeData CD = new UChangeDate();
        GetData GD = new GetUserData();
        DeleteData DD = new UDeleteData();
        UpLoadFile ulf = new UpLoadFile();
        SendData SD = new SendFileData();

        public ActionResult AuI()
        {
            List<AuIModels> res = GD.GetAuI(User.Identity.Name);
            return View(res.ToList());
        }

        public ActionResult PassAuI(string username,string furl,int auid,string filename)
        {
            string newpath = AppDomain.CurrentDomain.BaseDirectory + "Reference/" + username;
            string auipath = AppDomain.CurrentDomain.BaseDirectory + "Reference/AuI/" ;
            if (!Directory.Exists(newpath))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(newpath);//不存在则创建文件夹 
            }

            string destPath = Path.Combine(@newpath, Path.GetFileName(@furl));
            System.IO.File.Copy(@furl, destPath);
            
            DD.DeleteAuIFile(auid,auipath,destPath);

            return RedirectToAction("AuI", "Teacher");
        }


        public ActionResult Index()
        {
            List<Courses> C = GD.GetCourseName(User.Identity.Name);

            return View(C.ToList());
        }
        public ActionResult Audit()
        {

            return View();
        }

        //
        // GET: /Teacher/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Teacher/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teacher/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //if (!ModelState.IsValid)

                //    return View();

                //_db.AddToMovieSet(movieToCreate);

                //_db.SaveChanges();  


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Teacher/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Teacher/Edit/5

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

        //
        // GET: /Teacher/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Teacher/Delete/5

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
