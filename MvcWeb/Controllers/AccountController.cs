using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MvcWeb.Models;

namespace MvcWeb.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        public ActionResult AdminAbout()
        {
            return View();
        }

        public ActionResult AdminTeacher()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            var model = data.Teachers;
            return View(model);
        }

        public ActionResult AdminStudent()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            var model = data.Students;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminTeacherCreate()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            Teacher model = new Teacher();
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminTeacherCreate(int id, FormCollection fc)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Teachers.FirstOrDefault(c => c.ID == num);
            if (model == null)
            {
                Teacher s = new Teacher();
                UpdateModel(s, new[] { "ID", "Name", "Sex", "Academic", "Password" });
                data.Teachers.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("AdminTeacher");
            }
            else
                return RedirectToAction("AdminTeacherCreate");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminTeacherDelete(int id)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Teachers.First(c => c.ID == num);
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminTeacherDelete(int id, FormCollection fc)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Teachers.First(c => c.ID == num);
            data.Teachers.DeleteOnSubmit(model);
            data.SubmitChanges();
            return RedirectToAction("AdminTeacher");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminTeacherEdit(int id)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Teachers.First(c => c.ID == num);
            return View(model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminTeacherEdit(int id, FormCollection fc)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Teachers.First(c => c.ID == num);
            UpdateModel(model, new[] { "Name", "Sex", "Academic", "Password"});
            data.SubmitChanges();
            return RedirectToAction("AdminTeacher");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminStudentCreate()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            Student model = new Student();
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminStudentCreate(int id,FormCollection fc)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Students.FirstOrDefault(c => c.ID == num);
            if (model == null)
            {
                Student s = new Student();
                UpdateModel(s, new[] {"ID", "Password", "Name", "Sex", "Academic", "Major", "Grade" });
                data.Students.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("AdminStudent");
            }
            else
                return RedirectToAction("AdminStudentCreate");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminStudentDelete(int id)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Students.First(c => c.ID == num);
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminStudentDelete(int id, FormCollection fc)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Students.First(c => c.ID == num);
            data.Students.DeleteOnSubmit(model);
            data.SubmitChanges();
            return RedirectToAction("AdminStudent");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminStudentEdit(int id)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Students.First(c => c.ID == num);
            return View(model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminStudentEdit(int id,FormCollection fc)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.Students.First(c => c.ID == num);
            UpdateModel(model, new[] { "Password", "Name", "Sex", "Academic", "Major","Grade" });            
            data.SubmitChanges();
            return RedirectToAction("AdminStudent");
        }

        public ActionResult TeacherAbout(string major)
        {
            return View();
        }

        public ActionResult TeacherStudentInfo(MajorGrade mg)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            List<SelectListItem> mojor = new List<SelectListItem>();
            List<SelectListItem> grade = new List<SelectListItem>();

            mojor.Add(new SelectListItem { Text = "请选择   ", Value = "empty", Selected = true });
            foreach (var m in data.Majors)
            {
                mojor.Add(new SelectListItem { Text = m.Major1, Value = m.Major1 });
            }

            grade.Add(new SelectListItem { Text = "请选择     ", Value = "empty", Selected = true });
            foreach (var m in data.Grades)
            {
                grade.Add(new SelectListItem { Text = m.Grade1, Value = m.Grade1 });
            }

            ViewData["Grade"] = grade;
            ViewData["Major"] = mojor;

            MajorGrade MG = new MajorGrade();
            if (mg.major == null && mg.grade ==null)
            {
                var s = from m in data.Students
                        where mg.major == m.Major && mg.grade == m.Grade
                        select m;
                MG.student = s;
            }
            else
            {
                if (mg.major == "全部")
                {
                    if (mg.grade == "全部" || mg.grade == "empty")
                    {
                        var s = from m in data.Students
                                select m;                        
                        MG.student = s;
                    }
                    else
                    {
                        var s = from m in data.Students
                                where mg.grade == m.Grade
                                select m;
                        MG.student = s;
                    }
                }
                else if (mg.grade == "全部")
                {
                    if (mg.major == "全部" || mg.major == "empty")
                    {
                        var s = from m in data.Students
                                select m;
                        MG.student = s;
                    }
                    else
                    {
                        var s = from m in data.Students
                                where mg.major == m.Major
                                select m;
                        MG.student = s;
                    }
                }
                else if (mg.major == "empty" && mg.grade != "empty")
                {
                    var s = from m in data.Students
                            where mg.grade == m.Grade
                            select m;                   
                    MG.student = s;
                }
                else if ((mg.major != null && mg.grade == null)
                    ||(mg.major != null && mg.grade == "empty"))
                {
                    var sm = from m in data.Students
                             where mg.major == m.Major
                             select m;
                    MG.student = sm;
                }
                else if ((mg.grade != null && mg.major == null)
                    ||(mg.grade != null && mg.major == "empty"))
                {
                    var sm = from m in data.Students
                             where mg.grade == m.Grade
                             select m;
                    MG.student = sm;
                }
                else
                {
                    var s = from m in data.Students
                            where mg.major == m.Major && mg.grade == m.Grade
                            select m;
                    MG.student = s;
                }
            }                      
            return View(MG);            
        }

        public ActionResult TeacherThesisCheck(StudentThesis st)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            List<SelectListItem> mojor = new List<SelectListItem>();
            List<SelectListItem> grade = new List<SelectListItem>();

            mojor.Add(new SelectListItem { Text = "请选择   ", Value = "empty", Selected = true });
            foreach (var m in data.Majors)
            {
                mojor.Add(new SelectListItem { Text = m.Major1, Value = m.Major1 });
            }

            grade.Add(new SelectListItem { Text = "请选择     ", Value = "empty", Selected = true });
            foreach (var m in data.Grades)
            {
                grade.Add(new SelectListItem { Text = m.Grade1, Value = m.Grade1 });
            }

            ViewData["Grade"] = grade;
            ViewData["Major"] = mojor;

            StudentThesis MG = new StudentThesis();
            if (st.major == null && st.grade == null)
            {
                var s = from m in data.Students
                        where st.major == m.Major && st.grade == m.Grade
                        select m;

                var mark = from k in data.ThesisTopics
                           select k;

                MG.student = s;
                MG.topic = mark;

            }
            else
            {
                if (st.major == "全部")
                {
                    if (st.grade == "全部" || st.grade == "empty")
                    {
                        var s = from m in data.Students
                                select m;

                        var mark = from k in data.ThesisTopics
                                   select k;
                        MG.student = s;
                        MG.topic = mark;
                    }
                    else
                    {
                        var s = from m in data.Students
                                where st.grade == m.Grade
                                select m;
                        var mark = from k in data.ThesisTopics
                                   select k;
                        MG.student = s;
                        MG.topic = mark;
                    }
                }
                else if (st.grade == "全部")
                {
                    if (st.major == "全部" || st.major == "empty")
                    {
                        var s = from m in data.Students
                                select m;
                        var mark = from k in data.ThesisTopics
                                   select k;
                        MG.student = s;
                        MG.topic = mark;
                    }
                    else
                    {
                        var s = from m in data.Students
                                where st.major == m.Major
                                select m;
                        var mark = from k in data.ThesisTopics
                                   select k;
                        MG.student = s;
                        MG.topic = mark;
                    }
                }
                else if (st.major == "empty" && st.grade != "empty")
                {
                    var s = from m in data.Students
                            where st.grade == m.Grade
                            select m;
                    var mark = from k in data.ThesisTopics
                               select k;
                    MG.student = s;
                    MG.topic = mark;
                }
                else if ((st.major != null && st.grade == null)
                    || (st.major != null && st.grade == "empty"))
                {
                    var s = from m in data.Students
                            where st.major == m.Major
                            select m;

                    var mark = from k in data.ThesisTopics
                               select k;
                    MG.student = s;
                    MG.topic = mark;
                }
                else if ((st.grade != null && st.major == null)
                    || (st.grade != null && st.major == "empty"))
                {
                    var s = from m in data.Students
                            where st.major == m.Major
                            select m;

                    var mark = from k in data.ThesisTopics

                               select k;
                    MG.student = s;
                    MG.topic = mark;
                }

                else
                {
                    var s = from m in data.Students
                            where st.major == m.Major && st.grade == m.Grade
                            select m;

                    var mark = from k in data.ThesisTopics

                               select k;
                    MG.student = s;
                    MG.topic = mark;
                }
            }
            return View(MG);
        }

        public ActionResult TeacherStudentGrade(StudentMark sm)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            List<SelectListItem> mojor = new List<SelectListItem>();
            List<SelectListItem> grade = new List<SelectListItem>();

            mojor.Add(new SelectListItem { Text = "请选择   ", Value = "empty", Selected = true });
            foreach (var m in data.Majors)
            {
                mojor.Add(new SelectListItem { Text = m.Major1, Value = m.Major1 });
            }

            grade.Add(new SelectListItem { Text = "请选择     ", Value = "empty", Selected = true });
            foreach (var m in data.Grades)
            {
                grade.Add(new SelectListItem { Text = m.Grade1, Value = m.Grade1 });
            }

            ViewData["Grade"] = grade;
            ViewData["Major"] = mojor;

            StudentMark MG = new StudentMark();
            if (sm.major == null && sm.grade == null)
            {
                var s = from m in data.Students
                        where sm.major == m.Major && sm.grade == m.Grade
                        select m;

                var mark = from k in data.Marks
                           select k;
                MG.student = s;
                MG.mark = mark;
                
            }
            else
            {
                if (sm.major == "全部")
                {
                    if (sm.grade == "全部" || sm.grade == "empty")
                    {
                        var s = from m in data.Students
                                select m;

                        var mark = from k in data.Marks

                                   select k;
                        MG.student = s;
                        MG.mark = mark;
                    }
                    else
                    {
                        var s = from m in data.Students
                                where sm.grade == m.Grade
                                select m;

                        var mark = from k in data.Marks

                                   select k;
                        MG.student = s;
                        MG.mark = mark;
                    }
                }
                else if (sm.grade == "全部")
                {
                    if (sm.major == "全部" || sm.major == "empty")
                    {
                        var s = from m in data.Students
                                select m;
                        var mark = from k in data.Marks
                                   select k;
                        MG.student = s;
                        MG.mark = mark;
                    }
                    else
                    {
                        var s = from m in data.Students
                                where sm.major == m.Major
                                select m;
                        var mark = from k in data.Marks
                                   select k;
                        MG.student = s;
                        MG.mark = mark;
                    }
                }
                else if (sm.major == "empty" && sm.grade != "empty")
                {
                    var s = from m in data.Students
                            where sm.grade == m.Grade
                            select m;
                    var mark = from k in data.Marks
                               select k;
                    MG.student = s;
                    MG.mark = mark;
                }
                else if ((sm.major != null && sm.grade == null)
                    || (sm.major != null && sm.grade == "empty"))
                {
                    var s = from m in data.Students
                             where sm.major == m.Major
                             select m;

                    var mark = from k in data.Marks
                               
                               select k;
                    MG.student = s;
                    MG.mark = mark;
                }
                else if ((sm.grade != null && sm.major == null)
                    || (sm.grade != null && sm.major == "empty"))
                {
                    var s = from m in data.Students
                            where sm.major == m.Major
                            select m;

                    var mark = from k in data.Marks
                               
                               select k;
                    MG.student = s;
                    MG.mark = mark;
                }
                
                else
                {
                    var s = from m in data.Students
                            where sm.major == m.Major && sm.grade == m.Grade
                            select m;

                    var mark = from k in data.Marks

                               select k;
                    MG.student = s;
                    MG.mark = mark;
                }
            }
            return View(MG);
        }

        public ActionResult CheckResultList(int id)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            StudentThesis st = new StudentThesis();
            string num = id.ToString();
            st.ID = num;
            st.student = data.Students;
            st.check = data.ThesisChecks;
            return View(st);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CheckResultEdit(int id)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.ThesisChecks.First(c => c.ID == num);
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CheckResultEdit(int id,FormCollection fc)
        {
            DataClassesDataContext data = new DataClassesDataContext();
            string num = id.ToString();
            var model = data.ThesisChecks.First(c=>c.ID == num);
            UpdateModel(model, new[] { "Topic", "Literature", "ResearchCapacity", "ThesisQuality", "InnovationCapacity" });
            foreach (var item in data.Marks)
            {
                if (item.ID == num)
                {
                    item.ThesisMark = model.Topic + model.Literature + model.ResearchCapacity + model.ThesisQuality + model.InnovationCapacity;
                }
            }
            UpdateModel(model, new[] {"Topic","Literature","ResearchCapacity","ThesisQuality","InnovationCapacity"});
            data.SubmitChanges();
            return RedirectToAction("TeacherThesisCheck");

        }

        public ActionResult StudentAbout()
        {
            return View();
        }
        
        public ActionResult StudentMark()
        {
            DataClassesDataContext data = new DataClassesDataContext();           
            StudentMark model = new StudentMark();
            model.student = data.Students;
            model.mark = data.Marks;
            return View(model);
        }

        public ActionResult StudentThesisMark()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            StudentThesis model = new StudentThesis();
            model.student = data.Students;
            model.check = data.ThesisChecks;
            return View(model);
        }

        public ActionResult StudentTeacherInfo()
        {
            DataClassesDataContext data = new DataClassesDataContext();
            var model = data.Teachers;
            return View(model);
        }
    }
}
