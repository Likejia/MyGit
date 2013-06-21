using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.IO;

namespace Test.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private DataDataContext db = new DataDataContext();
        private int pageSize;
        private IMembershipService MembershipService { get; set; }
        private SendData SD = new SendFileData();
        private GetData GD = new GetUserData();
        private GetNewData GND = new GetNewData();

        public AdminController()
        {
            pageSize = 10;
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                if (User.Identity.Name != null)
                    ViewData["user"] = User.Identity.Name;

                ViewData["users"] = new shortList<Users>(db.Users.ToList());
                ViewData["courses"] = new shortList<Courses>(db.Courses.ToList());
                ViewData["files"] = new shortList<newUpLoadFiles>(GND.GetNewUpLoadFiles());
                ViewData["applyNewCourses"] = new shortList<newapplyNewCourse>(GND.GetapplyNewCourse());

                return View();
            }
            else
                return RedirectToAction("LogOn", "Account");
        }

        public ActionResult Admin_users(int? page)
        {
            //var NewsList = db.Users.Select(ID =>ID); 
            //var paginatedNews = new NewList<Users>(NewsList, page ??0, pageSize);
            var NewsList = db.Users.ToList();
            var paginatedNews = new NewList<Users>(NewsList, page ?? 0, pageSize);


            return View(paginatedNews);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Admin_users(FormCollection formValues)
        {
            int? index = int.Parse(formValues.GetValue("pageindex").AttemptedValue);
            int page = index ?? 0;
            //var NewsList = db.Users.Select(ID => ID);
            var NewsList = db.Users.ToList();
            var paginatedNews = new NewList<Users>(NewsList, page, pageSize);

            return View(paginatedNews);
        }

        // GET: /Users/Create

        public ActionResult Admin_usersCreate()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            List<SelectListItem> list = new List<SelectListItem> {
            new SelectListItem { Text = "学生", Value = "Student",Selected = true},
            new SelectListItem { Text = "老师", Value = "Teacher" } 
            };
            ViewData["listID"] = list;
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Admin_usersCreate([Bind(Exclude = "ID")] Users userToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                if (!MembershipService.IsUserNameExist(userToCreate.Name))
                {
                    MembershipService.CreateUser(userToCreate.Name, userToCreate.PassWord, userToCreate.UserType);
                }
                else
                {
                    ModelState.AddModelError("", "用户名已经存在");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            List<SelectListItem> list = new List<SelectListItem> {
            new SelectListItem { Text = "学生", Value = "Student",Selected = true},
            new SelectListItem { Text = "老师", Value = "Teacher" } 
            };
            ViewData["listID"] = list;

            return RedirectToAction("Admin_users");
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Admin_usersEdit(int id)
        {
            var userToEdit = (from n in db.Users
                              where n.ID == id
                              select n).First();
            List<SelectListItem> list = new List<SelectListItem> {
            new SelectListItem { Text = "学生", Value = "Student"},
            new SelectListItem { Text = "老师", Value = "Teacher" } 
            };
            ViewData["Usertype"] = new SelectList(list, "Value", "Text", userToEdit.UserType);

            return View(userToEdit);
        }

        //
        // POST:

        [HttpPost]
        public ActionResult Admin_usersEdit([Bind(Exclude = "ID")] Users userToEdit)
        {
            List<SelectListItem> list = new List<SelectListItem> {
            new SelectListItem { Text = "学生", Value = "Student"},
            new SelectListItem { Text = "老师", Value = "Teacher" } 
            };
            ViewData["Usertype"] = new SelectList(list, "Value", "Text", "Usertype");

            var user = (from n in db.Users
                        where n.ID == userToEdit.ID
                        select n).First();
            if (!ModelState.IsValid)
                return View();

            db.Users.DeleteOnSubmit(user);
            db.Users.InsertOnSubmit(userToEdit);
            db.SubmitChanges();
            return RedirectToAction("Admin_users");
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Admin_usersDelete(int id)
        {

            var user = (from n in db.Users
                        where n.ID == id
                        select n).First();
            if (!ModelState.IsValid)
                return View();

            db.Users.DeleteOnSubmit(user);
            db.SubmitChanges();

            return RedirectToAction("Admin_users");
        }


        //课程管理页面
        public ActionResult Admin_courses(int? page)
        {
            //var NewsList = db.Courses.Select(ID =>ID); 
            //var paginatedNews = new NewList<Courses>(NewsList, page ??0, pageSize);
            var NewsList = db.Courses.ToList();
            var paginatedNews = new NewList<Courses>(NewsList, page ?? 0, pageSize);

            return View(paginatedNews);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Admin_courses(FormCollection formValues)
        {
            int? index = int.Parse(formValues.GetValue("pageindex").AttemptedValue);
            int page = index ?? 0;
            //var NewsList = db.Courses.Select(CID => CID);
            var NewsList = db.Courses.ToList();
            var paginatedNews = new NewList<Courses>(NewsList, page, pageSize);

            return View(paginatedNews);
        }

        public ActionResult Admin_coursesEdit(int id)
        {
            var courseToEdit = (from n in db.Courses
                                where n.CID == id
                                select n).First();

            return View(courseToEdit);
        }

        //
        // POST:

        [HttpPost]
        public ActionResult Admin_coursesEdit([Bind(Exclude = "CID")]Courses courseToEdit)
        {

            var course = (from n in db.Courses
                          where n.CID == courseToEdit.CID
                          select n).First();
            if (!ModelState.IsValid)
                return View();

            db.Courses.DeleteOnSubmit(course);
            db.Courses.InsertOnSubmit(courseToEdit);
            db.SubmitChanges();
            return RedirectToAction("Admin_courses");
        }

        public ActionResult Admin_coursesDelete(int id)
        {

            var course = (from n in db.Courses
                          where n.CID == id
                          select n).First();
            if (!ModelState.IsValid)
                return View();

            db.Courses.DeleteOnSubmit(course);
            db.SubmitChanges();

            return RedirectToAction("Admin_courses");
        }

        //资料管理
        public ActionResult Admin_files(int? page)
        {
            //var NewsList = db.UpLoadFile.Select(ID =>ID); 
            //var paginatedNews = new NewList<UpLoadFile>(NewsList, page ??0, pageSize);
            var NewsList = GND.GetNewUpLoadFiles();
            var paginatedNews = new NewList<newUpLoadFiles>(NewsList, page ?? 0, pageSize);


            return View(paginatedNews);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Admin_files(FormCollection formValues)
        {
            int? index = int.Parse(formValues.GetValue("pageindex").AttemptedValue);
            int page = index ?? 0;
            //var NewsList = db.UpLoadFile.Select(UID => UID);
            var NewsList = GND.GetNewUpLoadFiles();
            var paginatedNews = new NewList<newUpLoadFiles>(NewsList, page, pageSize);

            return View(paginatedNews);
        }

        public ActionResult Admin_filesDelete(int id)
        {
            var file =
                (from n in db.UpLoadFile
                 where n.UID == id
                 select n).First();
            Directory.Delete(file.FUrl);
            db.UpLoadFile.DeleteOnSubmit(file);
            db.SubmitChanges();

            return RedirectToAction("Admin_files");
        }

        //文件上传
        public ActionResult Admin_UpLoadFile()
        {
            List<SelectListItem> CN = new List<SelectListItem>();

            foreach (var item in db.Courses)
            {
                SelectListItem listItem = new SelectListItem { Text = item.CName, Value = item.CName };
                CN.Add(listItem);
            }
            ViewData["CourseName"] = CN;
            return View();
        }

        [HttpPost]
        public ActionResult Admin_UpLoadFile(UpLoadFileModel model)
        {
            List<SelectListItem> CN = new List<SelectListItem>();

            foreach (var item in db.Courses)
            {
                SelectListItem listItem = new SelectListItem { Text = item.CName, Value = item.CName };
                CN.Add(listItem);
            }
            ViewData["CourseName"] = CN;
            foreach (string upload in Request.Files)
            {

                if (Request.Files[upload] == null && Request.ContentLength <= 0) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "Reference/" + User.Identity.Name;
                if (!Directory.Exists(path))//判断文件夹是否存在 
                {
                    Directory.CreateDirectory(path);//不存在则创建文件夹 
                }

                string filename = Path.GetFileName(Request.Files[upload].FileName);
                if (filename == "")
                {
                    ModelState.AddModelError("", "请重新选择要上传的文件！");
                }
                else
                {
                    string serverpath = Path.Combine(path + "/", filename);

                    int Uid = GD.GetUserID(User.Identity.Name),
                        Cid = GD.GetCourseID(model.CName),
                        Uuid = GD.GetNextUID_InUpLoadFile();

                    if (Cid != 0)
                    {
                        UpLoadFile exp = new UpLoadFile
                        {
                            UID = Uuid,
                            ID = Uid,
                            CID = Cid,
                            FileName = filename,
                            FUrl = serverpath,
                            UpLoadTime = DateTime.Now,
                            DownLoadCount = 0
                        };
                        using (DataDataContext ddc = new DataDataContext())
                        {
                            ddc.Log = Console.Out;
                            ddc.UpLoadFile.InsertOnSubmit(exp);
                            ddc.SubmitChanges();
                        }
                        Request.Files[upload].SaveAs(serverpath);
                        ViewData["UpLoadResult"] = "上传成功";
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "填写的课程信息不存在，请重新填写！");
                    }
                }
            }

            return View();
        }

        //文件下载
        public FilePathResult ReturnFile(string fileName)
        {
            var fileUrl = (from n in db.UpLoadFile
                           where n.FileName == fileName
                           select n.FUrl).First();

            string path = fileUrl;
            return File(path, "text/plain", fileName);
        }


        //课程审核
        public ActionResult Admin_applyNewCourse(int? page)
        {
            //var NewsList = db.ApplyNewCourse.Select(ID =>ID); 
            //var paginatedNews = new NewList<ApplyNewCourse>(NewsList, page ??0, pageSize);
            var NewsList = GND.GetapplyNewCourse();
            var paginatedNews = new NewList<newapplyNewCourse>(NewsList, page ?? 0, pageSize);

            return View(paginatedNews);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Admin_applyNewCourse(FormCollection formValues)
        {
            int? index = int.Parse(formValues.GetValue("pageindex").AttemptedValue);
            int page = index ?? 0;
            //var NewsList = db.ApplyNewCourse.Select(AI => AI);

            var NewsList = GND.GetapplyNewCourse();
            var paginatedNews = new NewList<newapplyNewCourse>(NewsList, page, pageSize);

            return View(paginatedNews);
        }

        public ActionResult applyNewCourseDelete(int id)
        {
            var newCourse = (from n in db.ApplyNewCourse
                             where n.AI == id
                             select n).First();

            db.ApplyNewCourse.DeleteOnSubmit(newCourse);
            return RedirectToAction("Admin_applyNewCourse");
        }

        public ActionResult pass(int id)
        {
            var newCourse = (from n in db.ApplyNewCourse
                             where n.AI == id
                             select n).First();
            var teacher = (from n in db.Users
                           where n.ID == newCourse.ID
                           select n.Name).First();
            Courses course = new Courses
            {
                CID = db.Courses.Count() + 1,
                CName = newCourse.CourseName,
                Teacher = teacher,
                Flag = "计算机类"
            };
            db.Courses.InsertOnSubmit(course);
            db.ApplyNewCourse.DeleteOnSubmit(newCourse);
            db.SubmitChanges();

            return RedirectToAction("Admin_applyNewCourse");
        }
    }
}
