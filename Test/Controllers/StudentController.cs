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
    public class StudentController : Controller
    {

        GetData GD = new GetUserData();
        UpLoadFile ulf = new UpLoadFile();
        SendData SD = new SendFileData();
        DeleteData DD = new UDeleteData();
        ChangeData CD = new UChangeDate();

        public ActionResult Index()
        {

            if (Request.IsAuthenticated)
            {
                if (User.Identity.Name != null)
                    ViewData["user"] = User.Identity.Name;

                int UID = GD.GetUserID(User.Identity.Name);

                List<SelCourses> smt = GD.GetSelCoursesInfo(User.Identity.Name);
                List<Courses> cmt = GD.GetCourses();

                var infos = from si in smt
                            join ci in cmt
                                on si.CID equals ci.CID
                            where si.ID == UID
                            select new NewSelCourse
                            {
                                CName = ci.CName,
                                Teacher = ci.Teacher,
                                Flag = ci.Flag,
                                Seltime = si.SelTime
                            };
                List<NewSelCourse> nsl = infos.ToList();
                return View(infos.ToList());
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }

        }

        public ActionResult UpLoadFile()
        {
            List<SelectListItem> CN = GD.GetCourseName();
            ViewData["CourseName"] = CN;
            return View();
        }

        [HttpPost]
        public ActionResult UpLoadFile(UpLoadFileModel model)
        {
            List<SelectListItem> CN = GD.GetCourseName();
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
                    for(int i =1; ;i++)
                    {
                        if (GD.If_CourseName_Exist(filename))
                        {
                            string front = filename.Substring(0,filename.IndexOf("."));
                            string follow = filename.Substring(filename.IndexOf("."));
                            filename = front + "(" + i.ToString() + ")" + follow ;
                        }
                        else
                            break;
                    }
                       
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
                        using (DataDataContext db = new DataDataContext())
                        {
                            db.Log = Console.Out;
                            db.UpLoadFile.InsertOnSubmit(exp);
                            db.SubmitChanges();
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
 
        public ActionResult DownLoadFile()
        {
            List<UpLoadFile> upl = GD.GetUpLoadFile();
            return View(upl.ToList());
        }
     
        public FilePathResult ReturnFile(string fileName,string furl)
        {
            CD.increaseDownLoadCount(fileName);
            return File(furl, "text/plain", fileName);
        }

        public ActionResult HandInEssay()
        {
            List<SelectListItem> CN = GD.GetCourseName();
            List<SelectListItem> TN = GD.GetTeacherName();
            ViewData["CourseName"] = CN;
            ViewData["TeacherName"] = TN;
            return View();
        }

        [HttpPost]
        public ActionResult HandInEssay(HandInEssayModel model)
        {
            List<SelectListItem> CN = GD.GetCourseName();
            List<SelectListItem> TN = GD.GetTeacherName();
            ViewData["CourseName"] = CN;
            ViewData["TeacherName"] = TN;

            foreach (string upload in Request.Files)
            {

                if (Request.Files[upload] == null && Request.ContentLength <= 0) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "Reference/AuI";
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
                        Tid = GD.GetUserID(model.Teacher),
                        Cid = GD.GetCourseID(model.CName),
                        Auid = GD.GetNextAuID();

                    if (Cid != 0)
                    {
                        AuditFile exp = new AuditFile
                        {
                            AuID = Auid,
                            ID = Uid,
                            CID = Cid,
                            FileName = filename,
                            AuditorID = Tid,
                            FileURL = serverpath
                        };
                        using (DataDataContext db = new DataDataContext())
                        {
                            db.Log = Console.Out;
                            db.AuditFile.InsertOnSubmit(exp);
                            db.SubmitChanges();
                        }
                        Request.Files[upload].SaveAs(serverpath);
                        ViewData["UpLoadResult"] = "上传成功,等待审核！";
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

        public ActionResult MangerRe()
        {

            List<SelectListItem> LS = GD.Getfitter("全部");
            ViewData["fitter"] = LS;
            List<MangerReModel> LU = new List<MangerReModel>();
            return View(LU.ToList());
        }

        [HttpPost]
        public ActionResult MangerRe(MangerReModel model)
        {
            int id = GD.GetUserID(User.Identity.Name);

            List<MangerReModel> LM = new List<MangerReModel>();
            if (model.Fitter == "全部")
                LM = GD.GetMangerRe(id);
            else
                LM = GD.GetMangerRe(id, model.Fitter);

            List<SelectListItem> LS = GD.Getfitter(model.Fitter);
            ViewData["fitter"] = LS;

            return View(LM.ToList());
        }

        public ActionResult Delete(int id,string fitter)
        {
            string fp = GD.GetFUrl(id);
            string path = AppDomain.CurrentDomain.BaseDirectory + "Reference/" + User.Identity.Name;
            DD.DeleteUpLoadFile(id,path);
            if (System.IO.File.Exists(fp))//先判断文件是否存在，再执行操作
                System.IO.File.Delete(fp);
            return RedirectToAction("MangerRe","Student");
        }

    }
}
